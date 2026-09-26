using UnityEngine;

public class Sword : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Stalfos stalfos = other.GetComponent<Stalfos>();

            if (stalfos != null)
            {
                stalfos.TakeDamage(1, transform.root.position);
            }
        }
    }
}
