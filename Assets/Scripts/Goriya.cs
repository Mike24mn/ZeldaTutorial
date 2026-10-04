using UnityEngine;

public class Goriya : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float directionChangeTime = 1.5f;
    public int maxHealth = 2;

    public float knockbackForce = 4f;
    public float knockbackTime = 0.2f;

    // Directional sprites
    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;

    // Boomerang
    public GameObject boomerangPrefab;
    public float throwInterval = 2.5f;

    private int currentHealth;
    private Rigidbody rb;
    private SpriteRenderer spriteRenderer;

    private Vector3 direction;
    private float directionTimer;
    private float throwTimer;

    private bool isKnockedBack = false;
    private float knockbackTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        currentHealth = maxHealth;

        ChooseDirection();

        throwTimer = throwInterval;
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

        directionTimer -= Time.deltaTime;

        if (directionTimer <= 0f)
            ChooseDirection();

        throwTimer -= Time.deltaTime;

        if (throwTimer <= 0f)
        {
            ThrowBoomerang();
            throwTimer = throwInterval;
        }
    }

    void FixedUpdate()
    {
        if (!isKnockedBack)
            rb.linearVelocity = direction * moveSpeed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!isKnockedBack)
            ChooseDirection();
    }

    void ChooseDirection()
    {
        int choice = Random.Range(0, 4);

        spriteRenderer.flipX = false;

        if (choice == 0)
        {
            direction = Vector3.up;
            spriteRenderer.sprite = upSprite;
        }
        else if (choice == 1)
        {
            direction = Vector3.down;
            spriteRenderer.sprite = downSprite;
        }
        else if (choice == 2)
        {
            direction = Vector3.left;

            // Goriya only needs one horizontal sprite.
            // Flip the right-facing sprite for left movement.
            spriteRenderer.sprite = rightSprite;
            spriteRenderer.flipX = true;
        }
        else
        {
            direction = Vector3.right;
            spriteRenderer.sprite = rightSprite;
        }

        directionTimer = directionChangeTime;
    }

    void ThrowBoomerang()
    {
        if (boomerangPrefab == null)
            return;

        Vector3 spawnPosition =
            transform.position + direction * 0.6f;

        GameObject boomerangObject = Instantiate(
            boomerangPrefab,
            spawnPosition,
            Quaternion.identity
        );

        GoriyaBoomerang boomerang =
            boomerangObject.GetComponent<GoriyaBoomerang>();

        if (boomerang != null)
            boomerang.Launch(transform, direction);
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

        rb.linearVelocity =
            knockbackDirection * knockbackForce;

        isKnockedBack = true;
        knockbackTimer = knockbackTime;
    }
}