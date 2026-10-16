using UnityEngine;

/// <summary>
/// PlayerCombat: handles laser firing with SPACE key.
/// Supports normal fire, rapid-fire, triple-shot power-ups.
/// Bullet prefab must be assigned (or auto-created by SceneSetupEditor).
/// </summary>
public class PlayerCombat : MonoBehaviour
{
    [Header("Combat")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float baseFireInterval = 0.35f;

    [Header("Triple Shot Angles")]
    public float tripleAngle = 18f;

    // Power-up state (set externally)
    [HideInInspector] public bool rapidFire;
    [HideInInspector] public bool tripleShot;
    [HideInInspector] public float laserDamageMultiplier = 1f;

    private float fireTimer;

    private void Update()
    {
        if (!GameManager.Instance.IsPlaying) return;

        fireTimer -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && fireTimer <= 0f)
        {
            Fire();
            float interval = rapidFire ? 0.12f : baseFireInterval;
            fireTimer = interval;
        }
    }

    private void Fire()
    {
        if (bulletPrefab == null || firePoint == null) return;

        if (tripleShot)
        {
            SpawnBullet(firePoint.position, firePoint.rotation);
            SpawnBullet(firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, tripleAngle));
            SpawnBullet(firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, -tripleAngle));
        }
        else
        {
            SpawnBullet(firePoint.position, firePoint.rotation);
        }

        AudioManager.Instance?.PlayShoot();
    }

    private void SpawnBullet(Vector3 pos, Quaternion rot)
    {
        GameObject b = Instantiate(bulletPrefab, pos, rot);
        Bullet bullet = b.GetComponent<Bullet>();
        if (bullet != null)
            bullet.damage = laserDamageMultiplier;
    }
}
