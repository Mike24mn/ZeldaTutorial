using UnityEngine;

public class Inventory : MonoBehaviour
{
    private int rupees = 0;

    public void AddRupee()
    {
        rupees++;
    }

    public int GetRupees()
    {
        return rupees;
    }
}