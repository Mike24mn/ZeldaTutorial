using UnityEngine;

public class SwordBeam : MonoBehaviour
{
    public float speed = 4f;
    public float lifetime = 2f;

    private Vector3 direction;

    public void SetDirection(Vector2 newDirection)
    {
        direction = new Vector3(newDirection.x, newDirection.y, 0f).normalized;
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
        if (other.CompareTag("Enemy"))
        {
            Stalfos stalfos = other.GetComponent<Stalfos>();

            if (stalfos != null)
            {
                stalfos.TakeDamage(1, transform.position);
            }

            Destroy(gameObject);
        }
    }
}
