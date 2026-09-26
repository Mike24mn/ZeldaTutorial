using UnityEngine;

public class Inventory : MonoBehaviour
{
    private int rupees = 0;
    private int keys = 0;

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

    // ===== Keys =====

    public void AddKey()
    {
        keys++;
        Debug.Log("Key collected. Keys: " + keys);
    }

    public bool SpendKey()
    {
        if (keys <= 0)
            return false;

        keys--;
        Debug.Log("Key used. Keys: " + keys);
        return true;
    }

    public int GetKeys()
    {
        return keys;
    }

    public void MaxKeys()
    {
        keys = 999;
    }
}