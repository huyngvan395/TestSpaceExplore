using UnityEngine;
using System.Collections;

/// <summary>
/// Manages Aurora's HP. HP=100. Invincibility frames prevent duplicate damage.
/// Shield power-up blocks one hit. Triggers GameOver at 0 HP.
/// </summary>
public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    public float maxHP = 100f;
    public float currentHP { get; private set; }

    [Header("Invincibility")]
    public float invincibilityDuration = 0.8f;

    // Shield state (set by ShieldPowerUp)
    public bool HasShield { get; private set; }

    // Events
    public static System.Action<float, float> OnHealthChanged; // current, max
    public static System.Action OnPlayerDied;
    public static System.Action OnShieldHit;
    public static System.Action OnShieldActivated;
    public static System.Action OnShieldDeactivated;

    private bool isInvincible;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        currentHP = maxHP;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        OnHealthChanged?.Invoke(currentHP, maxHP);
    }

    /// <summary>Apply damage from a source. Pass tag/name for context.</summary>
    public void TakeDamage(float amount)
    {
        if (isInvincible) return;

        if (HasShield)
        {
            // Shield absorbs the hit
            DeactivateShield();
            OnShieldHit?.Invoke();
            StartCoroutine(InvincibilityCoroutine());
            return;
        }

        currentHP = Mathf.Max(0f, currentHP - amount);
        OnHealthChanged?.Invoke(currentHP, maxHP);

        if (currentHP <= 0f)
        {
            Die();
        }
        else
        {
            StartCoroutine(InvincibilityCoroutine());
            StartCoroutine(FlashCoroutine());
        }
    }

    /// <summary>Restore HP by a fraction of max (e.g. 0.25 = 25%).</summary>
    public void Heal(float fraction)
    {
        currentHP = Mathf.Min(maxHP, currentHP + maxHP * fraction);
        OnHealthChanged?.Invoke(currentHP, maxHP);
    }

    public void ActivateShield()
    {
        HasShield = true;
        OnShieldActivated?.Invoke();
    }

    public void DeactivateShield()
    {
        HasShield = false;
        OnShieldDeactivated?.Invoke();
    }

    private void Die()
    {
        OnPlayerDied?.Invoke();
        GameManager.Instance.TriggerGameOver();
        gameObject.SetActive(false);
    }

    private IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        isInvincible = false;
    }

    private IEnumerator FlashCoroutine()
    {
        if (spriteRenderer == null) yield break;
        Color original = spriteRenderer.color;
        for (int i = 0; i < 3; i++)
        {
            spriteRenderer.color = new Color(1f, 0.3f, 0.3f, 0.6f);
            yield return new WaitForSeconds(0.08f);
            spriteRenderer.color = original;
            yield return new WaitForSeconds(0.08f);
        }
    }
}
