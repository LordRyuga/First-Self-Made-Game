using Unity.VisualScripting;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float lifetime = 5f;
    public bool isMagic;
    [SerializeField] float enemyAttackPower;
    [SerializeField] GameObject particleSystemReference;
    float damage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided");
        if (other.tag == "enemy")
        {
            EnemyBrain_stupid er;
            Health enemyHealth;
            er = other.gameObject.GetComponent<EnemyBrain_stupid>();
            enemyHealth = other.gameObject.GetComponent<Health>();
            if ( er != null)
            {
                er.health -= damage;
                Debug.Log(damage);
                Debug.Log(er.health);   
            }
            if (enemyHealth != null)
            {
                enemyHealth.health -= damage;
            }
            if (isMagic)
            {
                GameObject shockwave = Instantiate(particleSystemReference, transform.position, Quaternion.identity);
                Destroy(shockwave, 1f);
            }
            Destroy(gameObject);
        }else
        if (other.tag == "Player")
        {
            gameManager manager;
            gameManager managerFromParent;
            Debug.Log("Hit Player");
            managerFromParent = other.GetComponentInParent<gameManager>();
            manager = other.GetComponent<gameManager>();
            if ( manager != null )
            {
                manager.health -= enemyAttackPower;
                Debug.Log("Working");
                Debug.Log(enemyAttackPower);
                //Debug.Log(manager.health);
            }else
            if ( managerFromParent != null )
            {
                managerFromParent.health -= enemyAttackPower;
                Debug.Log("Fixed");
            }
            else
            {
                Debug.Log("Null?");
            }
            Destroy(gameObject);
        }else if (!other.CompareTag("background"))
        {
            Debug.Log(other.tag);
            if(isMagic)
            {
                GameObject shockwave = Instantiate(particleSystemReference, transform.position, Quaternion.identity);
                Destroy(shockwave, 0.4f);
            }
            Destroy(gameObject);

        }
    }


    public void setDamage(float value)
    {
        damage = value; 
    }

    public void setEnemyAttack(float value)
    {
        enemyAttackPower = value;
    }
}

