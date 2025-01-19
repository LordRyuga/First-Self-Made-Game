using UnityEngine;

public class RestArea : MonoBehaviour
{
    public Canvas restArea;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gameManager manager = other.GetComponent<gameManager>();
            manager.shouldDie = false;
            restArea.enabled = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gameManager manager = other.GetComponent<gameManager>();
            manager.shouldDie = false;
            restArea.enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gameManager manager = other.GetComponent<gameManager>();
            manager.shouldDie = true;
            restArea.enabled = false;   
        }
    }
}
