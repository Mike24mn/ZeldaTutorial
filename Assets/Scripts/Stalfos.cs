using UnityEngine;

public class Stalfos : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float directionChangeTime = 1.5f;

    private Rigidbody rb;
    private Vector3 direction;
    private float timer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ChooseDirection();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            ChooseDirection();
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = direction * moveSpeed;
    }

    void OnCollisionEnter(Collision collision)
    {
        // If Stalfos hits something other than Player,
        // pick another direction.
        if (!collision.gameObject.CompareTag("Player"))
        {
            ChooseDirection();
        }
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

        timer = directionChangeTime;
    }
}