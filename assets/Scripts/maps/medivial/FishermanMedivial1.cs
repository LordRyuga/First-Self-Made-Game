using DialogueEditor;
using UnityEngine;

public class FishermanMedivial1 : MonoBehaviour
{
    // Add a method so that player gains fish only once later.
    public NPCConversation fishermanMedivial1;
    public quests questScriptReference;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                ConversationManager.Instance.StartConversation(fishermanMedivial1);
            }
        }
    }

    public void setDataOfItems()
    {
        questScriptReference.items[0] += 5;
        Debug.Log("+5 Fishes");
    }
}
