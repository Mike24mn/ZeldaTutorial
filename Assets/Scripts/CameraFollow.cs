using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float roomWidth = 16f;
    public float roomHeight = 11f;

    public float cameraOffsetX = 7.5f;
    public float cameraOffsetY = 5f;

    void LateUpdate()
    {
        if (target == null)
            return;

        int roomX = Mathf.FloorToInt(target.position.x / roomWidth);
        int roomY = Mathf.FloorToInt(target.position.y / roomHeight);

        float cameraX = roomX * roomWidth + cameraOffsetX;
        float cameraY = roomY * roomHeight + cameraOffsetY;

        transform.position = new Vector3(
            cameraX,
            cameraY,
            transform.position.z
        );
    }
}