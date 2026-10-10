
using UnityEngine;

public class Wallmaster : MonoBehaviour
{
    public float moveSpeed = 1.5f;
    public float detectionRange = 5f;
    public float returnSpeed = 2f;
    public float respawnDelay = 3f;
    public Transform dungeonEntrance;

    private Transform player;
    private Rigidbody rb;
    private Vector3 startPosition;
    private float timer;
    private bool active = true;
    private bool returning = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
            player = playerObject.transform;
    }

    void FixedUpdate()
    {
        if (player == null || !active)
        {
            rb.linearVelocity = Vector3.zero;
            return;
        }

        if (returning)
        {
            Vector3 direction = startPosition - transform.position;
            direction.z = 0f;

            if (direction.magnitude < 0.1f)
            {
                rb.position = startPosition;
                rb.linearVelocity = Vector3.zero;
                returning = false;
                active = false;
                timer = respawnDelay;
            }
            else
            {
                rb.linearVelocity = direction.normalized * returnSpeed;
            }

            return;
        }

        Vector3 toPlayer = player.position - transform.position;
        toPlayer.z = 0f;

        if (toPlayer.magnitude <= detectionRange)
        {
            rb.linearVelocity = toPlayer.normalized * moveSpeed;
        }
        else
        {
            rb.linearVelocity = Vector3.zero;
        }

        if (Vector3.Distance(startPosition, transform.position) > detectionRange)
        {
            returning = true;
        }
    }

    void Update()
    {
        if (!active)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
                active = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (dungeonEntrance == null)
            return;

        Rigidbody playerRb = other.GetComponent<Rigidbody>();

        if (playerRb != null)
        {
            playerRb.linearVelocity = Vector3.zero;
            playerRb.position = dungeonEntrance.position;
        }
        else
        {
            other.transform.position = dungeonEntrance.position;
        }

        rb.position = startPosition;
        rb.linearVelocity = Vector3.zero;
        returning = false;
        active = false;
        timer = respawnDelay;
    }
}

