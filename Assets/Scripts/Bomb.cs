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

        // Damage nearby enemies
        Collider[] hits = Physics.OverlapSphere(
            transform.position,
            explosionRadius
        );

        foreach (Collider hit in hits)
        {
            Stalfos enemy = hit.GetComponent<Stalfos>();

            if (enemy != null)
            {
                enemy.TakeDamage(
                    damage,
                    transform.position
                );
            }
        }

        yield return new WaitForSeconds(0.2f);

        Destroy(gameObject);
    }
}