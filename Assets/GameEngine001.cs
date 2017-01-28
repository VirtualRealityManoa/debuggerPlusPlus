using UnityEngine;
using System.Collections;

public class GameEngine001: MonoBehaviour {

	public GameObject gameTimer;
	public GameObject gameHealth;
	public GameObject gamePoints;
	public GameObject gameKillCount;
	public GameObject gameComboCount;

	float time = 60;
	int health = 100;
	int points = 0;
	int killCount = 0;
	int comboCount = 0;

	void Start () {
		updateLabels();

	}

	void FixedUpdate () {
		// Counts down the game
		if (time > 0) {
			time -= Time.deltaTime;
			updateLabels();
		}
	}

	void updateLabels() {
		// Sets 3D text displays to show game variables
		TextMesh gameTimerMesh = (TextMesh)gameTimer.GetComponent(typeof(TextMesh));
		gameTimerMesh.text = "Time: " + ((int)time).ToString();
		TextMesh gameHealthMesh = (TextMesh)gameHealth.GetComponent(typeof(TextMesh));
		gameHealthMesh.text = "Health: " + health.ToString();
		TextMesh gamePointsMesh = (TextMesh)gamePoints.GetComponent(typeof(TextMesh));
		gamePointsMesh.text = "Points: " + points.ToString();
		TextMesh gameKillCountMesh = (TextMesh)gameKillCount.GetComponent(typeof(TextMesh));
		gameKillCountMesh.text = "Kill Count: " + killCount.ToString();
		TextMesh gameComboCountMesh = (TextMesh)gameComboCount.GetComponent(typeof(TextMesh));
		gameComboCountMesh.text = "Combo Count: " + comboCount.ToString();
	}

	public void setTime(int inputTime){
		this.time = inputTime;
		updateLabels();
	}
	public void setHealth(int health){
		this.health = health;
		updateLabels();
	}
	public void setPoints(int points) {
		this.points = points;
		updateLabels();
	}
	public void setKillCount(int killCount) {
		this.killCount = killCount;
		updateLabels();
	}
	public void setComboCount(int comboCount) {
		this.comboCount = comboCount;
		updateLabels();
	}

	// update kill count
	public void addKill() {
		this.killCount++;
		updateLabels();
	}

	// Add points
	public void addPoints(int inputPoints) {
		this.points += inputPoints;
		updateLabels();
	}
}


















