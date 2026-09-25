using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject arrowPrefab;

    private Inventory inventory;
    private ArrowKeyMovement movement;

    void Start()
    {
        inventory = GetComponent<Inventory>();
        movement = GetComponent<ArrowKeyMovement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (!inventory.SpendRupee())
        {
            Debug.Log("No rupees!");
            return;
        }

        Vector2 direction = movement.GetFacingDirection();

        Vector3 spawnPosition = transform.position +
            new Vector3(direction.x * 0.6f, direction.y * 0.6f, 0f);

        GameObject arrowObject = Instantiate(
            arrowPrefab,
            spawnPosition,
            Quaternion.identity
        );

        Arrow arrow = arrowObject.GetComponent<Arrow>();
        arrow.SetDirection(direction);
    }
}