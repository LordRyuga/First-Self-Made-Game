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

        InRange = Distance < range;

        if(InRange && !bearManager.fed)
        {
            Direction = -((transform.position - player.position).normalized);
            Direction.y = 0;
            transform.forward = Direction;
            
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (manager.questsScriptReference.items[0] > 0 && !bearManager.fed)
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
