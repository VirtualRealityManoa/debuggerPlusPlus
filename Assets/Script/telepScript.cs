using UnityEngine;
using System.Collections;

public class telepScript : MonoBehaviour {

    public GameObject TelepDis;
    public float telepCDTime = 2f;
    public bool telepCD = true;
    public GameObject telepBulletPosition;
    public GameObject telepBullet;
    public GameObject target;
    public float speed = 0.1f;
    public static bool portalColor = true;
    public static bool outPortalBlue = true;
    public static bool outPortalRed = true;
    public static Vector3 bluePortalPosition;
    public static Vector3 redPortalPosition;
    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.T) & telepCD == true)
        {
            transform.position = TelepDis.transform.position;
            telepCD = false;
            Invoke("telepCDMethod", telepCDTime);
        }

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject bullet = (GameObject) Instantiate(telepBullet, telepBulletPosition.transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().AddForce( -(bullet.transform.position - TelepDis.transform.position) * speed);
        }
    }

    void telepCDMethod()
    {
        telepCD = true;
    }
}
