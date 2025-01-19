using DialogueEditor;
using UnityEngine;

public class DialogueDefault : MonoBehaviour
{
    [SerializeField] NPCConversation dialogue;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                ConversationManager.Instance.StartConversation(dialogue);
            }
        }
    }
}
