using UnityEngine;
using System.Collections;

public class ProjectileShootScript : MonoBehaviour
{

    public Rigidbody projectile;
    public Transform bulletSpawn;
    public float projectileForce = 500f;
    public float fireRate = 8f;
    public float spawnLimit = 10;   //10 will be our default limit

    private float nextFireTime;
    private float amountSpawned = 0f;

    // Update is called once per frame
    void Update ()          //we are only applying one single hit of force in one frame. Fixed update isn't needed here.
    {
	    if(Time.time > nextFireTime && amountSpawned < spawnLimit)    //Input.GetButtonDown("Fire2") && Time.time > nextFireTime   [for FPS version]
        {
            Rigidbody cloneRb = Instantiate(projectile, bulletSpawn.position, Quaternion.identity) as Rigidbody; //Quaternion.identity = no rotation
            cloneRb.AddForce(bulletSpawn.transform.up * projectileForce);                                   //shooting forward from gun end
            nextFireTime = Time.time + fireRate;
            amountSpawned++;
        }
        
    }
}
