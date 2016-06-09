using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;



public class LevelManager : MonoBehaviour
{
	public GameObject goodJob;
	public GameObject newBlock;
	public GameObject currentNewBlock;
	public GameObject inventory;
	public GameObject blockInInventory;
	public static float startTime;
	float endTime;
	//public static int numOfBlocks = 20;
	//public static string[] blocksSizes;
	public Text scoreText;
	public Text numOfTotalBlocks;
	public Text numOfAvailableLevelBlocks;
	public Text nextBlockTime;
	public Button nextLevel;
	public Button replayLevel;
	public Button menu;
	public Button startGame;
	public Button pause;
	public Image threeStars;
	public Image twoStars;
	public Image oneStar;
	public Image zeroStar;
	public Image star;
	public Image circle;

	public static int minutesForNextBlock = 2;
	public static int secondsForNextBlock = 0;
	private bool isChangeFillTime;
	private bool won;
	private bool changeStar;


		

	// Use this for initialization
	void Start ()
	{	
		inventory.GetComponent<SpriteRenderer>().enabled = true;
		blockInInventory.GetComponent<SpriteRenderer>().enabled = true;
		numOfTotalBlocks.GetComponent<Text> ().enabled = true;
		//nextBlockTime.GetComponent<Text> ().enabled = true;
		won = false;
		MarbleCollision.kindOfBlock = new int[3];
//		secondsForNextBlock = 11;
//		minutesForNextBlock = 0;
		isChangeFillTime = true;
		nextLevel.gameObject.SetActive (false);
		replayLevel.gameObject.SetActive (false);
		menu.gameObject.SetActive (false);
		pause.gameObject.SetActive (true);
		startGame.gameObject.SetActive (true);
		scoreText.GetComponent<Text> ().enabled = false;
		threeStars.GetComponent<Image> ().enabled = false;
		twoStars.GetComponent<Image> ().enabled = false;
		oneStar.GetComponent<Image> ().enabled = false;
		zeroStar.GetComponent<Image> ().enabled = false;
		star.GetComponent<Image> ().enabled = false;
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
		numOfTotalBlocks.text = "x" + GameControl.control.numOfBlocks;

		if (GameControl.control.numOfBlocks < 10) {
			nextBlockTime.GetComponent<Text> ().enabled = true;
			if (secondsForNextBlock < 10) {
				nextBlockTime.text = "More in " + minutesForNextBlock + ":" + "0" + secondsForNextBlock;
			} else {
				nextBlockTime.text = "More in " + minutesForNextBlock + ":" + secondsForNextBlock;
			}
			if (isChangeFillTime) {
				StartCoroutine (FillCircle ());
			}
		} else {
			nextBlockTime.GetComponent<Text> ().enabled = false;
			barScript.secondsOver = 0;
			minutesForNextBlock = 2;
			secondsForNextBlock = 0;
		}
			

	}

	public IEnumerator FillCircle ()
	{
		isChangeFillTime = false;
		yield return new WaitForSeconds (1f);
		if (0 == secondsForNextBlock) {
			if (GameControl.control.numOfBlocks < barScript.MAX_NUM_OF_BLOCK_TO_ICREASE) {
				secondsForNextBlock = 59;
				if (minutesForNextBlock == 0) {				
					minutesForNextBlock = 2;			
					secondsForNextBlock = 0;
				
				} else {
					minutesForNextBlock--;
				}
			}
		} else {			
			secondsForNextBlock--;			
		}
		isChangeFillTime = true;
	}


	public void HandleOutOfBounds ()
	{
		if (!won) {
			GameControl.control.Save ();
			Application.LoadLevel (Application.loadedLevel);
		}
	}

	public void HandleWinLevel ()
	{
		endTime = Time.deltaTime;
//		Debug.Log(endTime);
//		Debug.Log(endTime - startTime);
		won = true;
		GameControl.control.Save ();
//		PointsCalc ();
		//Debug.Log(getCurrentLeverIndex());
		PointScripts.setPointInLevel (getCurrentLeverIndex (), endTime - startTime );
		//scoreText.text = "" + PointScripts.currentPoints;
		StartCoroutine(ShowPoints());
		StartCoroutine (levelCompleted ());
		//	Instantiate (goodJob, new Vector2 (0f, 0f), Quaternion.identity);
	}

	public IEnumerator ShowPoints ()
	{
		int i = 0;
		Debug.Log(PointScripts.currentPoints);
		do{
			scoreText.text = "" + i;
			i += 15;
			yield return new WaitForSeconds(0.01f);
		} while(i <= PointScripts.currentPoints);
	}


