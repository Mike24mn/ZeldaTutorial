using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    public Image swordIcon;
    public Image bowIcon;

    void Start()
    {
        UpdateUI();
    }

    void Update()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        // X = sword, Z = bow in our current controls.
        // Keep both visible; highlight them when their key is being used.

        swordIcon.color = Input.GetKey(KeyCode.X)
            ? Color.white
            : new Color(1f, 1f, 1f, 0.4f);

        bowIcon.color = Input.GetKey(KeyCode.Z)
            ? Color.white
            : new Color(1f, 1f, 1f, 0.4f);
    }
}