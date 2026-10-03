using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    public Image swordIcon;
    public Image bowIcon;

    public Sprite bowSprite;
    public Sprite boomerangSprite;
    public Sprite bombSprite;

    private int selectedWeapon = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            selectedWeapon = (selectedWeapon + 1) % 3;

            if (selectedWeapon == 0)
                bowIcon.sprite = bowSprite;
            else if (selectedWeapon == 1)
                bowIcon.sprite = boomerangSprite;
            else
                bowIcon.sprite = bombSprite;
        }

        swordIcon.color = Input.GetKey(KeyCode.X)
            ? Color.white
            : new Color(1f, 1f, 1f, 0.4f);

        bowIcon.color = Input.GetKey(KeyCode.Z)
            ? Color.white
            : new Color(1f, 1f, 1f, 0.4f);
    }
}