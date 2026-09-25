using UnityEngine;

public class CheatCode : MonoBehaviour
{
    private PlayerHealth health;
    private Inventory inventory;
    private PlayerDamage damage;

    void Start()
    {
        health = GetComponent<PlayerHealth>();
        inventory = GetComponent<Inventory>();
        damage = GetComponent<PlayerDamage>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            health.MaxHealth();
            inventory.MaxRupees();
            damage.cheatInvincible = true;

            Debug.Log("CHEAT ACTIVATED");
        }
    }
}