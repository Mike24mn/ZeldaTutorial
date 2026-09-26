using UnityEngine;

public class ResolutionManager : MonoBehaviour
{
    void Start()
    {
        Screen.SetResolution(1024, 960, false);
    }
}