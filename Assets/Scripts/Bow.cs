using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject arrowPrefab;
    public GameObject boomerangPrefab;
    public GameObject bombPrefab;

    private Inventory inventory;
    private ArrowKeyMovement movement;

    // 0 = Bow, 1 = Boomerang, 2 = Bomb
    private int selectedWeapon = 0;

    void Start()
    {
        inventory = GetComponent<Inventory>();
        movement = GetComponent<ArrowKeyMovement>();
    }

    void Update()
    {
        // Cycle alternate weapons
        if (Input.GetKeyDown(KeyCode.Space))
        {
            selectedWeapon = (selectedWeapon + 1) % 3;

            if (selectedWeapon == 0)
                Debug.Log("Selected: Bow");
            else if (selectedWeapon == 1)
                Debug.Log("Selected: Boomerang");
            else
                Debug.Log("Selected: Bomb");
        }

        // Use selected alternate weapon
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (selectedWeapon == 0)
                ShootBow();
            else if (selectedWeapon == 1)
                ThrowBoomerang();
            else
                PlaceBomb();
        }
    }

    void ShootBow()
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

    void ThrowBoomerang()
    {
        Vector2 direction = movement.GetFacingDirection();

        Vector3 spawnPosition = transform.position +
            new Vector3(direction.x * 0.6f, direction.y * 0.6f, 0f);

        GameObject boomerangObject = Instantiate(
            boomerangPrefab,
            spawnPosition,
            Quaternion.identity
        );

        Boomerang boomerang = boomerangObject.GetComponent<Boomerang>();

        boomerang.Launch(
            transform,
            new Vector3(direction.x, direction.y, 0f)
        );
    }

    void PlaceBomb()
    {
        Instantiate(
            bombPrefab,
            transform.position,
            Quaternion.identity
        );
    }
}