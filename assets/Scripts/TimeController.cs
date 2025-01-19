using UnityEngine;

public class TimeController : MonoBehaviour
{
    Transform Light;            // The transform of the Sun in scene

    [SerializeField]
    private float senstivity;       //The sensitivity of the day night cycles, changing will change the speed of day and night.

    private void Awake()
    {
        Light = transform;          //Since script is attached to the Light source in scene, set Light as transform of gameobject
    }

    private float tempTime;         //amount of time passed in seconds
    private void Update()
    {
        tempTime += Time.deltaTime;

        Light.rotation = Quaternion.Euler((tempTime * senstivity) % 360f, -20, 0);      //Set the x rotation of the light in order to spin it
    }

}
