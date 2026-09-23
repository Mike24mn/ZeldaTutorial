using System.Collections;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public GameObject sword;
    public GameObject swordBeamPrefab;

    public Sprite downSword;
    public Sprite leftSword;
    public Sprite upSword;
    public Sprite rightSword;

    public float attackTime = 0.2f;
    public float beamCooldown = 0.8f;

    private ArrowKeyMovement movement;
    private PlayerHealth health;
    private SpriteRenderer swordRenderer;
    private bool attacking = false;
    private float lastBeamTime = -999f;

    void Start()
    {
        movement = GetComponent<ArrowKeyMovement>();
        health = GetComponent<PlayerHealth>();
        swordRenderer = sword.GetComponent<SpriteRenderer>();
        sword.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && !attacking)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        attacking = true;

        Vector2 direction = movement.GetFacingDirection();

        if (direction == Vector2.down)
        {
            swordRenderer.sprite = downSword;
            sword.transform.position = transform.position + new Vector3(0f, -0.55f, 0f);
        }
        else if (direction == Vector2.left)
        {
            swordRenderer.sprite = leftSword;
            sword.transform.position = transform.position + new Vector3(-0.55f, 0f, 0f);
        }
        else if (direction == Vector2.up)
        {
            swordRenderer.sprite = upSword;
            sword.transform.position = transform.position + new Vector3(0f, 0.55f, 0f);
        }
        else
        {
            swordRenderer.sprite = rightSword;
            sword.transform.position = transform.position + new Vector3(0.55f, 0f, 0f);
        }

        sword.SetActive(true);

        if (health != null &&
            health.IsFullHealth() &&
            swordBeamPrefab != null &&
            Time.time >= lastBeamTime + beamCooldown)
        {
            ShootBeam(direction);
            lastBeamTime = Time.time;
        }

        yield return new WaitForSeconds(attackTime);

        sword.SetActive(false);
        attacking = false;
    }

    void ShootBeam(Vector2 direction)
    {
        Vector3 spawnPosition = transform.position + new Vector3(
            direction.x * 0.8f,
            direction.y * 0.8f,
            0f
        );

        GameObject beam = Instantiate(
            swordBeamPrefab,
            spawnPosition,
            Quaternion.identity
        );

        SwordBeam beamScript = beam.GetComponent<SwordBeam>();

        if (beamScript != null)
        {
            beamScript.SetDirection(direction);
        }

        if (direction == Vector2.up)
        {
            beam.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }
        else if (direction == Vector2.down)
        {
            beam.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
        }
        else if (direction == Vector2.left)
        {
            beam.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
        }
    }
}