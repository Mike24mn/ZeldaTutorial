
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class FixWaterTiles
{
    [MenuItem("Tools/Fix Water Tiles")]
    public static void Fix()
    {
        int count = 0;

        foreach (GameObject root in SceneManager.GetActiveScene().GetRootGameObjects())
        {
            SpriteRenderer[] renderers =
                root.GetComponentsInChildren<SpriteRenderer>(true);

            foreach (SpriteRenderer sr in renderers)
            {
                if (sr.gameObject.name != "Tile_NONE")
                    continue;

                if (sr.sprite == null || sr.sprite.name != "t_096")
                    continue;

                if (sr.GetComponent<Collider>() != null)
                    continue;

                Undo.AddComponent<BoxCollider>(sr.gameObject);
                count++;
            }
        }

        Debug.Log("Water tiles fixed: " + count);
    }
}
