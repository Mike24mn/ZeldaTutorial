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

    // Remember the last direction Link was facing
    private Vector2 lastDirection = Vector2.down;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(horizontal) > Mathf.Abs(vertical))
        {
            vertical = 0;
        }
        else
        {
            horizontal = 0;
        }

        rb.linearVelocity = new Vector3(
            horizontal * movementSpeed,
            vertical * movementSpeed,
            0
        );

        if (vertical < 0)
        {
            lastDirection = Vector2.down;
            spriteRenderer.flipX = false;
            Animate(downSprite1, downSprite2);
        }
        else if (vertical > 0)
        {
            lastDirection = Vector2.up;
            spriteRenderer.flipX = false;
            Animate(upSprite1, upSprite2);
        }
        else if (horizontal > 0)
        {
            lastDirection = Vector2.right;
            spriteRenderer.flipX = false;
            Animate(rightSprite1, rightSprite2);
        }
        else if (horizontal < 0)
        {
            lastDirection = Vector2.left;
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
        else if (lastDirection == Vector2.left)
        {
            spriteRenderer.flipX = true;
            spriteRenderer.sprite = rightSprite1;
        }
    }
}