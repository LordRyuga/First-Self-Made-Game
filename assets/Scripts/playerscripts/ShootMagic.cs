using UnityEngine;

public class ShootMagic : MonoBehaviour
{
    public float MagicShotPower = 10f;
    public float lifetime = 2f;
    public float magicSpeed = 5f;
    [SerializeField] float timer = 5f;
    [SerializeField] gameManager manager;
    float tempTime;
    bool TimerStart;
    bool canShoot;

    [SerializeField] GameObject MagicShotPrefab;
    [SerializeField] Camera Eyes;

    private void Start()
    {
        canShoot = true;
    }

    private void Awake()
    {
        manager = GetComponentInParent<gameManager>();
    }

    private void Update()
    {
        if(TimerStart)
        {
            tempTime += Time.deltaTime;

            if(tempTime > timer)
            {
                tempTime = 0;
                TimerStart = false;
                canShoot = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Q) && canShoot)
        {
            TimerStart = true;
            canShoot = false;

            GameObject MagicShot = Instantiate(MagicShotPrefab, transform.position, Eyes.transform.rotation);

            Rigidbody rb = MagicShot.GetComponent<Rigidbody>();
            bullet MagicPowerScript = MagicShot.GetComponent<bullet>();
            if (manager.isStrong)
            {
                MagicPowerScript.setDamage(3 * MagicShotPower);
            }else
            {
                MagicPowerScript.setDamage(MagicShotPower);
            }
            MagicPowerScript.lifetime = this.lifetime;
            MagicPowerScript.isMagic = true;

            Vector3 direction = Eyes.transform.forward;

            if (rb != null)
            {
                rb.linearVelocity = direction * magicSpeed;
            }

        }
    }
}
