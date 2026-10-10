
using UnityEngine;

public class Sword : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Enemy"))
            return;

        Stalfos stalfos = other.GetComponent<Stalfos>();
        if (stalfos != null)
        {
            stalfos.TakeDamage(1, transform.root.position);
            return;
        }

        Keese keese = other.GetComponent<Keese>();
        if (keese != null)
        {
            keese.TakeDamage(1, transform.root.position);
            return;
        }

        Goriya goriya = other.GetComponent<Goriya>();
        if (goriya != null)
        {
            goriya.TakeDamage(1, transform.root.position);
            return;
        }

        Gel gel = other.GetComponent<Gel>();
        if (gel != null)
        {
            gel.TakeDamage(1, transform.root.position);
            return;
        }

        Aquamentus aquamentus = other.GetComponent<Aquamentus>();
        if (aquamentus != null)
        {
            aquamentus.TakeDamage(1, transform.root.position);
            return;
        }
    }
}

