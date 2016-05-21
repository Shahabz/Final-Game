using UnityEngine;
using System.Collections;

public class PointScripts : MonoBehaviour
{
	
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}



	public static void setPointInLevel (int level)
	{
		int currentPoints = 0;
		int numOfSmallBlock = MarbleCollision.kindOfBlock [0];
		int numOfRegularBlock = MarbleCollision.kindOfBlock [1];
		int numOfbigBlock = MarbleCollision.kindOfBlock [2];
		if (level == 1) {
			currentPoints = numOfSmallBlock * 4000 + numOfRegularBlock * 3000 + numOfbigBlock * 1000;
		} else if (level >= 2 || level <= 5) {
			currentPoints = numOfSmallBlock * 5000 + numOfRegularBlock * 3000 + numOfbigBlock * 2000;
		} else if (level >= 6 || level <= 10) {
			currentPoints = numOfSmallBlock * 7000 + numOfRegularBlock * 4000 + numOfbigBlock * 3000;
		} else if (level >= 11 || level <= 20) {			
		}

		setNumOfStarsInLevel (currentPoints, level);
	}

	public static void setNumOfStarsInLevel (int points, int level)
	{

		if (level == 1) {
			if (points <= 0) {
				ChangeLevel.starsArray [level - 1] = -1;
				GameControl.control.starsArray[level - 1] = -1;

			} else if (points >= 1 || points <= 999) {
				ChangeLevel.starsArray [level - 1] = 0;
				GameControl.control.starsArray[level - 1] = 0;

			} else if (points >= 1000 || points <= 1999) {
				ChangeLevel.starsArray [level - 1] = 1;
				GameControl.control.starsArray[level - 1] = 1;

			} else if (points >= 2000 || points <= 2999) {
				ChangeLevel.starsArray [level - 1] = 2;
				GameControl.control.starsArray[level - 1] = 2;

			} else if (points >= 3000) {
				ChangeLevel.starsArray [level - 1] = 3;
				GameControl.control.starsArray[level - 1] = 3;
			}
		} else if (level >= 2 || level <= 5) {
			
			if (points <= 0) {
				ChangeLevel.starsArray [level - 1] = -1;
				GameControl.control.starsArray[level - 1] = -1;

			} else if (points >= 1 || points <= 1999) {
				ChangeLevel.starsArray [level - 1] = 0;
				GameControl.control.starsArray[level - 1] = 0;
			} else if (points >= 2000 || points <= 2999) {
				ChangeLevel.starsArray [level - 1] = 1;
				GameControl.control.starsArray[level - 1] = 1;

			} else if (points >= 3000 || points <= 4999) {
				ChangeLevel.starsArray [level - 1] = 2;
				GameControl.control.starsArray[level - 1] = 2;

			} else if (points >= 5000) {
				ChangeLevel.starsArray [level - 1] = 3;
				GameControl.control.starsArray[level - 1] = 3;
			}
			
		} else if (level >= 6 || level <= 10) {
			
			if (points <= 0) {
				ChangeLevel.starsArray [level - 1] = -1;
				GameControl.control.starsArray[level - 1] = -1;

			} else if (points >= 1 || points <= 2999) {
				ChangeLevel.starsArray [level - 1] = 0;
				GameControl.control.starsArray[level - 1] = 0;

			} else if (points >= 3000 || points <= 3999) {
				ChangeLevel.starsArray [level - 1] = 1;
				GameControl.control.starsArray[level - 1] = 1;

			} else if (points >= 4000 || points <= 6999) {
				ChangeLevel.starsArray [level - 1] = 2;
				GameControl.control.starsArray[level - 1] = 2;

			} else if (points >= 7000) {
				ChangeLevel.starsArray [level - 1] = 3;
				GameControl.control.starsArray[level - 1] = 3;
			}
			
		} else if (level >= 11 || level <= 20) {			

		}
	}
}
