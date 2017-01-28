using UnityEngine;
using System.Collections;

public class trapScript : MonoBehaviour {
    public float iniPos;
    public float speed = 5;
    public float move = 0;
	// Use this for initialization
	void Start () {
        iniPos = transform.position.x;
        if(transform.position.x > 0)
        {
            move = -1;
        }else
        {
            move = 1;
        }

	}
	
	// Update is called once per frame
	void Update () {
        if(iniPos > 0)
        {
            if(transform.position.x > iniPos)
            {
                move = -1;
            }
        }else
        {
            if(transform.position.x < iniPos)
            {
                move = 1;
            }
        }
        float step = speed * Time.deltaTime;
        Vector3 targetPosition = new Vector3(transform.position.x + move, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
	}

    void OnTriggerEnter(Collider col)
    {

        if (col.transform.tag == "trap")
        {

            if (move > 0)
            {

                move = -1;
            }else
            {
                move = 1;
            }
        }
        
        
    }
}
