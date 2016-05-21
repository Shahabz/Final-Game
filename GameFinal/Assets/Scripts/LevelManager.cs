﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;



public class LevelManager : MonoBehaviour
{
	public GameObject goodJob;
	public GameObject newBlock;
	public GameObject currentNewBlock;
	public static int numOfBlocks = 3;
	//public static string[] blocksSizes;
	public Text scoreText;
	public Text numOfTotalBlocks;
	public Text numOfAvailableLevelBlocks;
	public Text nextBlockTime;
	public Button nextLevel;
	public static int minutesForNextBlock = 0;
	public static int secondsForNextBlock = 11;
	private bool isChangeFillTime;
		

	// Use this for initialization
	void Start ()
	{	
		MarbleCollision.kindOfBlock = new int[3];
//		secondsForNextBlock = 11;
//		minutesForNextBlock = 0;
		isChangeFillTime = true;
		nextLevel.gameObject.SetActive (false);
		scoreText.GetComponent<Text> ().enabled = false;
	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButton (0) && currentNewBlock) {
			currentNewBlock.transform.position = new Vector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, 
				Camera.main.ScreenToWorldPoint (Input.mousePosition).y, 10f); 
		}
		if (Input.GetMouseButtonUp (0) && currentNewBlock) {
			if (7.15f < currentNewBlock.transform.position.x && currentNewBlock.transform.position.x < 8.62f && -4.75f < currentNewBlock.transform.position.y && currentNewBlock.transform.position.y < -3.24f) {
				//Destroy (currentNewBlock.gameObject);
				BlockModel.inStash = true;
			}
			currentNewBlock = null; 
		}
		numOfTotalBlocks.text = "x" + numOfBlocks;
		if(secondsForNextBlock < 10){
			nextBlockTime.text = "More in "+ minutesForNextBlock + ":" + "0" + secondsForNextBlock ;
		}else{
			nextBlockTime.text = "More in "+ minutesForNextBlock + ":" + secondsForNextBlock;
		}
		if(isChangeFillTime){
		StartCoroutine (FillCircle ());
		}
	}

	public IEnumerator FillCircle ()
	{
		isChangeFillTime = false;
		yield return new WaitForSeconds (1f);
		if (0 == secondsForNextBlock) {
			if(numOfBlocks < barScript.MAX_NUM_OF_BLOCK_TO_ICREASE){
			secondsForNextBlock = 59;
			if(minutesForNextBlock == 0){				
				minutesForNextBlock = 2;			
				secondsForNextBlock = 0;
				
			}else{
				minutesForNextBlock--;
			}
		}
		}else{			
			secondsForNextBlock--;			
		}
		isChangeFillTime = true;
	}


	public void HandleOutOfBounds ()
	{
		Application.LoadLevel (Application.loadedLevel);
	}

	public void HandleWinLevel ()
	{
		GameControl.control.Save ();
		nextLevel.gameObject.SetActive (true);
//		PointsCalc ();
		//Debug.Log(getCurrentLeverIndex());
		PointScripts.setPointInLevel(getCurrentLeverIndex());
		Instantiate (goodJob, new Vector2 (0f, 0f), Quaternion.identity);
	}

	public static int getCurrentLeverIndex(){
		string levelName = Application.loadedLevelName;
		switch(levelName){
		case"Level1":
			return 1;
		case"Level2":
			return 2;
		case"Level3":
			return 3;
		case"Level4":
			return 4;
		case"Level5":
			return 5;
		case"Level6":
			return 6;
		case"Level7":
			return 7;
		case"Level8":
			return 8;
		case"Level9":
			return 9;
		case"Level10":
			return 10;
		}			
		return 1;
	}


	public void HandleClickedForAnotherBlock ()
	{		
		if (numOfBlocks > 0) {
			currentNewBlock = (GameObject)Instantiate (newBlock, new Vector2 (-2.5f, -4.7f), Quaternion.identity);		
			numOfBlocks--;
		}
	}



	public void PointsCalc ()
	{
		int points = 10000;
		int decreaseBig = 9900 / 10;
		int decreaseRegular = (int)(0.75 * decreaseBig);
		int decreaseSmall = decreaseBig / 2;
		int count = 0;
	//	for (int i = 0; i < blocksSizes.Length; i++) {
	//		if (blocksSizes [i].Equals ("big")) {
	//			points -= decreaseBig;
	//			count++;
	//		} else if (blocksSizes [i].Equals ("regular")) {
	//			points -= decreaseRegular;
	//			count++;
	//		} else if (blocksSizes [i].Equals ("small")) {
	//			points -= decreaseSmall;
	//			count++;
	//		}
	//	}
		if (count == 1) {
			points += decreaseSmall;
		}
		scoreText.GetComponent<Text> ().enabled = true;
		scoreText.text += " " + points;
	}

	public void HandlePressLevelsButton(){
		LastPlacedBlocks.lastBlocksList = new List<BlockData> ();
		Application.LoadLevel ("Levels");
	}

	public void HandleMoveNextLevel (int level)
	{
		LastPlacedBlocks.lastBlocksList = new List<BlockData> ();
		Application.LoadLevel ("Level" + level);		
	}
}