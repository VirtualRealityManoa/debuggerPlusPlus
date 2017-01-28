using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    //public PlayerHealth playerHealth;     //taken from the tutorial
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

    private float specialSpawnTime = 15f;
    private GameObject enemyClone;

    // Use this for initialization
    void Start()
    {
        /*
        if (enemy.CompareTag("Special") == true)              //we want to spawn "special" enemies less frequently
        {
            Spawn();
        }
        
        else
        */

        if (enemy.CompareTag("Special") == false)           //only repeat spawns if it's not special
        {
            InvokeRepeating("Spawn", spawnTime, spawnTime);
        }
    }

    //"Special" enemies only spawn less frequently and the next one spawns only when the previous one dies
    void FixedUpdate()
    {
        //Debug.Log("FixedUpdate is working!");

        if (GameObject.Find("SpecialRoachClone") == false)
        {
            Debug.Log("enemyClone is off");

            if (enemyClone == null)                                                     //this whole thing could probably be coded more efficiently later as of 4/26/16
            {
                Debug.Log("enemyClone is null");

                specialSpawnTime -= Time.deltaTime;

                if (specialSpawnTime <= 0.0)                                                      //when we are done waiting, we can then spawn the Roachlings and get rid of ball
                {
                    int spawnPointIndex = Random.Range(0, spawnPoints.Length);

                    enemyClone = Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation) as GameObject;
                    enemyClone.name = "SpecialRoachClone";

                    Debug.Log("SpecialRoach Clone is turned on");

                    specialSpawnTime = 15f;

                    Debug.Log("SpecialRoach Clone spawn time has been reset");
                }
            }
        }
    }

    void Spawn()
    {
        
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }

    
    void specialSpawn()         //might want to encorporate this in Fixedupdate form
    {
        specialSpawnTime -= Time.deltaTime;

        if (specialSpawnTime <= 0.0)                                                      //when we are done waiting, we can then spawn the Roachlings and get rid of ball
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }
    }
    

}
