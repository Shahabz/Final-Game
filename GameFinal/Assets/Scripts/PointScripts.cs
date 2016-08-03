using UnityEngine;
using System.Collections;

public class PointScripts : MonoBehaviour
{

	public static int currentPoints;
	public static int currentStars;


	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}



	public static void setPointInLevel (int level, double time)
	{		
		int numOfSmallBlock = MarbleCollision.kindOfBlock [0];
		int numOfRegularBlock = MarbleCollision.kindOfBlock [1];
		int numOfbigBlock = MarbleCollision.kindOfBlock [2];

		currentPoints = numOfSmallBlock * 1850 + numOfRegularBlock * 1400 + numOfbigBlock * 1100 + ((int)(time * 363));

		Debug.Log("Time" + time);

		setNumOfStarsInLevel (currentPoints, level);

		if( level < ChangeLevel.lastLevel) 
		{
			if (GameControl.control.starsArray [level] == -1) {
				GameControl.control.starsArray [level] = 0;
			}			
		}
	}

	public static void setNumOfStarsInLevel (int points, int level)
	{
		if (level == 1) {			
			if (points >= 1500) {
				GameControl.control.starsArray [level - 1] = 
					Mathf.Max (GameControl.control.starsArray [level - 1], 3);
				currentStars = 3;
			}
		} else if (level == 2 || level == 3) {
			if (points >= 1650 && points <= 1749) {
				GameControl.control.starsArray [level - 1] = 
					Mathf.Max (GameControl.control.starsArray [level - 1], 2);
				currentStars = 2;
			} else if (points >= 1750) {
				GameControl.control.starsArray [level - 1] = 
					Mathf.Max (GameControl.control.starsArray [level - 1], 3);
				currentStars = 3;
			}
		} else if (level == 4 && level == 5) {

			if (points <= 0) {
				ChangeLevel.starsArray [level - 1] = -1;
				GameControl.control.starsArray [level - 1] = -1; 

			} else if (points >= 1 && points <= 1599) {
				ChangeLevel.starsArray [level - 1] = 0;
				GameControl.control.starsArray [level - 1] = 
					Mathf.Max (GameControl.control.starsArray [level - 1], 0);
			} else if (points >= 1600 && points <= 1749) {
				GameControl.control.starsArray [level - 1] = 
					Mathf.Max (GameControl.control.starsArray [level - 1], 1);
				currentStars = 1;
			} else if (points >= 1750 && points <= 2199) {
				GameControl.control.starsArray [level - 1] = 
					Mathf.Max (GameControl.control.starsArray [level - 1], 2);
				currentStars = 2;
			} else if (points >= 2200) {
				GameControl.control.starsArray [level - 1] = 
					Mathf.Max (GameControl.control.starsArray [level - 1], 3);
				currentStars = 3;
			}
		} else if (level >= 6 && level <= 13 || level == 18 || level == 17) {

			if (points <= 0) {
				ChangeLevel.starsArray [level - 1] = -1;
				GameControl.control.starsArray [level - 1] = -1; 

			} else if (points >= 1 && points <= 1599) {
				ChangeLevel.starsArray [level - 1] = 0;
				GameControl.control.starsArray [level - 1] = 
					Mathf.Max (GameControl.control.starsArray [level - 1], 0);
			} else if (points >= 1600 && points <= 1899) {
				GameControl.control.starsArray [level - 1] = 
					Mathf.Max (GameControl.control.starsArray [level - 1], 1);
				currentStars = 1;
			} else if (points >= 1900 && points <= 2199) {
				GameControl.control.starsArray [level - 1] = 
					Mathf.Max (GameControl.control.starsArray [level - 1], 2);
				currentStars = 2;
			} else if (points >= 2200) {
				GameControl.control.starsArray [level - 1] = 
					Mathf.Max (GameControl.control.starsArray [level - 1], 3);
				currentStars = 3;
			}
		} else if (level == 15 || level == 16) {

			if (points <= 0) {
				ChangeLevel.starsArray [level - 1] = -1;
				GameControl.control.starsArray [level - 1] = -1; 

			} else if (points >= 1 && points <= 1599) {
				ChangeLevel.starsArray [level - 1] = 0;
				GameControl.control.starsArray [level - 1] = 
					Mathf.Max (GameControl.control.starsArray [level - 1], 0);
			} else if (points >= 1600 && points <= 3799) {
				GameControl.control.starsArray [level - 1] = 
					Mathf.Max (GameControl.control.starsArray [level - 1], 1);
				currentStars = 1;
			} else if (points >= 3800 && points <= 4399) {
				GameControl.control.starsArray [level - 1] = 
					Mathf.Max (GameControl.control.starsArray [level - 1], 2);
				currentStars = 2;
			} else if (points >= 4400) {
				GameControl.control.starsArray [level - 1] = 
					Mathf.Max (GameControl.control.starsArray [level - 1], 3);
				currentStars = 3;
			}
		} else if (level == 19 || level == 20) {

			if (points <= 0) {
				ChangeLevel.starsArray [level - 1] = -1;
				GameControl.control.starsArray [level - 1] = -1; 

			} else if (points >= 1 && points <= 1599) {
				ChangeLevel.starsArray [level - 1] = 0;
				GameControl.control.starsArray [level - 1] = 
					Mathf.Max (GameControl.control.starsArray [level - 1], 0);
			} else if (points >= 1600 && points <= 4999) {
				GameControl.control.starsArray [level - 1] = 
					Mathf.Max (GameControl.control.starsArray [level - 1], 1);
				currentStars = 1;
			} else if (points >= 5000 && points <= 5799) {
				GameControl.control.starsArray [level - 1] = 
					Mathf.Max (GameControl.control.starsArray [level - 1], 2);
				currentStars = 2;
			} else if (points >= 5800) {
				GameControl.control.starsArray [level - 1] = 
					Mathf.Max (GameControl.control.starsArray [level - 1], 3);
				currentStars = 3;
			}
		}
	}
}
