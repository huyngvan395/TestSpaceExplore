using UnityEngine;

/// <summary>
/// Asteroid hazard. Three sizes: Large (HP3), Medium (HP2), Small (HP1).
/// Large splits into 2 Medium, Medium splits into 2 Small, Small destroys.
/// Moves in random direction, rotates.
/// </summary>
public class Asteroid : MonoBehaviour
{
    public enum AsteroidSize { Large, Medium, Small }

    [Header("Asteroid Config")]
    public AsteroidSize size = AsteroidSize.Large;

    [Header("Prefabs for splitting")]
    public GameObject mediumPrefab;
    public GameObject smallPrefab;

    [Header("Movement")]
    public float minSpeed = 1.5f;
    public float maxSpeed = 4f;
    public float rotationSpeed = 50f;

    private float hp;
    private Rigidbody2D rb;

    // Damage values for player contact
    private static readonly float[] contactDamage = { 50f, 35f, 25f }; // Large, Medium, Small

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        switch (size)
        {
            case AsteroidSize.Large:  hp = 3f; break;
            case AsteroidSize.Medium: hp = 2f; break;
            case AsteroidSize.Small:  hp = 1f; break;
        }
    }

    private void Start()
    {
        // Random movement direction
        Vector2 dir = Random.insideUnitCircle.normalized;
        float speed = Random.Range(minSpeed, maxSpeed);
        if (rb != null) rb.linearVelocity = dir * speed;

        // Random rotation
        if (rb != null) rb.angularVelocity = Random.Range(-rotationSpeed, rotationSpeed);
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        VFXManager.Instance?.PlayAsteroidHit(transform.position);

        if (hp <= 0f)
        {
            Destroy();
        }
    }

    private void Destroy()
    {
        int score = 0;
        GameObject splitPrefab = null;

        switch (size)
        {
            case AsteroidSize.Large:
                score = 20;
                splitPrefab = mediumPrefab;
                SpawnSplit(splitPrefab, 2);
                break;
            case AsteroidSize.Medium:
                score = 30;
                splitPrefab = smallPrefab;
                SpawnSplit(splitPrefab, 2);
                break;
            case AsteroidSize.Small:
                score = 50;
                break;
        }

        ScoreManager.Instance?.AddScore(score);
        VFXManager.Instance?.PlayAsteroidExplosion(transform.position);
        AudioManager.Instance?.PlayExplosion();
        Destroy(gameObject);
    }

    private void SpawnSplit(GameObject prefab, int count)
    {
        if (prefab == null) return;
        for (int i = 0; i < count; i++)
        {
            Vector2 offset = Random.insideUnitCircle.normalized * 0.5f;
            GameObject go = Instantiate(prefab, (Vector2)transform.position + offset, Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        PlayerHealth player = col.gameObject.GetComponent<PlayerHealth>();
        if (player != null)
        {
            float dmg = contactDamage[(int)size];
            player.TakeDamage(dmg);
        }
    }

    public float GetContactDamage() => contactDamage[(int)size];
}
