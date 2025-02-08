using Unity.Cinemachine;
using UnityEngine;

public class RangeDetectorBear : MonoBehaviour
{
    public Transform player;
    public float range= 5f;
    float Distance;
    Vector3 Direction;
    bool InRange;
    public Animator bear;
    BearManager bearManager;
    public gameManager manager;


    private void Awake()
    {
        bearManager = GetComponent<BearManager>();
    }
    private void Update()
    {
        Distance = Vector3.Distance(transform.position, player.position);
        // get the distance between the player and the bear

        InRange = Distance < range;
        //check if the player is within the bear's range or not

        if(InRange && !bearManager.fed)     //make the bear attack or be able to be fed again only if it is not fed
        {
            Direction = -((transform.position - player.position).normalized);   
            Direction.y = 0;
            transform.forward = Direction;
            
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (manager.questsScriptReference.items[0] > 0 && !bearManager.fed)  // using the referenc to quest items present in the gameManager,
                                                                                     //   we check the number of fish present as it is hard coded into the
                                                                                     // 0th index of the items array.
                {
                    manager.questsScriptReference.items[0]--;
                    bearManager.fed = true;
                    Debug.Log(manager.questsScriptReference.items[0]);
                }
            }
        }

        bear.SetBool("InRange", InRange);
    }
}
