using UnityEngine;
using TMPro;

public class HealthDisplayer : MonoBehaviour
{
    public PlayerHealth playerHealth;
    private TMP_Text healthText;

    void Start()
    {
        healthText = GetComponent<TMP_Text>();
    }

    void Update()
    {
        if (playerHealth == null || healthText == null)
            return;

        if (playerHealth.currentHealth >= 5)
            healthText.text = "♥ ♥ ♥";
        else if (playerHealth.currentHealth >= 3)
            healthText.text = "♥ ♥";
        else if (playerHealth.currentHealth >= 1)
            healthText.text = "♥";
        else
            healthText.text = "";
    }
}