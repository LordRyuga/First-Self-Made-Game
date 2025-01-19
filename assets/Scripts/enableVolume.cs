using UnityEngine;
using UnityEngine.Rendering;

public class enableVolume : MonoBehaviour
{
    public Volume volume;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            volume.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            volume.enabled = false;
        }
    }
}
