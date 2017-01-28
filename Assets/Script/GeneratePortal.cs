using UnityEngine;
using System.Collections;

public class GeneratePortal : MonoBehaviour {
    public GameObject portalBlue;
    public GameObject portalRed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
    
    void OnCollisionEnter(Collision obj)
    {
        if(obj.transform.tag == "bullet")
        {
            if(telepScript.portalColor == true)
            {
                Instantiate(portalBlue, obj.transform.position, Quaternion.identity);
                telepScript.bluePortalPosition = obj.transform.position;
                telepScript.portalColor = false;
            }else
            {
                Instantiate(portalRed, obj.transform.position, Quaternion.identity);
                telepScript.redPortalPosition = obj.transform.position;
                telepScript.portalColor = true;
            }

            Destroy(obj.gameObject);

        }

    }
}
