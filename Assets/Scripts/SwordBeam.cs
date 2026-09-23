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
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
