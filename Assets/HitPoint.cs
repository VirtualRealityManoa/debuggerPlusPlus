using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HitPoint : MonoBehaviour {

	public Slider hp;


	// Use this for initialization
	void Start () {
		hp = GameObject.Find("Slider").GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void damaged(int damage)
	{
		hp.value = hp.value - damage;
	}
}
