using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Inventory inventory = collision.gameObject.GetComponent<Inventory>();

        if (inventory == null)
            return;

        if (inventory.SpendKey())
        {
            Debug.Log("Door unlocked!");
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Door is locked. Need a key.");
        }
    }
}
