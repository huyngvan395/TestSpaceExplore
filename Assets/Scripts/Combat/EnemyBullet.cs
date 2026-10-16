using UnityEngine;

/// <summary>
/// Enemy plasma projectile fired by Gunner and Boss.
/// Visually distinct from player laser.
/// Moves toward player direction, deals damage on contact.
/// </summary>
public class EnemyBullet : MonoBehaviour
{
    [Header("Enemy Bullet Settings")]
    public float speed = 7f;
    public float lifetime = 4f;
    public float damage = 20f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        if (rb != null)
            rb.linearVelocity = transform.up * speed;

        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
