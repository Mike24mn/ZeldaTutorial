
using UnityEngine;

public class CustomLevelTeleport : MonoBehaviour
{
    public Transform customLevelSpawn;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4) && customLevelSpawn != null)
        {
            rb.linearVelocity = Vector3.zero;
            transform.position = customLevelSpawn.position;
        }
    }
}
