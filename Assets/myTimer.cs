using UnityEngine;
using System.Collections;

public class myTimer : MonoBehaviour {

	public GameObject gameTimer;
	public GameObject gameHealth;
	public GameObject gamePoints;
	public GameObject gameKillCount;
	public GameObject gameComboCount;

	int time = 60;
	int health = 100;
	int points = 0;
	int killCount = 0;
	int comboCount = 0;

	// Use this for initialization
	void Start () {

		updateLabels();

	}
	
	// Update is called once per frame
	void Update () {
		// Counts down the game
		if (time > 0) {
			time -= 1;
			updateLabels();
		}
	}

	void updateLabels() {
		// Sets 3D text displays to show game variables
		TextMesh gameTimerMesh = (TextMesh)gameTimer.GetComponent(typeof(TextMesh));
		gameTimerMesh.text = time.ToString();
		TextMesh gameHealthMesh = (TextMesh)gameHealth.GetComponent(typeof(TextMesh));
		gameHealthMesh.text = health.ToString();
		TextMesh gamePointsMesh = (TextMesh)gamePoints.GetComponent(typeof(TextMesh));
		gamePointsMesh.text = points.ToString();
		TextMesh gameKillCountMesh = (TextMesh)gameKillCount.GetComponent(typeof(TextMesh));
		gameKillCountMesh.text = killCount.ToString();
		TextMesh gameComboCountMesh = (TextMesh)gameComboCount.GetComponent(typeof(TextMesh));
		gameComboCountMesh.text = comboCount.ToString();
	}
}
