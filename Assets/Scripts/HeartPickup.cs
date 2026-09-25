using UnityEngine;

public class HeartPickup : MonoBehaviour
{
    public int healAmount = 2;

    void OnTriggerEnter(Collider other)
    {
        PlayerHealth health = other.GetComponent<PlayerHealth>();

        if (health != null)
        {
            health.Heal(healAmount);
            Destroy(gameObject);
        }
    }
}