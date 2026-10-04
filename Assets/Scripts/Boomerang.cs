using UnityEngine;

public class Boomerang : MonoBehaviour
{
    public float speed = 6f;
    public float maxDistance = 4f;
    public float spinSpeed = 720f;
    public int damage = 1;

    private Transform player;
    private Vector3 direction;
    private Vector3 startPosition;
    private bool returning = false;

    public void Launch(Transform playerTransform, Vector3 launchDirection)
    {
        player = playerTransform;
        direction = launchDirection.normalized;
        startPosition = transform.position;
    }

    void Update()
    {
        transform.Rotate(0f, 0f, spinSpeed * Time.deltaTime);

        if (!returning)
        {
            transform.position += direction * speed * Time.deltaTime;

            if (Vector3.Distance(startPosition, transform.position) >= maxDistance)
                returning = true;
        }
        else
        {
            if (player == null)
            {
                Destroy(gameObject);
                return;
            }

            transform.position = Vector3.MoveTowards(
                transform.position,
                player.position,
                speed * Time.deltaTime
            );

            if (Vector3.Distance(transform.position, player.position) < 0.3f)
                Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Enemy"))
            return;

        Stalfos stalfos = other.GetComponent<Stalfos>();
        if (stalfos != null)
            stalfos.TakeDamage(damage, transform.position);

        Keese keese = other.GetComponent<Keese>();
        if (keese != null)
            keese.TakeDamage(damage, transform.position);

        returning = true;
    }
}