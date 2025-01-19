using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveGame : MonoBehaviour
{
    public Button SaveGameButton;
    public Canvas saveIcon;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SaveGameButton.interactable = true;
            saveIcon.enabled = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SaveGameButton.interactable = true;
            saveIcon.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SaveGameButton.interactable = false;
            saveIcon.enabled = false;
        }
    }
}
