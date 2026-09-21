using UnityEngine;

public class Collector : MonoBehaviour
{
    private Inventory inventory;

    public AudioClip rupeeSound;

    void Start()
    {
        inventory = GetComponent<Inventory>();

        if (inventory == null)
        {
            Debug.LogWarning("Collector requires an Inventory component!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("rupee"))
        {
            if (inventory != null)
            {
                inventory.AddRupee();
                Debug.Log("Rupees: " + inventory.GetRupees());
            }

            AudioSource.PlayClipAtPoint(
                rupeeSound,
                Camera.main.transform.position
            );

            Destroy(other.gameObject);
        }
    }
}