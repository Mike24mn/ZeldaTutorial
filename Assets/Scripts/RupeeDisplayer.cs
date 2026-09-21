using UnityEngine;
using TMPro;

public class RupeeDisplayer : MonoBehaviour
{
    public Inventory inventory;

    private TMP_Text text;

    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        text.text = inventory.GetRupees().ToString();
    }
}