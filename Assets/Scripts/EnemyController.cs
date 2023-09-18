using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawn;
    public float timeBetweenFiring;
    private float timer;
    private bool canShoot;

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    public void Damage()
    {
        Destroy(gameObject);
    }

    void Shoot()
    {
        timer += Time.deltaTime;

        if (timer > timeBetweenFiring)
        {
            Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
            timer = 0;
        }   
        
    }
}
