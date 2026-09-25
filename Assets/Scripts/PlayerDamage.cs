using System.Collections;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public float invincibilityTime = 1.0f;
    public float knockbackForce = 4.0f;
    public float hitStunTime = 0.25f;

    // Cheat code sets this to true
    public bool cheatInvincible = false;

    private PlayerHealth health;
    private SpriteRenderer spriteRenderer;
    private Rigidbody rb;
    private ArrowKeyMovement movement;

    private bool invincible = false;

    void Start()
    {
        health = GetComponent<PlayerHealth>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody>();
        movement = GetComponent<ArrowKeyMovement>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")
            && !invincible
            && !cheatInvincible)
        {
            Vector3 direction =
                (transform.position - collision.transform.position).normalized;

            TakeHit(direction);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")
            && !invincible
            && !cheatInvincible)
        {
            Vector3 direction =
                (transform.position - other.transform.position).normalized;

            TakeHit(direction);
        }
    }

    void TakeHit(Vector3 direction)
    {
        health.TakeDamage(2);

        movement.controlsEnabled = false;

        direction.z = 0f;
        direction.Normalize();

        rb.linearVelocity = direction * knockbackForce;

        StartCoroutine(HitStun());
        StartCoroutine(Invincibility());
    }

    IEnumerator HitStun()
    {
        yield return new WaitForSeconds(hitStunTime);

        rb.linearVelocity = Vector3.zero;
        movement.controlsEnabled = true;
    }

    IEnumerator Invincibility()
    {
        invincible = true;

        float elapsed = 0f;

        while (elapsed < invincibilityTime)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;

            yield return new WaitForSeconds(0.1f);

            elapsed += 0.1f;
        }

        spriteRenderer.enabled = true;
        invincible = false;
    }
}