using TMPro;
using UnityEngine;

public class WASD : MonoBehaviour
{
    public TextMeshProUGUI MovementText;

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (MovementText != null)
            {
                MovementText.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (MovementText != null)
            {
                MovementText.enabled = false;   
            }
        }

        MovementText.gameObject.SetActive(false);
    }
}
