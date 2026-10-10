using UnityEngine;

public class StaircaseTeleport : MonoBehaviour
{
    public Transform destination;

    private void OnTriggerEnter(Collider other)
    {
        if (destination == null)
            return;

        ArrowKeyMovement player = other.GetComponentInParent<ArrowKeyMovement>();

        if (player == null)
            return;

        player.transform.position = destination.position;
    }
}