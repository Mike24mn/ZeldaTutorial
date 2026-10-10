using UnityEngine;

public class BowPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Bow bow = other.GetComponentInParent<Bow>();

        if (bow == null)
            return;

        bow.UnlockBow();
        Destroy(gameObject);
    }
}