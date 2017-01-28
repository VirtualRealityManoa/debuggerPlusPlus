using UnityEngine;
using System.Collections;

public class level1Script : MonoBehaviour {
    public GameObject rotateBalls;
    Vector3 targetScale = new Vector3(0, 0, 0);
    public float speed = 5;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(rotation.rotationStart == true)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, speed * Time.deltaTime);
        }

        if (rotateBalls == null)
        {
            Destroy(gameObject);
        }
	
	}
}
