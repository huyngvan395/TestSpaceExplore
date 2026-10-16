using UnityEngine;

/// <summary>
/// Tank AI: slow, very durable heavy enemy. HP=6, Score=100.
/// Moves slowly toward player. Hard to kill.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class TankAI : Monster
{
    [Header("Tank Settings")]
    public float moveSpeed = 1.5f;
    public float detectionRadius = 10f;

    private Rigidbody2D rb;

    protected override void Awake()
    {
        base.Awake();
        maxHP = 6f;
        scoreValue = 100f;
        contactDamage = 40f;
        currentHP = maxHP;
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 0f;
            rb.linearDamping = 3f;
            rb.mass = 5f;
        }
    }

    private void FixedUpdate()
    {
        if (!GameManager.Instance.IsPlaying || player == null) return;

        float dist = Vector2.Distance(rb.position, player.position);
        if (dist > detectionRadius) return;

        Vector2 dir = ((Vector2)player.position - rb.position).normalized;
        rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, dir * moveSpeed, 2f * Time.fixedDeltaTime);
    }
}
