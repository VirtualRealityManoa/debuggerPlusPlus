using UnityEngine;
using System.Collections;

public class portalScript : MonoBehaviour {
    public GameObject targetPortal;
    public static bool intoPortal = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter(Collider obj)
    {
        Debug.Log(tag);
        if(obj.transform.tag == "Player")
        {
            if(tag == "bluePortal" && telepScript.outPortalBlue == true)
            {
                obj.transform.position = telepScript.redPortalPosition;
                telepScript.outPortalRed = false;

            }
            else if(tag == "redPortal" && telepScript.outPortalRed == true)
            {
                obj.transform.position = telepScript.bluePortalPosition;
                telepScript.outPortalBlue = false;

            }
        }
    }

    void OnTriggerExit(Collider obj)
    {
        if(tag == "bluePortal")
        {
            telepScript.outPortalBlue = true;
        }else if(tag == "redPortal")
        {
            telepScript.outPortalRed = true;
        }

        
    }

    void changeIntoPortal()
    {
        portalScript.intoPortal = false;
    }
}
