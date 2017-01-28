using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour {
	public int score;
	public int totalscore;
	public int power;
	private GameObject parent;

	public AudioClip itemSound;
	public AudioClip roachSound;
	public AudioClip bossSound;
	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		score = 0;
		power = 10;
		parent = transform.root.gameObject;
		audioSource = gameObject.GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {
	}
		

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("roach"))
		{
			audioSource.clip = roachSound;
			audioSource.Play();
			other.gameObject.SendMessage ("attacked", power);
			totalscore = totalscore + score;
		}

		if (other.gameObject.CompareTag ("item_speed"))
		{
			other.gameObject.SetActive (false);
			audioSource.clip = itemSound;
			audioSource.Play();
			parent.SendMessage ("speedup");
		}
		if (other.gameObject.CompareTag ("item_power"))
		{
			other.gameObject.SetActive (false);
			audioSource.Play();
			power = power + 10;
		}
	}

	/*

	void  OnTrigerEnter(Collider col){
		//SendMessage(“関数名”) で対象が持っているスクリプトが持っている関数を呼び出すことができる  
		if (col.gameObject.tag == "roach") {
			col.gameObject.SendMessage ("attacked", 10);
		}
	}
	*/
}
