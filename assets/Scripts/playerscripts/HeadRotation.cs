using UnityEngine;

public class HeadRotation : MonoBehaviour
{
    public Camera eyes;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(0, eyes.transform.eulerAngles.y, 0);  
    }
}
    