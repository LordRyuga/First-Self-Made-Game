using DialogueEditor;
using UnityEngine;

public class Farmer1Convo : MonoBehaviour
{
    public NPCConversation farmer_convo;
    public quests QuestInfo;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("working");

            if(Input.GetKeyDown(KeyCode.F) && ConversationManager.Instance.IsConversationActive == false)
            {
                ConversationManager.Instance.StartConversation(farmer_convo);
            }
        }
    }
    private void Update()
    {
        if (ConversationManager.Instance.IsConversationActive)
        {
            ConversationManager.Instance.SetBool("Quest 1", QuestInfo.questsData[0, 0]);
        }
    }
}
