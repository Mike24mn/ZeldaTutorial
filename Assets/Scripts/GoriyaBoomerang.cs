using UnityEngine;

public class GoriyaBoomerang : MonoBehaviour
{
    public float speed = 5f;
    public float maxDistance = 3f;
    public float spinSpeed = 720f;
    public float hitRadius = 0.35f;

    private Transform owner;
    private Vector3 direction;
    private Vector3 startPosition;
    private bool returning = false;

    public void Launch(Transform goriya, Vector3 launchDirection)
    {
        owner = goriya;
        direction = launchDirection.normalized;
        startPosition = transform.position;

        // Ignore physical collisions with ALL enemies
        Collider myCollider = GetComponent<Collider>();

        if (myCollider != null)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject enemy in enemies)
            {
                Collider enemyCollider = enemy.GetComponent<Collider>();

                if (enemyCollider != null)
                    Physics.IgnoreCollision(myCollider, enemyCollider);
            }
        }
    }

    void Update()
    {
        // Spin
        transform.Rotate(0f, 0f, spinSpeed * Time.deltaTime);

        // Fly outward
        if (!returning)
        {
            transform.position += direction * speed * Time.deltaTime;

            if (Vector3.Distance(startPosition, transform.position) >= maxDistance)
                returning = true;
        }
        else
        {
            // Return to Goriya
            if (owner == null)
            {
                Destroy(gameObject);
                return;
            }

            transform.position = Vector3.MoveTowards(
                transform.position,
                owner.position,
                speed * Time.deltaTime
            );

            if (Vector3.Distance(transform.position, owner.position) < 0.3f)
            {
                Destroy(gameObject);
                return;
            }
        }

        // Only search for Link
        Collider[] hits = Physics.OverlapSphere(
            transform.position,
            hitRadius
        );

        foreach (Collider hit in hits)
        {
            if (!hit.CompareTag("Player"))
                continue;

            PlayerHealth health = hit.GetComponent<PlayerHealth>();

            if (health != null)
                health.TakeDamage(1);

            returning = true;
            break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Goriya boomerangs ONLY damage Link
        if (!other.CompareTag("Player"))
            return;

        PlayerHealth health = other.GetComponent<PlayerHealth>();

        if (health != null)
            health.TakeDamage(1);

        returning = true;
    }
}