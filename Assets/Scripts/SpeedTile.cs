using UnityEngine;

public class SpeedTile : MonoBehaviour
{
    public float speedMultiplier = 2f;

    private void OnTriggerEnter(Collider other)
    {
        ArrowKeyMovement player = other.GetComponentInParent<ArrowKeyMovement>();

        if (player != null)
            player.movementSpeed = player.normalMovementSpeed * speedMultiplier;
    }

    private void OnTriggerExit(Collider other)
    {
        ArrowKeyMovement player = other.GetComponentInParent<ArrowKeyMovement>();

        if (player != null)
            player.movementSpeed = player.normalMovementSpeed;
    }
}