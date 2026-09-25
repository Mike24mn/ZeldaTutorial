using UnityEngine;

public class Inventory : MonoBehaviour
{
    private int rupees = 0;

    public void AddRupee()
    {
        rupees++;
    }

    public bool SpendRupee()
    {
        if (rupees <= 0)
            return false;

        rupees--;
        return true;
    }

    public int GetRupees()
    {
        return rupees;
    }

    public void MaxRupees()
{
    rupees = 999;
}
}