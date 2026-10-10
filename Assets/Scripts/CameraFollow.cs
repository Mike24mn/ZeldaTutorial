using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Transform bowRoom;

    public float roomWidth = 16f;
    public float roomHeight = 11f;

    public float cameraOffsetX = 7.5f;
    public float cameraOffsetY = 5f;

    void LateUpdate()
    {
        if (target == null)
            return;

        // Special camera position for the Bow Room
        if (bowRoom != null &&
            target.position.x >= bowRoom.position.x - 8f &&
            target.position.x < bowRoom.position.x + 8f &&
            target.position.y >= bowRoom.position.y - 5.5f &&
            target.position.y < bowRoom.position.y + 5.5f)
        {
            transform.position = new Vector3(
                bowRoom.position.x,
                bowRoom.position.y,
                transform.position.z
            );
            return;
        }

        // Normal dungeon camera snapping
        int roomX = Mathf.FloorToInt(target.position.x / roomWidth);
        int roomY = Mathf.FloorToInt(target.position.y / roomHeight);

        transform.position = new Vector3(
            roomX * roomWidth + cameraOffsetX,
            roomY * roomHeight + cameraOffsetY,
            transform.position.z
        );
    }
}