using UnityEngine;
using System.Collections;

/// <summary>
/// Dreadnought Boss Controller. Three phases:
/// Phase 1: Fan Shot  
/// Phase 2 (60% HP): Summon Chasers + continue attacks
/// Phase 3 (30% HP): Enrage — faster attacks + Charge
/// </summary>
public class BossController : MonoBehaviour
{
    [Header("Boss Stats")]
    public float maxHP = 40f;
    public float currentHP { get; private set; }

    [Header("Movement")]
    public float moveSpeed = 3f;
    public float patrolRadius = 6f;

    [Header("Phase 1 — Fan Shot")]
    public GameObject bossBulletPrefab;
    public int fanBulletCount = 5;
    public float fanAngle = 120f;
    public float phase1FireInterval = 2.5f;

    [Header("Phase 2 — Summon")]
    public GameObject chaserPrefab;
    public float summonInterval = 6f;
    public int summonsPerWave = 2;

    [Header("Phase 3 — Enrage")]
    public float enrageSpeedMult = 1.35f;
    public float chargeInterval = 5f;
    public float chargeSpeed = 18f;
    public float chargeWarningTime = 0.5f;

    [Header("References")]
    public Transform player;

    // Events
    public static System.Action OnBossDefeated;

    private int phase = 1;
    private bool isEnraged;
    private bool isCharging;
    private Vector2 patrolTarget;
    private float fireTimer;
    private float summonTimer;
    private float chargeTimer;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Color originalColor;

    // HP thresholds
    private const float Phase2Threshold = 0.60f;
    private const float Phase3Threshold = 0.30f;

    public static System.Action<float, float> OnBossHPChanged;

    private void Awake()
    {
        currentHP = maxHP;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        if (sr != null) originalColor = sr.color;

        if (rb != null)
        {
            rb.gravityScale = 0f;
            rb.linearDamping = 3f;
        }

        PickNewPatrolTarget();
    }

    private void Start()
    {
        // Find player if not assigned
        if (player == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p != null) player = p.transform;
        }

        OnBossHPChanged?.Invoke(currentHP, maxHP);
        fireTimer = phase1FireInterval;
        summonTimer = summonInterval;
        chargeTimer = chargeInterval;
    }

    private void Update()
    {
        if (!GameManager.Instance.IsPlaying) return;

        UpdatePhase();
        UpdateTimers();
    }

    private void FixedUpdate()
    {
        if (!GameManager.Instance.IsPlaying || isCharging) return;

        Patrol();
    }

    private void UpdatePhase()
    {
        float hpRatio = currentHP / maxHP;

        if (hpRatio <= Phase3Threshold && phase < 3)
        {
            phase = 3;
            Enrage();
        }
        else if (hpRatio <= Phase2Threshold && phase < 2)
        {
            phase = 2;
        }
    }

    private void UpdateTimers()
    {
        float mult = isEnraged ? enrageSpeedMult : 1f;

        fireTimer -= Time.deltaTime * mult;
        if (fireTimer <= 0f)
        {
            FanShot();
            fireTimer = phase1FireInterval;
        }

        if (phase >= 2)
        {
            summonTimer -= Time.deltaTime;
            if (summonTimer <= 0f)
            {
                SummonChasers();
                summonTimer = summonInterval;
            }
        }

        if (phase >= 3)
        {
            chargeTimer -= Time.deltaTime * mult;
            if (chargeTimer <= 0f && !isCharging)
            {
                StartCoroutine(ChargeAttack());
                chargeTimer = chargeInterval;
            }
        }
    }

    private void Patrol()
    {
        if (rb == null) return;

        Vector2 dir = (patrolTarget - rb.position);
        if (dir.magnitude < 0.5f)
        {
            PickNewPatrolTarget();
        }
        else
        {
            rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, dir.normalized * moveSpeed, 3f * Time.fixedDeltaTime);
        }
    }

    private void PickNewPatrolTarget()
    {
        Vector2 center = player != null ? (Vector2)player.position : Vector2.zero;
        center += Random.insideUnitCircle.normalized * patrolRadius;
        patrolTarget = center;
    }

    private void FanShot()
    {
        if (bossBulletPrefab == null || player == null) return;

        Vector2 dir = ((Vector2)player.position - (Vector2)transform.position).normalized;
        float baseAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        for (int i = 0; i < fanBulletCount; i++)
        {
            float t = fanBulletCount > 1 ? i / (float)(fanBulletCount - 1) : 0.5f;
            float angle = Mathf.Lerp(-fanAngle / 2f, fanAngle / 2f, t) + baseAngle - 90f;
            Quaternion rot = Quaternion.Euler(0, 0, angle);
            Instantiate(bossBulletPrefab, transform.position, rot);
        }

        AudioManager.Instance?.PlayBossAttack();
    }

    private void SummonChasers()
    {
        if (chaserPrefab == null) return;
        for (int i = 0; i < summonsPerWave; i++)
        {
            Vector2 pos = (Vector2)transform.position + Random.insideUnitCircle.normalized * 3f;
            Instantiate(chaserPrefab, pos, Quaternion.identity);
        }
    }

    private void Enrage()
    {
        isEnraged = true;
        // Visual feedback — tint red
        if (sr != null)
            sr.color = new Color(1f, 0.3f, 0.3f);
    }

    private IEnumerator ChargeAttack()
    {
        if (player == null || rb == null) yield break;

        isCharging = true;
        Vector2 chargeTarget = player.position;

        // Warning phase
        if (sr != null) sr.color = Color.yellow;
        AudioManager.Instance?.PlayBossWarning();
        yield return new WaitForSeconds(chargeWarningTime);

        if (sr != null) sr.color = isEnraged ? new Color(1f, 0.3f, 0.3f) : originalColor;

        // Charge
        Vector2 dir = (chargeTarget - rb.position).normalized;
        rb.linearVelocity = dir * chargeSpeed;

        yield return new WaitForSeconds(0.4f);

        rb.linearVelocity = Vector2.zero;
        isCharging = false;
    }

    public void TakeDamage(float damage)
    {
        currentHP = Mathf.Max(0f, currentHP - damage);
        OnBossHPChanged?.Invoke(currentHP, maxHP);

        if (currentHP <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        ScoreManager.Instance?.AddScore(1000);
        VFXManager.Instance?.PlayBossExplosion(transform.position);
        AudioManager.Instance?.PlayExplosion();
        OnBossDefeated?.Invoke();
        GameManager.Instance.TriggerVictory();
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        PlayerHealth ph = col.gameObject.GetComponent<PlayerHealth>();
        if (ph != null) ph.TakeDamage(60f);
    }
}
