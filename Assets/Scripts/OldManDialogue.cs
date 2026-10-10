using UnityEngine;

public class OldManDialogue : MonoBehaviour
{
    public GameObject dialogueText;
    public Transform player;
    public float activationDistance = 4f;

    void Update()
    {
        if (player == null || dialogueText == null)
            return;

        float distance = Vector3.Distance(
            transform.position,
            player.position
        );

        dialogueText.SetActive(distance <= activationDistance);
    }
}