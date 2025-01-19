using UnityEngine;
using UnityEngine.AI;

[DisallowMultipleComponent]
public class EnemyReferences : MonoBehaviour
{
    [HideInInspector]
    public NavMeshAgent navMeshagent;
    [HideInInspector]
    public Animator animator;

    public float pathUpdatedelay = 0.2f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        navMeshagent = GetComponent<NavMeshAgent>();
    }
}
