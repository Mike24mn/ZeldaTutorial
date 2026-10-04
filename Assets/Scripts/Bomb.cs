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

        // Explosion visual
        transform.localScale *= 1.5f;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        if (sr != null)
            sr.color = new Color(1f, 0.4f, 0.1f);

        // Find everything inside explosion radius
        Collider[] hits = Physics.OverlapSphere(
            transform.position,
            explosionRadius
        );

        foreach (Collider hit in hits)
        {
            // Damage Stalfos
            Stalfos stalfos = hit.GetComponent<Stalfos>();

            if (stalfos != null)
            {
                stalfos.TakeDamage(
                    damage,
                    transform.position
                );
            }

            // Damage Keese
            Keese keese = hit.GetComponent<Keese>();

            if (keese != null)
            {
                keese.TakeDamage(
                    damage,
                    transform.position
                );
            }
        }

        // Keep explosion visible briefly
        yield return new WaitForSeconds(0.2f);

        Destroy(gameObject);
    }
}