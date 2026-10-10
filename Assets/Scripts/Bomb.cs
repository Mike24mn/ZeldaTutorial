
using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
    public float fuseTime = 2f;
    public float explosionRadius = 2.5f;
    public int damage = 2;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(fuseTime);

        transform.localScale *= 1.5f;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        if (sr != null)
            sr.color = new Color(1f, 0.4f, 0.1f);

        Collider[] hits = Physics.OverlapSphere(
            transform.position,
            explosionRadius
        );

        foreach (Collider hit in hits)
        {
            Stalfos stalfos = hit.GetComponent<Stalfos>();

            if (stalfos != null)
            {
                stalfos.TakeDamage(
                    damage,
                    transform.position
                );
            }

            Keese keese = hit.GetComponent<Keese>();

            if (keese != null)
            {
                keese.TakeDamage(
                    damage,
                    transform.position
                );
            }

            Goriya goriya = hit.GetComponent<Goriya>();

            if (goriya != null)
            {
                goriya.TakeDamage(
                    damage,
                    transform.position
                );
            }

            Gel gel = hit.GetComponent<Gel>();

            if (gel != null)
            {
                gel.TakeDamage(
                    damage,
                    transform.position
                );
            }

            Aquamentus aquamentus = hit.GetComponent<Aquamentus>();

            if (aquamentus != null)
            {
                aquamentus.TakeDamage(
                    damage,
                    transform.position
                );
            }
        }

        yield return new WaitForSeconds(0.2f);

        Destroy(gameObject);
    }
}

