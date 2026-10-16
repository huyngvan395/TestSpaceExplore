using UnityEngine;

/// <summary>
/// Base class for all alien monsters. Handles HP, score, damage events.
/// Subclasses (ChaserAI, GunnerAI, TankAI) implement movement.
/// </summary>
public class Monster : MonoBehaviour
{
    [Header("Monster Stats")]
    public float maxHP = 2f;
    public float scoreValue = 40f;
    public float contactDamage = 30f;

    protected float currentHP;
    protected Transform player;

    public static System.Action OnMonsterKilled;

    protected virtual void Awake()
    {
        currentHP = maxHP;
    }

    protected virtual void Start()
    {
        // Find player
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null) player = playerObj.transform;
    }

    public virtual void TakeDamage(float damage)
    {
        currentHP -= damage;
        VFXManager.Instance?.PlayEnemyHit(transform.position);
        AudioManager.Instance?.PlayEnemyHit();

        if (currentHP <= 0f)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        ScoreManager.Instance?.AddScore((int)scoreValue);
        MissionManager.Instance?.OnMonsterKilled();
        OnMonsterKilled?.Invoke();
        VFXManager.Instance?.PlayEnemyExplosion(transform.position);
        AudioManager.Instance?.PlayExplosion();
        Destroy(gameObject);
    }

    protected virtual void OnCollisionEnter2D(Collision2D col)
    {
        PlayerHealth ph = col.gameObject.GetComponent<PlayerHealth>();
        if (ph != null)
        {
            ph.TakeDamage(contactDamage);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth ph = other.GetComponent<PlayerHealth>();
        if (ph != null)
        {
            ph.TakeDamage(contactDamage);
        }
    }
}
