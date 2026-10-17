using UnityEngine;

public class ResolutionManager : MonoBehaviour
{
    void Start()
    {
#if !UNITY_WEBGL
        Screen.SetResolution(1024, 960, false);
#endif
    }
}