
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Transform bowRoom;

    public float roomWidth = 16f;
    public float roomHeight = 11f;

    public float cameraOffsetX = 7.5f;
    public float cameraOffsetY = 5f;

    [Header("Custom Level")]
    public Transform customRoom1;
    public Transform customRoom2;
    public Transform customRoom3;
    public Transform customRoom4;

    void LateUpdate()
    {
        if (target == null)
            return;

        // Check the four custom rooms first
        if (FollowCustomRoom(customRoom1)) return;
        if (FollowCustomRoom(customRoom2)) return;
        if (FollowCustomRoom(customRoom3)) return;
        if (FollowCustomRoom(customRoom4)) return;

        // Special camera position for the Bow Room
        if (bowRoom != null &&
            target.position.x >= bowRoom.position.x - 8f &&
            target.position.x < bowRoom.position.x + 16f &&
            target.position.y >= bowRoom.position.y - 5.5f &&
            target.position.y < bowRoom.position.y + 11f)
        {
            transform.position = new Vector3(
                bowRoom.position.x + cameraOffsetX,
                bowRoom.position.y + cameraOffsetY,
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

    bool FollowCustomRoom(Transform room)
    {
        if (room == null)
            return false;

        // Check if Link is inside this room
        if (target.position.x >= room.position.x &&
            target.position.x < room.position.x + roomWidth &&
            target.position.y >= room.position.y &&
            target.position.y < room.position.y + roomHeight)
        {
            transform.position = new Vector3(
                room.position.x + cameraOffsetX,
                room.position.y + cameraOffsetY,
                transform.position.z
            );

            return true;
        }

        return false;
    }
}
