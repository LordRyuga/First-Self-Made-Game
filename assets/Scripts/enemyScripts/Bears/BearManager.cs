using UnityEngine;

public class BearManager : MonoBehaviour
{
    float InvincibilityTime = 1f;
    bool hit;
    bool Iframe;
    public float knockback = 3f;
    public float damage = 50f;
    public bool fed;
    Animator bear;
    float timer;

    public float sleepTime = 10f;


    private void Awake()
    {
        bear = GetComponent<Animator>();
    }
    private void Start()
    {
        Iframe = false;
        hit = false;
        timer = sleepTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager player = other.GetComponent<gameManager>();
            movement playerMovement = other.GetComponent<movement>();

            Vector3 Direction = transform.forward.normalized;
            Direction.y = 1f;

            playerMovement.Controller.Move(Direction * knockback * Time.deltaTime);


            if(!Iframe)
            {
                player.health -= damage;
                hit = true;
            }
            //Debug.Log("Hit Player");
        }
    }

    private void Update()
    {
        if(hit)
        {
            InvincibilityTime -= Time.deltaTime;
            Iframe = true;
        }

        if (InvincibilityTime < 0f)
        {
            Iframe = false;
            InvincibilityTime = 1f;
            hit = false;
        }

        if(timer > 0f && fed)
        {
            timer -= Time.deltaTime;
        }else
        if(timer < 0f)
         {
            fed = false;
            timer = sleepTime;
            //Debug.Log(bear.GetBool("Sleep"));
         }

        bear.SetBool("Sleep", fed);
        
    }
}
