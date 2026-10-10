
using UnityEngine;

public class AquamentusFireball : MonoBehaviour
{
    public float lifetime = 4f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        else if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}

