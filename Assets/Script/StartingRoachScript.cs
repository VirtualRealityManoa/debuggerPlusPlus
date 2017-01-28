using UnityEngine;
using System.Collections;

public class StartingRoachScript : MonoBehaviour {

    public float min = 2f;
    public float max = 3f;

    //public GameObject startingRoach;
    public GameObject laptop;

	// Use this for initialization
	void Start () 
    {
        min = transform.position.z;
        max = transform.position.z + 3;
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.PingPong(Time.time * 2, max - min) + min);

        if(Vector3.Distance(transform.position, laptop.transform.position) > 20)                  //if the roach exceeds the distance of 20 from laptop, it dies and game starts
        {
            this.gameObject.SetActive(false);
        }
	}

    /**
    void OnCollisionEnter(Collision obj)
    {

        if(obj.CompareTag("Player"))
        {
            Debug.Log("Player Slipper Collided with Roach!");

            startingRoach.SetActive(false);
        }
    }
    */

}
