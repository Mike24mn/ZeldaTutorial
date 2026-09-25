using UnityEngine;

public class ArrowKeyMovement : MonoBehaviour
{
    public float movementSpeed = 5.0f;

    public Sprite downSprite1;
    public Sprite downSprite2;
    public Sprite rightSprite1;
    public Sprite rightSprite2;
    public Sprite upSprite1;
    public Sprite upSprite2;

    private Rigidbody rb;
    private SpriteRenderer spriteRenderer;

    private float animationTimer = 0f;
    private bool useSecondSprite = false;

    private Vector2 lastDirection = Vector2.down;
    private Vector3 movement;

    public bool controlsEnabled = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!controlsEnabled)
        {
            movement = Vector3.zero;
            return;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        movement = Vector3.zero;

        if (horizontal != 0)
        {
            float targetY = Mathf.Round(transform.position.y * 2f) / 2f;
            float difference = targetY - transform.position.y;

            if (Mathf.Abs(difference) > 0.05f)
            {
                movement.y = Mathf.Sign(difference);
            }
            else
            {
                Vector3 p = transform.position;
                p.y = targetY;
                transform.position = p;
                movement.x = horizontal;
            }

            lastDirection = horizontal > 0 ? Vector2.right : Vector2.left;
        }
        else if (vertical != 0)
        {
            float targetX = Mathf.Round(transform.position.x * 2f) / 2f;
            float difference = targetX - transform.position.x;

            if (Mathf.Abs(difference) > 0.05f)
            {
                movement.x = Mathf.Sign(difference);
            }
            else
            {
                Vector3 p = transform.position;
                p.x = targetX;
                transform.position = p;
                movement.y = vertical;
            }

            lastDirection = vertical > 0 ? Vector2.up : Vector2.down;
        }

        UpdateAnimation();
    }

    void FixedUpdate()
    {
        if (controlsEnabled)
        {
            rb.linearVelocity = movement * movementSpeed;
        }
    }

    void UpdateAnimation()
    {
        if (movement.y < 0)
        {
            spriteRenderer.flipX = false;
            Animate(downSprite1, downSprite2);
        }
        else if (movement.y > 0)
        {
            spriteRenderer.flipX = false;
            Animate(upSprite1, upSprite2);
        }
        else if (movement.x > 0)
        {
            spriteRenderer.flipX = false;
            Animate(rightSprite1, rightSprite2);
        }
        else if (movement.x < 0)
        {
            spriteRenderer.flipX = true;
            Animate(rightSprite1, rightSprite2);
        }
        else
        {
            SetIdleSprite();
        }
    }

    void Animate(Sprite sprite1, Sprite sprite2)
    {
        animationTimer += Time.deltaTime;

        if (animationTimer >= 0.15f)
        {
            useSecondSprite = !useSecondSprite;
            animationTimer = 0f;
        }

        spriteRenderer.sprite = useSecondSprite ? sprite2 : sprite1;
    }

    void SetIdleSprite()
    {
        animationTimer = 0f;
        useSecondSprite = false;

        if (lastDirection == Vector2.down)
        {
            spriteRenderer.flipX = false;
            spriteRenderer.sprite = downSprite1;
        }
        else if (lastDirection == Vector2.up)
        {
            spriteRenderer.flipX = false;
            spriteRenderer.sprite = upSprite1;
        }
        else if (lastDirection == Vector2.right)
        {
            spriteRenderer.flipX = false;
            spriteRenderer.sprite = rightSprite1;
        }
        else
        {
            spriteRenderer.flipX = true;
            spriteRenderer.sprite = rightSprite1;
        }
    }

    public Vector2 GetFacingDirection()
    {
        return lastDirection;
    }
}