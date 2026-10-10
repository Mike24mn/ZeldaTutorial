
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 8f;
    public float lifetime = 2f;

    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;

    private Vector3 direction;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetDirection(Vector2 newDirection)
    {
        direction = new Vector3(newDirection.x, newDirection.y, 0f).normalized;

        if (newDirection == Vector2.up)
            spriteRenderer.sprite = upSprite;
        else if (newDirection == Vector2.down)
            spriteRenderer.sprite = downSprite;
        else if (newDirection == Vector2.left)
            spriteRenderer.sprite = leftSprite;
        else
            spriteRenderer.sprite = rightSprite;
    }

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Enemy"))
            return;

        Stalfos stalfos = other.GetComponent<Stalfos>();
        if (stalfos != null)
            stalfos.TakeDamage(1, transform.position);

        Keese keese = other.GetComponent<Keese>();
        if (keese != null)
            keese.TakeDamage(1, transform.position);

        Goriya goriya = other.GetComponent<Goriya>();
        if (goriya != null)
            goriya.TakeDamage(1, transform.position);

        Gel gel = other.GetComponent<Gel>();
        if (gel != null)
            gel.TakeDamage(1, transform.position);

        Aquamentus aquamentus = other.GetComponent<Aquamentus>();
        if (aquamentus != null)
            aquamentus.TakeDamage(1, transform.position);

        Destroy(gameObject);
    }
}

