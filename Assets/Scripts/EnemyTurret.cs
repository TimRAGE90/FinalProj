using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    private GameObject target;
    private bool targetLocked;

    public GameObject turretTop;
    public GameObject bulletSpawnPoint;
    public GameObject bullet;

    public float fireTimer;
    private bool shotReady;

    // Start is called before the first frame update
    void Start()
    {
        shotReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Shooting and detecting enemies
        if (targetLocked)
        {
            turretTop.transform.LookAt(target.transform);
            turretTop.transform.Rotate(0, 0, 0);

            if (shotReady)
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Transform _bullet = Instantiate(bullet.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
        _bullet.transform.rotation = bulletSpawnPoint.transform.rotation;
        shotReady = false;
        StartCoroutine(FireRate());
    }

    IEnumerator FireRate()
    {
        yield return new WaitForSeconds(fireTimer);
        shotReady = true;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (target)
                targetLocked = true;
            else
                targetLocked = false;

            if (targetLocked == false)
            {
                target = other.gameObject;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            targetLocked = false;
        }
    }
}
