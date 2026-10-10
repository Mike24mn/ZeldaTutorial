
using UnityEngine;

public class PushableBlock : MonoBehaviour
{
    public float pushDelay = 0.5f;
    public float pushDistance = 1f;
    public float pushSpeed = 3f;

    private float pushTimer = 0f;
    private bool moved = false;
    private bool moving = false;
    private Vector3 destination;

    private Rigidbody playerRb;
    private ArrowKeyMovement playerMovement;

    void OnCollisionStay(Collision collision)
    {
        if (moved || moving)
            return;

        ArrowKeyMovement player =
            collision.gameObject.GetComponentInParent<ArrowKeyMovement>();

        if (player == null)
            return;

        Vector2 input = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );

        if (input.sqrMagnitude < 0.1f)
        {
            pushTimer = 0f;
            return;
        }

        Vector2 towardBlock = new Vector2(
            transform.position.x - player.transform.position.x,
            transform.position.y - player.transform.position.y
        ).normalized;

        if (Vector2.Dot(input.normalized, towardBlock) < 0.8f)
        {
            pushTimer = 0f;
            return;
        }

        pushTimer += Time.fixedDeltaTime;

        if (pushTimer >= pushDelay)
        {
            destination = transform.position +
                new Vector3(
                    Mathf.Round(input.normalized.x),
                    Mathf.Round(input.normalized.y),
                    0f
                ) * pushDistance;

            moved = true;
            moving = true;
        }
    }

    void Update()
    {
        if (!moving)
            return;

        transform.position = Vector3.MoveTowards(
            transform.position,
            destination,
            pushSpeed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, destination) < 0.001f)
        {
            transform.position = destination;
            moving = false;
        }
    }
}
