using UnityEngine;
using System.Collections;

public class OrbitSun : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		int rotateSpeed = 3;
		transform.RotateAround (Vector3.zero, Vector3.up, rotateSpeed * Time.deltaTime);	
	}
}
