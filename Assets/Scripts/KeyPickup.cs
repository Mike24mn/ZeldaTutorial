using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public AudioClip pickupSound;

    private void OnTriggerEnter(Collider other)
    {
        Inventory inventory = other.GetComponent<Inventory>();

        if (inventory != null)
        {
            inventory.AddKey();

            AudioSource.PlayClipAtPoint(
                pickupSound,
                Camera.main.transform.position
            );

            Destroy(gameObject);
        }
    }
}
