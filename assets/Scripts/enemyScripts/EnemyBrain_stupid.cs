using Unity.Cinemachine;
using UnityEngine;

public class EnemyBrain_stupid : MonoBehaviour
{
    public Transform target;    // Reference to our target
    private EnemyReferences enemyReferences;    //reference to the script containing all the references that might be needed
    public gameManager Player;

    public float followRange;
    public float rewardOnKill;
    private float shootingDistance;     //Shooting distance
    private float pathUpdateTime;       //timer to update path
    Vector3 directionAway;


    public float health = 100f;

    private void Awake()
    {
        enemyReferences = GetComponent<EnemyReferences>();
    }

    private void Start()
    {
        shootingDistance = enemyReferences.navMeshagent.stoppingDistance + 5f; // we can change this to create a difference between follow distance and stopping distance
    }

    private void Update()
    {

        if (target != null)
        {
            bool infollowRange = Vector3.Distance(transform.position, target.position) <= followRange;
            bool inRange = Vector3.Distance(transform.position, target.position) <= shootingDistance;  //check if target is in range of shooting

            if (inRange)
            {
                LookAtTarget();         //if In range, look at it. We use animator and events to implement shooting later on
            }else
            {
                if (infollowRange)
                {
                    UpdateTarget();         //If not in range, then follow the enemy
                }
            }
            enemyReferences.animator.SetBool("shooting", inRange);      //setting the shooting bool in parameters of animator to same as inRange
        }
        enemyReferences.animator.SetFloat("Speed", enemyReferences.navMeshagent.desiredVelocity.sqrMagnitude);      //Setting the value of the blend in animator
                                                                                                 //relative to the speed of the enemy character

        if (health < 0f)
        {
            Player.health += rewardOnKill;
            Destroy(gameObject);
        }
    }


    private void LookAtTarget()
    {
        Vector3 look = target.position - transform.position;
        look.y = 0f;
        Quaternion rotation = Quaternion.LookRotation(look);        //converting the look vector into a quaternion
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.2f);      // Slerp smooths out the transistion from current look direction to the target
    }

    private void UpdateTarget()
    {
        //Usually people just compute the path every frame, but we do not need to do that. Instead we can set a simple delay of around 0.2 seconds in order to 
        //compute the destination and path every 0.2s which practically doesn't affect gameplay and lessens computational load.

        if (Time.time > pathUpdateTime)
        {
            pathUpdateTime = Time.time + enemyReferences.pathUpdatedelay;
            if (health > 45f)
            {
                enemyReferences.navMeshagent.SetDestination(target.position);
            }else
            {
                float distance = Vector3.Distance(transform.position, target.position);

                if (distance < (shootingDistance - 5f))
                {
                    directionAway = (transform.position - target.position).normalized;
                    Vector3 newDestination = target.position + directionAway * (shootingDistance - 3f);
                    enemyReferences.navMeshagent.SetDestination(newDestination);
                }
            }
        }
        
    }
}
