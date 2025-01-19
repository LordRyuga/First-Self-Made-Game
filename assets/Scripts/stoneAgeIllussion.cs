using UnityEngine;
using UnityEngine.Playables;

public class stoneAgeIllussion : MonoBehaviour
{
    public GameObject neighbours; // Parent object containing the terrains
    public Terrain transistion1;
    public GameObject room1;
    public GameObject sword;
    public GameObject gun;
    bool hasLeft;
    [SerializeField] PlayableDirector TransistionTimeline;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Delay disabling the terrains
            StartCoroutine(DisableAfterPhysicsNeighbours());
            transistion1.enabled = true;
            room1.SetActive(true);
            gun.SetActive(true);
            TransistionTimeline.Play();
            hasLeft = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Enable terrains immediately
            neighbours.SetActive(true);
            sword.SetActive(true);
            StartCoroutine(DisableAfterPhysicsRoom1());
            if (hasLeft)
            {
                TransistionTimeline.Play();
            }
        }
    }

    private System.Collections.IEnumerator DisableAfterPhysicsNeighbours()
    {
        // Wait for the end of the frame to safely disable GameObjects
        yield return new WaitForEndOfFrame();
        neighbours.SetActive(false);
        sword.SetActive(false);
    }

    private System.Collections.IEnumerator DisableAfterPhysicsRoom1()
    {
        yield return new WaitForEndOfFrame();
        room1.SetActive(false);
        gun.SetActive(false);
        transistion1.enabled = false;
    }
}
