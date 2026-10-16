using UnityEngine;

/// <summary>
/// Star Crystal collectible.
/// Floats, rotates, glows. Magnetic pickup within radius.
/// Gives score + combo. Counts toward mission objectives.
/// </summary>
public class StarPickup : MonoBehaviour
{
    [Header("Crystal Settings")]
    public float magnetRadius = 3f;
    public float attractSpeed = 8f;

    [Header("Float Animation")]
    public float floatAmplitude = 0.2f;
    public float floatFrequency = 1.2f;
    public float rotateSpeed = 90f;

    private Transform player;
    private Vector3 startPos;
    private PlayerController playerController;

    private void Start()
    {
        startPos = transform.position;
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null)
        {
            player = p.transform;
            playerController = p.GetComponent<PlayerController>();
        }
    }

    private void Update()
    {
        // Float animation
        float y = startPos.y + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        transform.position = new Vector3(transform.position.x, y, transform.position.z);

        // Rotate
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);

        // Magnetic attraction
        if (player == null) return;

        float dist = Vector2.Distance(transform.position, player.position);

        // Check if Magnet power-up is active
        float effectiveRadius = magnetRadius;
        PowerUpManager pum = playerController != null ? playerController.GetComponent<PowerUpManager>() : null;
        if (pum != null && pum.MagnetActive)
            effectiveRadius = magnetRadius * 3f;

        if (dist <= effectiveRadius)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                player.position,
                attractSpeed * Time.deltaTime
            );
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        ScoreManager.Instance?.AddCrystalScore();
        MissionManager.Instance?.OnCrystalCollected();
        VFXManager.Instance?.PlayPickup(transform.position);
        AudioManager.Instance?.PlayPickup();
        Destroy(gameObject);
    }
}
