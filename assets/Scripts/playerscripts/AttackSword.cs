using UnityEngine;

public class AttackSword : MonoBehaviour
{
    gameManager gameManager;

    private void Awake()
    {
        gameManager = GetComponentInParent<gameManager>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            Debug.Log("attacked!");
            Health health = other.GetComponent<Health>();
            if (health != null)
            {
                health.health -= gameManager.attack;
            }else
            {
                health = other.GetComponentInParent<Health>();
                if (health != null)
                {
                    health.health -= gameManager.attack;
                }
            }
        }
    }
}
