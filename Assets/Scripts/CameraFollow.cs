
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

    // Position of CustomRoom1
    public Vector2 customLevelOrigin = new Vector2(-54f, -6f);

    void LateUpdate()
    {
        if (target == null)
            return;

        // Custom level: use its own grid
        if (FollowCustomLevel())
            return;

        // Special Bow Room camera
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

        // Original dungeon camera
        int roomX = Mathf.FloorToInt(target.position.x / roomWidth);
        int roomY = Mathf.FloorToInt(target.position.y / roomHeight);

        transform.position = new Vector3(
            roomX * roomWidth + cameraOffsetX,
            roomY * roomHeight + cameraOffsetY,
            transform.position.z
        );
    }

    bool FollowCustomLevel()
    {
        // Check Link's position against the custom level grid
        float relativeX = target.position.x - customLevelOrigin.x;
        float relativeY = target.position.y - customLevelOrigin.y;

        int roomX = Mathf.FloorToInt(relativeX / roomWidth);
        int roomY = Mathf.FloorToInt(relativeY / roomHeight);

        // Only handle our 2x2 custom level
        if (roomX < 0 || roomX > 1 ||
            roomY < 0 || roomY > 1)
        {
            return false;
        }

        float cameraX = customLevelOrigin.x
                        + roomX * roomWidth
                        + cameraOffsetX;

        float cameraY = customLevelOrigin.y
                        + roomY * roomHeight
                        + cameraOffsetY;

        transform.position = new Vector3(
            cameraX,
            cameraY,
            transform.position.z
        );

        return true;
    }
}
