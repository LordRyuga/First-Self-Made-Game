using System.Collections;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public Transform shootPoint;
    public Transform gunPoint;
    public GameObject bulletPrefab;
    public float spread;
    public LayerMask layermask;
    public gameManager ManagerScript;
    public float enemyAttackPower;
    public float bulletSpeed;

    public TrailRenderer bulletTrail;

    private EnemyReferences enemyReferences;

    private void Awake()
    {
        enemyReferences = GetComponent<EnemyReferences>();
    }

    public void shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, gunPoint.position, gunPoint.rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        bullet bulletscript = bullet.GetComponent<bullet>();

        bulletscript.setEnemyAttack(enemyAttackPower);

        Vector3 Direction = GetDirection();
        if (rb != null)
        {
            rb.linearVelocity = Direction * bulletSpeed;
        }
    }

    private Vector3 GetDirection()
    { 
        Vector3 dir = transform.forward;

        dir += new Vector3(Random.Range(-spread, spread), Random.Range(-spread, spread), Random.Range(-spread, spread));

        dir = dir.normalized;

        return dir;
    }

    //private IEnumerator SpawnTrail(TrailRenderer trail, RaycastHit hitInfo)
    //{
    //    float time = 0f;
    //    Vector3 startPos = trail.transform.position;
    //    bullet shotBullet = trail.GetComponentInParent<bullet>();

    //    while (time < 1)
    //    {
    //        if (trail != null)
    //        {
    //            trail.transform.position = Vector3.Lerp(startPos, hitInfo.point, time);
    //            time += Time.deltaTime / trail.time;
    //            trail.transform.position = hitInfo.point;
    //            if (shotBullet != null)
    //            {
    //                shotBullet.setEnemyAttack(enemyAttackPower);
    //            }
    //        }

    //        yield return null;
    //    }


    //    Destroy(trail.gameObject, trail.time);
    //}
    
}
