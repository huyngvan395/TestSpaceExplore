using UnityEngine;

/// <summary>
/// Manages Aurora's Energy resource.
/// Energy is consumed by Boost and certain world interactions.
/// Energy Cell pickups restore energy.
/// </summary>
public class PlayerEnergy : MonoBehaviour
{
    [Header("Energy")]
    public float maxEnergy = 100f;
    public float currentEnergy { get; private set; }

    // Upgrade modifier applied by UpgradeManager
    [HideInInspector] public float maxEnergyBonus = 0f;

    // Events
    public static System.Action<float, float> OnEnergyChanged; // current, max

    private void Awake()
    {
        currentEnergy = GetMaxEnergy();
    }

    private void Start()
    {
        OnEnergyChanged?.Invoke(currentEnergy, GetMaxEnergy());
    }

    public float GetMaxEnergy() => maxEnergy + maxEnergyBonus;

    public bool HasEnergy() => currentEnergy > 0.1f;

    /// <summary>Called every FixedUpdate while boosting.</summary>
    public void ConsumeEnergy(float amount)
    {
        currentEnergy = Mathf.Max(0f, currentEnergy - amount);
        OnEnergyChanged?.Invoke(currentEnergy, GetMaxEnergy());
    }

    /// <summary>Restore a flat amount of energy (e.g. from Energy Cell pickup).</summary>
    public void RestoreEnergy(float amount)
    {
        currentEnergy = Mathf.Min(GetMaxEnergy(), currentEnergy + amount);
        OnEnergyChanged?.Invoke(currentEnergy, GetMaxEnergy());
    }

    /// <summary>Called by Magnet power-up or other effects that need the full bar.</summary>
    public void SetMaxEnergy(float bonus)
    {
        maxEnergyBonus = bonus;
        // Clamp current to new max
        currentEnergy = Mathf.Min(currentEnergy, GetMaxEnergy());
        OnEnergyChanged?.Invoke(currentEnergy, GetMaxEnergy());
    }
}
