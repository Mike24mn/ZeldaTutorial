
using UnityEngine;

public class Aquamentus : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    public float moveDistance = 0.6f;
    public float fireInterval = 2.5f;
    public float projectileSpeed = 3f;
    public GameObject fireballPrefab;
    public int maxHealth = 6;
    public float invincibilityTime = 0.3f;

    private Rigidbody rb;
    private Transform player;
    private SpriteRenderer spriteRenderer;
    private Vector3 startPosition;
    private float fireTimer;
    private float moveDirection = 1f;
    private int currentHealth;
    private float damageTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        startPosition = transform.position;
        currentHealth = maxHealth;

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
            player = playerObject.transform;
    }

    void FixedUpdate()
    {
        float offset = transform.position.y - startPosition.y;

        if (offset >= moveDistance)
            moveDirection = -1f;
        else if (offset <= -moveDistance)
            moveDirection = 1f;

        rb.linearVelocity = Vector3.up * moveDirection * moveSpeed;
    }

    void Update()
    {
        if (damageTimer > 0f)
            damageTimer -= Time.deltaTime;

        if (player == null || fireballPrefab == null)
            return;

        Vector3 difference = player.position - transform.position;
        difference.z = 0f;

        if (Mathf.Abs(difference.x) > 5f ||
            Mathf.Abs(difference.y) > 3.5f)
        {
            fireTimer = 0f;
            return;
        }

        fireTimer += Time.deltaTime;

        if (fireTimer >= fireInterval)
        {
            fireTimer = 0f;
            FireProjectiles();
        }
    }

    void FireProjectiles()
    {
        Vector3 direction = player.position - transform.position;
        direction.z = 0f;
        direction.Normalize();

        float[] angles = { -20f, 0f, 20f };

        foreach (float angle in angles)
        {
            Vector3 shotDirection =
                Quaternion.Euler(0f, 0f, angle) * direction;

            GameObject projectile = Instantiate(
                fireballPrefab,
                transform.position + shotDirection * 0.5f,
                Quaternion.identity
            );

            Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

            if (projectileRb != null)
                projectileRb.linearVelocity =
                    shotDirection * projectileSpeed;
        }
    }

    public void TakeDamage(int damage, Vector3 attackerPosition)
    {
        if (damageTimer > 0f)
            return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            return;
        }

        damageTimer = invincibilityTime;
    }
}


