using UnityEngine;

public class Keese : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float directionChangeTime = 1f;
    public int maxHealth = 1;

    public float knockbackForce = 4f;
    public float knockbackTime = 0.2f;

    private int currentHealth;
    private Rigidbody rb;
    private Vector3 direction;
    private float timer;

    private bool isKnockedBack = false;
    private float knockbackTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
        ChooseDirection();
    }

    void Update()
    {
        if (isKnockedBack)
        {
            knockbackTimer -= Time.deltaTime;

            if (knockbackTimer <= 0f)
            {
                isKnockedBack = false;
                ChooseDirection();
            }

            return;
        }

        timer -= Time.deltaTime;

        if (timer <= 0f)
            ChooseDirection();
    }

    void FixedUpdate()
    {
        if (!isKnockedBack)
            rb.linearVelocity = direction * moveSpeed;
    }

    void OnCollisionEnter(Collision collision)
    {
        ChooseDirection();
    }

    public void TakeDamage(int damage, Vector3 attackerPosition)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 knockbackDirection =
            (transform.position - attackerPosition).normalized;

        knockbackDirection.z = 0f;

        rb.linearVelocity = knockbackDirection * knockbackForce;

        isKnockedBack = true;
        knockbackTimer = knockbackTime;
    }

    void ChooseDirection()
    {
        // Keese can fly diagonally unlike Stalfos
        direction = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            0f
        ).normalized;

        timer = directionChangeTime;
    }
}