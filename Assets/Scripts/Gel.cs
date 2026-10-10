
using UnityEngine;

public class Gel : MonoBehaviour
{
    public float moveSpeed = 1.5f;
    public float moveTime = 0.35f;
    public float pauseTime = 0.6f;

    public int maxHealth = 1;

    public float knockbackForce = 3f;
    public float knockbackTime = 0.15f;

    public GameObject rupeePrefab;
    public GameObject heartPrefab;

    private int currentHealth;
    private Rigidbody rb;
    private Vector3 direction;
    private float timer;

    private bool isMoving;
    private bool isKnockedBack;
    private float knockbackTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
        timer = pauseTime;
    }

    void Update()
    {
        if (isKnockedBack)
        {
            knockbackTimer -= Time.deltaTime;

            if (knockbackTimer <= 0f)
            {
                isKnockedBack = false;
                isMoving = false;
                timer = pauseTime;
            }
            return;
        }

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            if (isMoving)
            {
                isMoving = false;
                timer = pauseTime;
            }
            else
            {
                ChooseDirection();
                isMoving = true;
                timer = moveTime;
            }
        }
    }

    void FixedUpdate()
    {
        if (!isKnockedBack)
        {
            rb.linearVelocity = isMoving
                ? direction * moveSpeed
                : Vector3.zero;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            isMoving = false;
            timer = pauseTime;
            rb.linearVelocity = Vector3.zero;
        }
    }

    public void TakeDamage(int damage, Vector3 attackerPosition)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            DropItem();
            Destroy(gameObject);
            return;
        }

        Vector3 knockbackDirection =
            transform.position - attackerPosition;

        knockbackDirection.z = 0f;
        knockbackDirection.Normalize();

        rb.linearVelocity =
            knockbackDirection * knockbackForce;

        isKnockedBack = true;
        knockbackTimer = knockbackTime;
    }

    void DropItem()
    {
        int drop = Random.Range(0, 3);

        if (drop == 0 && rupeePrefab != null)
            Instantiate(rupeePrefab, transform.position,
                Quaternion.identity);
        else if (drop == 1 && heartPrefab != null)
            Instantiate(heartPrefab, transform.position,
                Quaternion.identity);
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
    }
}

