using DialogueEditor;
using UnityEngine;

public class quests : MonoBehaviour
{
    //Quests will be stored in a 2D Array of bools in order to store it
    public bool[,] questsData = new bool[2, 2];
    public int[] items = new int[1];
    public gameManager gameManager;
    // Final size of this is to be stored in player data.
    // Each row represents a new quest and there are 2 collumns. Collumn 1 shows if quest is active or not
    // collumn 2 shows if quest is completed or not.
    // If further variables needed to mark status of quests, then it will be implemented later.

    //Quest 1 variables
    public bool hasCrateQuest1;

    private void Start()
    {
        questsData[0, 0] = false;
        questsData[0, 1] = false;
        questsData[1, 0] = false;
        questsData[1, 1] = false;
    }
    public void setQuestData()          //Set as event on the dialogue of the thing giving quest in order to set quest's data.
    {
        questsData[ConversationManager.Instance.GetInt("Quest number") - 1, 0] = ConversationManager.Instance.GetBool("Activity");
    }
    public void setQuestCompletion()
    {
        questsData[ConversationManager.Instance.GetInt("Quest number") - 1, 1] = ConversationManager.Instance.GetBool("Completion");
    }


    public void MouseLock()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (ConversationManager.Instance != null)
        {
            if (ConversationManager.Instance.IsConversationActive)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    ConversationManager.Instance.SelectNextOption();
                }
                else
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    ConversationManager.Instance.SelectPreviousOption();
                }
                else
                if (Input.GetKeyDown(KeyCode.Y))
                {
                    ConversationManager.Instance.PressSelectedOption();
                }
            }

        }
    }

}
