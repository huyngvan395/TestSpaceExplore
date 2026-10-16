using UnityEngine;

/// <summary>
/// Gunner AI: maintains distance, fires plasma bullets at player.
/// HP=2, Score=60. Moves laterally and shoots.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class GunnerAI : Monster
{
    [Header("Gunner Settings")]
    public float preferredDistance = 7f;
    public float moveSpeed = 2.5f;
    public float strafeSpeed = 3f;
    public float fireInterval = 2f;
    public float detectionRadius = 15f;
    public GameObject bulletPrefab;

    private Rigidbody2D rb;
    private float fireTimer;
    private int strafeDir = 1;
    private float strafeSwitchTimer;

    protected override void Awake()
    {
        base.Awake();
        maxHP = 2f;
        scoreValue = 60f;
        contactDamage = 30f;
        currentHP = maxHP;
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 0f;
            rb.linearDamping = 3f;
        }
        strafeSwitchTimer = Random.Range(2f, 4f);
    }

    private void Update()
    {
        if (!GameManager.Instance.IsPlaying || player == null) return;

        fireTimer -= Time.deltaTime;
        strafeSwitchTimer -= Time.deltaTime;

        if (strafeSwitchTimer <= 0f)
        {
            strafeDir = -strafeDir;
            strafeSwitchTimer = Random.Range(2f, 4f);
        }

        float dist = Vector2.Distance(transform.position, player.position);
        if (dist <= detectionRadius && fireTimer <= 0f)
        {
            Shoot();
            fireTimer = fireInterval;
        }
    }

    private void FixedUpdate()
    {
        if (!GameManager.Instance.IsPlaying || player == null) return;

        Vector2 dir = ((Vector2)player.position - rb.position).normalized;
        float dist = Vector2.Distance(rb.position, player.position);
        Vector2 desiredVel = Vector2.zero;

        // Approach or retreat to maintain distance
        if (dist > preferredDistance + 1f)
            desiredVel += dir * moveSpeed;
        else if (dist < preferredDistance - 1f)
            desiredVel -= dir * moveSpeed;

        // Strafe laterally
        Vector2 perp = new Vector2(-dir.y, dir.x) * strafeDir;
        desiredVel += perp * strafeSpeed;

        rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, desiredVel, 4f * Time.fixedDeltaTime);
    }

    private void Shoot()
    {
        if (bulletPrefab == null || player == null) return;

        Vector2 dir = ((Vector2)player.position - (Vector2)transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        Quaternion rot = Quaternion.Euler(0, 0, angle);

        Instantiate(bulletPrefab, transform.position, rot);
        AudioManager.Instance?.PlayEnemyShoot();
    }
}
