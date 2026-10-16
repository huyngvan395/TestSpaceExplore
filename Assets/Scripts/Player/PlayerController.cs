using UnityEngine;

/// <summary>
/// Controls Aurora spaceship movement.
/// WASD / Arrow keys = 4-direction flight.
/// SHIFT = boost (consumes energy).
/// Rigidbody2D physics with smooth acceleration/deceleration.
/// Subtle horizontal banking for feel.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerEnergy))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float baseSpeed = 8f;
    public float acceleration = 20f;
    public float deceleration = 15f;

    [Header("Boost")]
    public float boostMultiplier = 1.8f;
    public float boostEnergyPerSecond = 25f;

    [Header("Banking")]
    public float maxBankAngle = 18f;
    public float bankSpeed = 8f;

    [Header("World Bounds (set by WorldBounds or SceneSetup)")]
    public float minX = -25f;
    public float maxX = 25f;
    public float minY = -18f;
    public float maxY = 18f;

    // Runtime state
    public Vector2 MoveInput { get; private set; }
    public bool IsBoosting { get; private set; }
    public float CurrentSpeed { get; private set; }

    private Rigidbody2D rb;
    private PlayerEnergy energy;
    private Vector2 velocity;
    private float currentBankAngle;

    // Power-up modifiers (set externally)
    [HideInInspector] public float speedMultiplier = 1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        energy = GetComponent<PlayerEnergy>();

        // Configure Rigidbody2D for top-down 2D space
        rb.gravityScale = 0f;
        rb.linearDamping = 0f;
        rb.angularDamping = 5f;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    private void Update()
    {
        if (!GameManager.Instance.IsPlaying) return;

        ReadInput();
        HandleBanking();
    }

    private void FixedUpdate()
    {
        if (!GameManager.Instance.IsPlaying)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        ApplyMovement();
        ClampToBounds();
    }

    private void ReadInput()
    {
        float h = 0f, v = 0f;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))  h -= 1f;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) h += 1f;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))  v -= 1f;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))    v += 1f;

        MoveInput = new Vector2(h, v);
        if (MoveInput.sqrMagnitude > 1f) MoveInput = MoveInput.normalized;

        // Boost
        IsBoosting = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        if (IsBoosting && !energy.HasEnergy())
            IsBoosting = false;
    }

    private void ApplyMovement()
    {
        float topSpeed = baseSpeed * speedMultiplier;
        if (IsBoosting)
        {
            topSpeed *= boostMultiplier;
            energy.ConsumeEnergy(boostEnergyPerSecond * Time.fixedDeltaTime);
        }

        if (MoveInput.sqrMagnitude > 0.01f)
        {
            velocity = Vector2.MoveTowards(velocity, MoveInput * topSpeed, acceleration * Time.fixedDeltaTime);
        }
        else
        {
            velocity = Vector2.MoveTowards(velocity, Vector2.zero, deceleration * Time.fixedDeltaTime);
        }

        CurrentSpeed = velocity.magnitude;
        rb.linearVelocity = velocity;
    }

    private void HandleBanking()
    {
        // Subtle bank (tilt) when moving horizontally — purely visual
        float targetBank = -MoveInput.x * maxBankAngle;
        currentBankAngle = Mathf.Lerp(currentBankAngle, targetBank, bankSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0f, 0f, currentBankAngle);
    }

    private void ClampToBounds()
    {
        Vector2 pos = rb.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        rb.position = pos;

        // Stop velocity at boundary
        if (pos.x <= minX || pos.x >= maxX) velocity.x = 0f;
        if (pos.y <= minY || pos.y >= maxY) velocity.y = 0f;
    }

    /// <summary>Called by WorldBounds to set world limits at runtime.</summary>
    public void SetBounds(float xMin, float xMax, float yMin, float yMax)
    {
        minX = xMin; maxX = xMax;
        minY = yMin; maxY = yMax;
    }
}
