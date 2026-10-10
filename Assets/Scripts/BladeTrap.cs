
using UnityEngine;

public class BladeTrap : MonoBehaviour
{
    public float detectionRange = 5f;
    public float alignmentTolerance = 0.35f;
    public float attackSpeed = 6f;
    public float returnSpeed = 2f;
    public float maxTravelDistance = 3f;
    public float cooldown = 0.5f;

    private Transform player;
    private Rigidbody rb;
    private Vector3 startPosition;
    private Vector3 attackDirection;
    private float cooldownTimer;

    private enum TrapState
    {
        Waiting,
        Attacking,
        Returning
    }

    private TrapState state = TrapState.Waiting;

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
        if (player == null)
        {
            rb.linearVelocity = Vector3.zero;
            return;
        }

        switch (state)
        {
            case TrapState.Waiting:
                rb.linearVelocity = Vector3.zero;

                if (cooldownTimer > 0f)
                {
                    cooldownTimer -= Time.fixedDeltaTime;
                    return;
                }

                DetectPlayer();
                break;

            case TrapState.Attacking:
                rb.linearVelocity = attackDirection * attackSpeed;

                if (Vector3.Distance(startPosition, transform.position)
                    >= maxTravelDistance)
                {
                    StartReturning();
                }
                break;

            case TrapState.Returning:
                Vector3 toStart = startPosition - transform.position;
                toStart.z = 0f;

                if (toStart.magnitude < 0.08f)
                {
                    rb.position = startPosition;
                    rb.linearVelocity = Vector3.zero;
                    cooldownTimer = cooldown;
                    state = TrapState.Waiting;
                }
                else
                {
                    rb.linearVelocity = toStart.normalized * returnSpeed;
                }
                break;
        }
    }

    void DetectPlayer()
    {
        Vector3 difference = player.position - transform.position;
        difference.z = 0f;

        if (difference.magnitude > detectionRange)
            return;

        if (Mathf.Abs(difference.x) < alignmentTolerance)
        {
            attackDirection = difference.y > 0f
                ? Vector3.up : Vector3.down;

            state = TrapState.Attacking;
        }
        else if (Mathf.Abs(difference.y) < alignmentTolerance)
        {
            attackDirection = difference.x > 0f
                ? Vector3.right : Vector3.left;

            state = TrapState.Attacking;
        }
    }

    void StartReturning()
    {
        rb.linearVelocity = Vector3.zero;
        state = TrapState.Returning;
    }

    void OnCollisionEnter(Collision collision)
    {
    if (state != TrapState.Attacking)
        return;

    StartReturning();
    }
}
