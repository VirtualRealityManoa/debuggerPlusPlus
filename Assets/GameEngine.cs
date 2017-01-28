using UnityEngine;
using System.Collections;

public class GameEngine : MonoBehaviour {

	private int time = 60;
	private int health = 100;
	private int points = 0;
	private int combo = 0;
	private int kills = 0;

	public void setTime(int time) {
		this.time += time;
	}
	public int getTime() {
		return this.time;
	}

	public void setHealth(int health) {
		this.health += health;
	}
	public int getHealth() {
		return this.health;
	}

	public void setPoints(int points) {
		this.points += points;
	}
	public int getPoints() {
		return this.points;
	}

	public void setCombo(int combo) {
		this.combo += combo;
	}
	public int getCombo() {
		return this.combo;
	}

	public void setKills(int kills) {
		this.kills += kills;
	}
	public int getKills() {
		return this.kills;
	}

	// Use this for initialization
	void Start () {
		// show this on the screen
	}
	
	// Update is called once per frame
	void Update () {
		// update the display on the screen
	}

	//TODO: Create a new update on stepUpdate that counts the time down.
}
