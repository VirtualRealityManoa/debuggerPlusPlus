using UnityEngine;
using System.Collections;

public class RoachSpawnScript : MonoBehaviour {

    public GameObject destroyerRoachlings;
    public Transform roachSpawn;

    private float waitTime = 5f;
 
    
    //The Debug.Log statements can be added back for debugging purposes
    void FixedUpdate()
    {

        if(this.gameObject.activeSelf == true)
        {

            waitTime -= Time.deltaTime;

            if(waitTime <= 0.0)                                                      //when we are done waiting, we can then spawn the Roachlings and get rid of ball
            {
                //Debug.Log("waitTime is <= 0");

                this.gameObject.SetActive(false);

                //Debug.Log("set the game obj to false");

                for (int i = 0; i < 3; i++)
                {
                    //Debug.Log("Went inside for loop and spawning 3 Roachlings");
                    Instantiate(destroyerRoachlings, roachSpawn.position, Quaternion.identity);         //Quaternion.identity = no rotation
                }
            }

        }

    }
    
}
