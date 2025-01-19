using TMPro;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public TextMeshProUGUI InteractText;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (InteractText != null)
            {
                InteractText.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (InteractText != null)
            {
                InteractText.enabled = false;
            }
        }

        InteractText.gameObject.SetActive(false);
    }
}
