using UnityEngine;

public class handleOpen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private bool inDoorRange;
    private int checker;
    public Animator door;
    private bool DoorSwing;

    //Initially door is closed. So checker positive indicates that door must be close right now
    //Then we change it to -1. now we should make transistion to the animation of doorSwingOpen.

    void Start()
    {
        checker = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && inDoorRange)
        {
            checker *= -1;
        }

        DoorSwing = checker > 0;
        //If checker goes -1, Doorswing becomes false. THis means we transistion to door open whenever DoorSwing
        // Is set to false.
        door.SetBool("DoorSwing", DoorSwing);

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inDoorRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inDoorRange = false;
        }
    }
}
