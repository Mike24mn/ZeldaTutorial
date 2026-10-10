
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
        if (!other.CompareTag("Enemy"))
            return;

        Vector3 attackerPosition = transform.position;

        Stalfos stalfos = other.GetComponent<Stalfos>();
        if (stalfos != null)
        {
            stalfos.TakeDamage(1, attackerPosition);
            Destroy(gameObject);
            return;
        }

        Keese keese = other.GetComponent<Keese>();
        if (keese != null)
        {
            keese.TakeDamage(1, attackerPosition);
            Destroy(gameObject);
            return;
        }

        Goriya goriya = other.GetComponent<Goriya>();
        if (goriya != null)
        {
            goriya.TakeDamage(1, attackerPosition);
            Destroy(gameObject);
            return;
        }

        Gel gel = other.GetComponent<Gel>();
        if (gel != null)
        {
            gel.TakeDamage(1, attackerPosition);
            Destroy(gameObject);
            return;
        }

        Aquamentus aquamentus = other.GetComponent<Aquamentus>();
        if (aquamentus != null)
        {
            aquamentus.TakeDamage(1, attackerPosition);
            Destroy(gameObject);
        }
    }
}