	public IEnumerator levelCompleted ()
	{
		yield return new WaitForSeconds (2f);
		nextLevel.gameObject.SetActive (true);
		replayLevel.gameObject.SetActive (true);
		menu.gameObject.SetActive (true);
		pause.gameObject.SetActive (false);
		startGame.gameObject.SetActive (false);
		nextBlockTime.GetComponent<Text> ().enabled = false;
		numOfTotalBlocks.GetComponent<Text> ().enabled = false;
		scoreText.GetComponent<Text> ().enabled = true;
		printStarsImage (PointScripts.currentStars);
		circle.GetComponent<Image> ().enabled = false;
		inventory.GetComponent<SpriteRenderer>().enabled = false;
		blockInInventory.GetComponent<SpriteRenderer>().enabled = false;
		Instantiate (goodJob, new Vector2 (0f, 0f), Quaternion.identity);
			
	}

	public IEnumerator ChangeStar (int levelStars)
	{		
		Debug.Log(" num of stars " + levelStars);
//		zeroStar.GetComponent<Image> ().enabled = true;
		oneStar.GetComponent<Image> ().enabled = true;
		star.GetComponent<Image> ().enabled = true;
//		Debug.Log(star.transform.position.x);
//		Debug.Log(star.transform.position.y);
		star.GetComponent<RectTransform>().transform.position = new Vector3(-1.57f,3.24f,0f);

		int i = 0;

		do {
			yield return new WaitForSeconds (0.01f);

			star.GetComponent<RectTransform>().localScale += new Vector3(0.02f, 0.02f, 0f);
			i++;
		} while(i < 10);

		do {
			yield return new WaitForSeconds (0.01f);

			star.GetComponent<RectTransform>().localScale -= new Vector3(0.02f, 0.02f, 0f);
			i--;
		} while(i > 0);

		star.GetComponent<Image> ().enabled = false;
		yield return new WaitForSeconds (0.2f);
		if (levelStars > 1){ 
		oneStar.GetComponent<Image> ().enabled = false;
		twoStars.GetComponent<Image> ().enabled = true;
		star.GetComponent<Image> ().enabled = true;
		star.GetComponent<RectTransform>().transform.position = new Vector3(0f,3.46f,0f);

		
		do {
			yield return new WaitForSeconds (0.01f);

			star.GetComponent<RectTransform>().localScale += new Vector3(0.02f, 0.02f, 0f);
			i++;
		} while(i < 10);

		do {
			yield return new WaitForSeconds (0.01f);

			star.GetComponent<RectTransform>().localScale -= new Vector3(0.02f, 0.02f, 0f);
			i--;
		} while(i > 0);
		star.GetComponent<Image> ().enabled = false;

		}

		yield return new WaitForSeconds (0.2f);
		if (levelStars > 2){ 
		twoStars.GetComponent<Image> ().enabled = false;
		threeStars.GetComponent<Image> ().enabled = true;
		star.GetComponent<Image> ().enabled = true;
		star.GetComponent<RectTransform>().transform.position = new Vector3(1.6f,3.24f,0f);

		
		do {
			yield return new WaitForSeconds (0.01f);

			star.GetComponent<RectTransform>().localScale += new Vector3(0.02f, 0.02f, 0f);
			i++;
		} while(i < 10);

		do {
			yield return new WaitForSeconds (0.01f);


			star.GetComponent<RectTransform>().localScale -= new Vector3(0.02f, 0.02f, 0f);
			i--;
		} while(i > 0);
		star.GetComponent<Image> ().enabled = false;
		}
	}

	public void printStarsImage (int numOfStars)
	{

		StartCoroutine(ChangeStar(numOfStars));

//		switch (numOfStars) {
//		case 1:
//			oneStar.GetComponent<Image> ().enabled = true;
//			break;
//		case 2:
//			twoStars.GetComponent<Image> ().enabled = true;
//			break;
//		case 3:
//			threeStars.GetComponent<Image> ().enabled = true;
//			break;
//		}

	}




	public IEnumerator ChangeStarScale ()
	{
		Debug.Log("4");
			int i = 0;

			do {
				yield return new WaitForSeconds (0.04f);
		
				star.GetComponent<RectTransform>().localScale += new Vector3(0.02f, 0.02f, 0f);
				i++;
			} while(i < 10);

			do {
				yield return new WaitForSeconds (0.04f);
		
				star.GetComponent<RectTransform>().localScale -= new Vector3(0.02f, 0.02f, 0f);
				i--;
			} while(i > 0);
			yield return new WaitForSeconds (3f);
					//star.transform.position = new Vector3(0f,148f,0f);
//		star.GetComponent<Image> ().enabled = false;
		changeStar = true;
			
	}

	public static int getCurrentLeverIndex ()
	{
		string levelName = Application.loadedLevelName;
		switch (levelName) {
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
		if (GameControl.control.numOfBlocks > 0) {
			currentNewBlock = (GameObject)Instantiate (newBlock, new Vector2 (-2.5f, -4.7f), Quaternion.identity);		
			GameControl.control.numOfBlocks--;
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

	public void HandlePressLevelsButton ()
	{
		LastPlacedBlocks.lastBlocksList = new List<BlockData> ();
		Application.LoadLevel ("Levels");
	}

	public void HandleMoveNextLevel (int level)
	{
		LastPlacedBlocks.lastBlocksList = new List<BlockData> ();
		Application.LoadLevel ("Level" + level);		
	}
		
}