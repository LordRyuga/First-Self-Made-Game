using TMPro;
using UnityEngine;
using DialogueEditor;

public class dialogue : MonoBehaviour
{
    public NPCConversation quest1;
    public NPCConversation quest1Complete;
    public NPCConversation shop;
    public Animator talking;
    private bool TalkingWithShopkeeper;

    private void OnTriggerStay(Collider other)
    {
        quests PlayerQuests = other.GetComponent<quests>();
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F) && ConversationManager.Instance.IsConversationActive == false)
            {
                TalkingWithShopkeeper = true;
                if (PlayerQuests.questsData[0, 0] == false)
                {
                    ConversationManager.Instance.StartConversation(quest1);
                    Debug.Log("Conversation started");
                }else if(PlayerQuests.questsData[0, 0] == true && PlayerQuests.questsData[0, 1] == false)
                {
                    ConversationManager.Instance.StartConversation(quest1Complete);
                    ConversationManager.Instance.SetBool("hasCrateQuest1", PlayerQuests.hasCrateQuest1);
                }else
                {
                    ConversationManager.Instance.StartConversation(shop);
                }
               
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TalkingWithShopkeeper = false;
        }
    }

    private void Update()
    {
            talking.SetBool("talking", TalkingWithShopkeeper);
    }


}
