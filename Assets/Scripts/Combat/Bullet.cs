using UnityEngine;

/// <summary>
/// Player laser projectile.
/// Moves forward, damages asteroids and enemies, has limited lifetime.
/// </summary>
public class Bullet : MonoBehaviour
{
    [Header("Bullet Settings")]
    public float speed = 18f;
    public float lifetime = 2.5f;
    public float damage = 1f; // upgraded by LaserUpgrade

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
        // Hit asteroid
        Asteroid asteroid = other.GetComponent<Asteroid>();
        if (asteroid != null)
        {
            asteroid.TakeDamage(damage);
            SpawnImpact();
            Destroy(gameObject);
            return;
        }

        // Hit monster
        Monster monster = other.GetComponent<Monster>();
        if (monster != null)
        {
            monster.TakeDamage(damage);
            SpawnImpact();
            Destroy(gameObject);
            return;
        }

        // Hit boss
        BossController boss = other.GetComponent<BossController>();
        if (boss != null)
        {
            boss.TakeDamage(damage);
            SpawnImpact();
            Destroy(gameObject);
            return;
        }
    }

    private void SpawnImpact()
    {
        VFXManager.Instance?.PlayLaserImpact(transform.position);
    }
}
