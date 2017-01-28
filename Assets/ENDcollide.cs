using UnityEngine;
using System.Collections;

public class ENDcollide : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			this.gameObject.SetActive(false);
		}
	}
}
