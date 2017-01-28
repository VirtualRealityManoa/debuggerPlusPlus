using UnityEngine;
using System.Collections;

public class gamescore : MonoBehaviour {

    private int totalScore;
    private int killPoints;

	// Use this for initialization
	void Start () {
        totalScore = 0;

	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("Total score: "+totalScore+". Kill points: "+killPoints+". Time points: "+(200-(Time.time)/60)+". The player's current rank is: "+getRank());
	}

    public void addKillPoint()
    {
        killPoints++;
    }

   public void addPoints(int num_points)
    {
        totalScore += num_points;
    }

    public int[] getTotals()
    {
        int[] totals = new int[4];
        totals[0] = totalScore;
        totals[1] = killPoints;
        totals[2] = (int)Time.time; //this returns the number of seconds since the beginning of the game, need to convert for nicer presentation
        totals[3] = getRank(); //im imagining the ranking like this: 0 = D, 1 = C, 2 = B, 3 = A, 4 = S.

        return totals;
    }

    int getRank()
    {
        int rank = 0;
        int max_value = 1000;
        //need to decide what our standards will be for this... how does the player get an S rank? Is it a combination of how many roaches they kill, how long they take, how many points they get?
        //this simple implementation can be adjusted to whatever we want it to be
        //# of roaches killed will be 30% of the score (300), time taken will be 20% (200), and score will be 50% (500)
        //the max value needed for an S rank will be 1000 for now\

        int final_percentage = ((killPoints + totalScore + (200 - ((int)Time.time)/60)) / max_value)*100;

        if(final_percentage <= 60)
        {
            rank = 0;
        }
        else if(final_percentage <= 70)
        {
            rank = 1;
        }
        else if(final_percentage <= 80)
        {
            rank = 2;
        }
        else if(final_percentage <= 90)
        {
            rank = 3;
        }
        else if(final_percentage == 100)
        {
            rank = 4;
        }



        return rank;
    }
}
