using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public Transform gunPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 25f;
    public Transform player;
    public float spread = 0.06f;
    public LayerMask enemies;
    public gameManager gameManager;
    // Update is called once per frame
    private void Update()
    {
        Quaternion rotation = Quaternion.LookRotation(player.forward);
        transform.rotation = rotation;

        gunPoint.rotation = rotation;
    }



    public void shooting()
    {
        GameObject bullet = Instantiate(bulletPrefab, gunPoint.position, gunPoint.rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        bullet bulletscript = bullet.GetComponent<bullet>();

        bulletscript.setDamage(gameManager.attack);

        Vector3 Direction = gunPoint.forward;
        Direction += new Vector3(Random.Range(-spread, spread), Random.Range(-spread, spread), Random.Range(-spread, spread));
        Direction.Normalize();
        if (rb != null )
        {
            rb.linearVelocity = Direction * bulletSpeed;
        }
    }
   
}
