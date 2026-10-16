using UnityEngine;

/// <summary>
/// Chaser AI: detects player and chases them.
/// Speeds up when nearby. Forces player to keep moving.
/// HP=2, Score=40.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class ChaserAI : Monster
{
    [Header("Chaser Movement")]
    public float moveSpeed = 4f;
    public float detectionRadius = 12f;
    public float chargeRadius = 3f;
    public float chargeSpeedMultiplier = 2f;

    private Rigidbody2D rb;
    private bool isChasing;

    protected override void Awake()
    {
        base.Awake();
        maxHP = 2f;
        scoreValue = 40f;
        contactDamage = 30f;
        currentHP = maxHP;
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 0f;
            rb.linearDamping = 2f;
        }
    }

    private void Update()
    {
        if (!GameManager.Instance.IsPlaying) return;
        if (player == null) return;

        float dist = Vector2.Distance(transform.position, player.position);
        isChasing = dist <= detectionRadius;
    }

    private void FixedUpdate()
    {
        if (!GameManager.Instance.IsPlaying || player == null || !isChasing) return;

        Vector2 dir = ((Vector2)player.position - rb.position).normalized;
        float dist = Vector2.Distance(rb.position, player.position);

        float speed = moveSpeed;
        if (dist <= chargeRadius)
            speed *= chargeSpeedMultiplier;

        rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, dir * speed, 5f * Time.fixedDeltaTime);
    }
}
