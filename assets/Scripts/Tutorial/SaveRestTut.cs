using TMPro;
using UnityEngine;

public class SaveRestTut : MonoBehaviour
{
    public TextMeshProUGUI SaveRestText;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (SaveRestText != null)
            {
                SaveRestText.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (SaveRestText != null)
            {
                SaveRestText.enabled = false;
            }
        }

        SaveRestText.gameObject.SetActive(false);
    }
}
