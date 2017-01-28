using UnityEngine;
using System.Collections;

public class slipper : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine("move");

        }

    }


    IEnumerator move()
    { 
        transform.Translate(Vector3.down * 80);
        yield return new WaitForSeconds(0.85f);
        transform.Translate(Vector3.up * 80);
        Debug.Log(transform.rotation.z);
        if (transform.rotation.z > 60)
        {
            transform.Rotate(0, 0, -90);
            yield return new WaitForSeconds(2.5f);
            transform.Rotate(0, 0, 90);
        }
    }

}


