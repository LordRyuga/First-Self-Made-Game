using UnityEngine;

public class pickedUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collider collider = GetComponent<Collider>();
            collider.enabled = false;
            gameObject.SetActive(false);
            quests manager = other.GetComponent<quests>();

            manager.hasCrateQuest1 = true;
        }
    }
}
