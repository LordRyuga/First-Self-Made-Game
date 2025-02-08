using UnityEngine;
using UnityEngine.Playables;

public class openingConfig : MonoBehaviour
{
    [SerializeField] private PlayableDirector openingTimeline;
    [SerializeField] private movement playerMovement;
    private float time;


    private void Start()
    {
        playerMovement.ShouldMove = false;
        Debug.Log(playerMovement.ShouldMove);
        Debug.Log(openingTimeline.duration);
    }



    private void Update()
    {
        time += Time.deltaTime;
        if (openingTimeline != null)
        {
            if(time > openingTimeline.duration)
            {
                Debug.Log("done");
                playerMovement.ShouldMove = true;
                Destroy(gameObject);
            }
        }
    }

}
