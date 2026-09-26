using UnityEngine;

public class Stalfos : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float directionChangeTime = 1.5f;

    // Health
    public int maxHealth = 2;

    // Knockback
    public float knockbackForce = 4f;
    public float knockbackTime = 0.2f;

    // Drops
    public GameObject rupeePrefab;
    public GameObject heartPrefab;

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

            if (knockbackTimer <= 0)
            {
                isKnockedBack = false;
                ChooseDirection();
            }

            return;
        }

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            ChooseDirection();
        }
    }

    void FixedUpdate()
    {
        if (!isKnockedBack)
        {
            rb.linearVelocity = direction * moveSpeed;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            ChooseDirection();
        }
    }

    public void TakeDamage(int damage, Vector3 attackerPosition)
    {
        currentHealth -= damage;

        Debug.Log("Stalfos HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            DropItem();
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

    void DropItem()
    {
        int drop = Random.Range(0, 3);

        if (drop == 0 && rupeePrefab != null)
        {
            Instantiate(rupeePrefab, transform.position, Quaternion.identity);
        }
        else if (drop == 1 && heartPrefab != null)
        {
            Instantiate(heartPrefab, transform.position, Quaternion.identity);
        }
        // drop == 2: nothing drops
    }

    void ChooseDirection()
    {
        int choice = Random.Range(0, 4);

        if (choice == 0)
            direction = Vector3.up;
        else if (choice == 1)
            direction = Vector3.down;
        else if (choice == 2)
            direction = Vector3.left;
        else
            direction = Vector3.right;

        timer = directionChangeTime;
    }
}