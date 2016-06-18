using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
public class LevelManager : MonoBehaviour
{
	public GameObject goodJob;
	public GameObject newBlock;
	public GameObject currentNewBlock;
	public GameObject inventory;
	public GameObject blockInInventory;
	public static Stopwatch sw;
	//	public static float startTime;
	//	float endTime;
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
	public static bool isTutorialRunning = false;
	private bool tutorialIsOver = false;
	public GameObject starParticles;

	// Use this for initialization
	void Start ()
	{	
		inventory.GetComponent<SpriteRenderer>().enabled = true;
		blockInInventory.GetComponent<SpriteRenderer>().enabled = true;
		numOfTotalBlocks.GetComponent<Text> ().enabled = true;
		//nextBlockTime.GetComponent<Text> ().enabled = true;
		won = false;
		MarbleCollision.kindOfBlock = new int[3];
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
		if (isTutorialRunning){
			tutorialIsOver = false;
			startGame.enabled = false;
			pause.enabled = false;
		} else if (!isTutorialRunning && !tutorialIsOver) {
			startGame.enabled = true;
			pause.enabled = true;
			tutorialIsOver = true;
		}
		if (Input.GetMouseButton (0) && currentNewBlock) {
			currentNewBlock.transform.position = new Vector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, 
				Camera.main.ScreenToWorldPoint (Input.mousePosition).y, 10f); 
		}
		if (Input.GetMouseButtonUp (0) && currentNewBlock) {
			if (5.6f < currentNewBlock.transform.position.x && currentNewBlock.transform.position.x < 12f && -5.5f < currentNewBlock.transform.position.y && currentNewBlock.transform.position.y < -2.2f) {
				//Destroy (currentNewBlock.gameObject);
				BlockModel.inStash = true;
			}				
			currentNewBlock = null; 
		}
		numOfTotalBlocks.text = "x" + GameControl.control.numOfBlocks;
		if (GameControl.control.numOfBlocks < 10) {
			if (!won) {
				nextBlockTime.GetComponent<Text> ().enabled = true;
			}
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
		sw.Stop();
		won = true;
		GameControl.control.Save ();
		int currentLevel = getCurrentLeverIndex ();
		int levelPoints = GetPointInLevel (currentLevel, sw.Elapsed.TotalSeconds);
		StartCoroutine (levelCompleted (levelPoints, currentLevel));
	}
	public int GetPointInLevel (int level, double time)
	{		
		int numOfSmallBlock = MarbleCollision.kindOfBlock [0];
		int numOfRegularBlock = MarbleCollision.kindOfBlock [1];
		int numOfbigBlock = MarbleCollision.kindOfBlock [2];
//		UnityEngine.Debug.Log(numOfRegularBlock);
		int currentPoints = numOfSmallBlock * 1850 + numOfRegularBlock * 1400 + numOfbigBlock * 1100 + ((int)(time * 363));
		return currentPoints;
	}

	public IEnumerator levelCompleted (int levelPoints, int currentLevel)
	{
		yield return new WaitForSeconds (2f);

		nextBlockTime.GetComponent<Text>().enabled = false;

		BlockModel.levelCompleted = true;
		nextLevel.gameObject.SetActive (true);
		replayLevel.gameObject.SetActive (true);
		menu.gameObject.SetActive (true);
		pause.gameObject.SetActive (false);
		startGame.gameObject.SetActive (false);
		nextBlockTime.GetComponent<Text> ().enabled = false;
		numOfTotalBlocks.GetComponent<Text> ().enabled = false;
		scoreText.GetComponent<Text> ().enabled = true;
		circle.GetComponent<Image> ().enabled = false;
		zeroStar.GetComponent<Image> ().enabled = true;
		inventory.GetComponent<SpriteRenderer>().enabled = false;
		blockInInventory.GetComponent<SpriteRenderer>().enabled = false;
		Instantiate (goodJob, new Vector2 (0f, 0f), Quaternion.identity);
		int levelSars = GetNumOfStarsInLevel(levelPoints, currentLevel);
		StartCoroutine(ShowPoints(levelPoints, currentLevel));
		StartCoroutine(ChangeStar(levelSars));
		if( currentLevel < ChangeLevel.lastLevel) 
		{
			if (GameControl.control.starsArray [currentLevel] == -1) {
				GameControl.control.starsArray [currentLevel] = 0;
			}			
		}
	}

	public IEnumerator ShowPoints (int levelPoints, int currentLevel)
	{
		StartCoroutine (DelayCalculatePoints());
		int levelSars = GetNumOfStarsInLevel(levelPoints, currentLevel);			
		int i = 0;
		int x =(int)  ((levelPoints / ((levelSars * 0.2f) + ((levelSars - 1) * 0.5f))) * 0.01f);
		x = Mathf.Abs(x);
		do{
			scoreText.text = "" + i;
			i += x;
			yield return new WaitForSeconds(0.01f);
		} while(i <= levelPoints);			
	}

	public IEnumerator DelayCalculatePoints()
	{
		yield return new WaitForSeconds(1.4f);
	}

	public IEnumerator ChangeStar (int levelStars)
	{		
		zeroStar.GetComponent<Image> ().enabled = false;
		oneStar.GetComponent<Image> ().enabled = true;
		star.GetComponent<Image> ().enabled = true;
		star.GetComponent<RectTransform>().transform.position = new Vector3(-1.57f,3.24f,0f);
		int i = 0;
		do {
			yield return new WaitForSeconds (0.01f);
			star.GetComponent<RectTransform>().localScale += new Vector3(0.02f, 0.02f, 0f);

			//ADDEDCODE 
			Instantiate(starParticles, star.gameObject.transform.position, Quaternion.identity);

			i++;
		} while(i < 10);
		do {
			yield return new WaitForSeconds (0.01f);
			star.GetComponent<RectTransform>().localScale -= new Vector3(0.02f, 0.02f, 0f);
			i--;
		} while(i > 0);
		star.GetComponent<Image> ().enabled = false;
		yield return new WaitForSeconds (0.5f);
		if (levelStars > 1){ 
			oneStar.GetComponent<Image> ().enabled = false;
			twoStars.GetComponent<Image> ().enabled = true;
			star.GetComponent<Image> ().enabled = true;
			star.GetComponent<RectTransform>().transform.position = new Vector3(0f,3.46f,0f);

			do {
				yield return new WaitForSeconds (0.01f);
				star.GetComponent<RectTransform>().localScale += new Vector3(0.02f, 0.02f, 0f);

				//ADDEDCODE 
				Instantiate(starParticles, star.gameObject.transform.position, Quaternion.identity);

				i++;
			} while(i < 10);
			do {
				yield return new WaitForSeconds (0.01f);
				star.GetComponent<RectTransform>().localScale -= new Vector3(0.02f, 0.02f, 0f);
				i--;
			} while(i > 0);
			star.GetComponent<Image> ().enabled = false;
		}
		yield return new WaitForSeconds (0.5f);
		if (levelStars > 2){ 
			twoStars.GetComponent<Image> ().enabled = false;
			threeStars.GetComponent<Image> ().enabled = true;
			star.GetComponent<Image> ().enabled = true;
			star.GetComponent<RectTransform>().transform.position = new Vector3(1.6f,3.24f,0f);

			do {
				yield return new WaitForSeconds (0.01f);
				star.GetComponent<RectTransform>().localScale += new Vector3(0.02f, 0.02f, 0f);

				//ADDEDCODE 
				Instantiate(starParticles, star.gameObject.transform.position, Quaternion.identity);

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
		
	public static int getCurrentLeverIndex ()
	{
		Regex regex = new Regex(".+([0-9]+)$");
		Match match = regex.Match(Application.loadedLevelName);
		string  levelString = match.Groups[1].Value;
		int level = int.Parse(levelString);
		return level;
	}
	public void HandleClickedForAnotherBlock ()
	{		
		if (GameControl.control.numOfBlocks > 0) {
			currentNewBlock = (GameObject)Instantiate (newBlock, new Vector2 (-2.5f, -4.7f), Quaternion.identity);		
			GameControl.control.numOfBlocks--;
		}
	}

	public void HandlePressLevelsButton (int level)
	{
		level--;
		if (!won)
		{
			GameControl.control.numOfBlocks = GameControl.control.numOfBlocks + PauseMenuManager.activeBlocksCounter;
		}
		//TODO: return blocks to stash
		startGame.enabled = true;
		pause.enabled = true;
		BlockStashModel.canDragFromStash = true;
		DragScript.canDragBlock = true;
		PauseMenuManager.MenuIsOpen = false;
		LastPlacedBlocks.lastBlocksList = new List<BlockData> ();
		Application.LoadLevel ("Levels" + ((level / 10) + 1));
	}
	public void HandleMoveNextLevel (int level)
	{
		LastPlacedBlocks.lastBlocksList = new List<BlockData> ();
		Application.LoadLevel ("Level" + level);		
	}
	public int GetNumOfStarsInLevel (int points, int level)
	{
		int currentStars = 0;
		if (level == 1 || level == 2) {			
			if (points <= 0) {
				//Debug.Log("0");
//				ChangeLevel.starsArray [level - 1] = -1;
				GameControl.control.starsArray[level - 1] = -1;
			} else if (points >= 1 && points <= 499) {
				//Debug.Log("2");
//				ChangeLevel.starsArray [level - 1] = 0;
				GameControl.control.starsArray[level - 1] = 
					Mathf.Max(GameControl.control.starsArray[level - 1], 0);
			} else if (points >= 500 && points <= 999) {
				//Debug.Log("3");
//				ChangeLevel.starsArray [level - 1] = 1;
				GameControl.control.starsArray[level - 1] = 
					Mathf.Max(GameControl.control.starsArray[level - 1], 1);
				currentStars = 1;
			} else if (points >= 1000 && points <= 1499) {
				//Debug.Log("4");
//				ChangeLevel.starsArray [level - 1] = 2;
				GameControl.control.starsArray[level - 1] = 
					Mathf.Max(GameControl.control.starsArray[level - 1], 2);
				currentStars = 2;
			} else if (points >= 1500) {
				//Debug.Log("5");
//				ChangeLevel.starsArray [level - 1] = 3;
				GameControl.control.starsArray[level - 1] = 
					Mathf.Max(GameControl.control.starsArray[level - 1], 3);
				currentStars = 3;
			}
		} else if (level >= 3 || level <= 5) {
			if (points <= 0) {
//				ChangeLevel.starsArray [level - 1] = -1;
				GameControl.control.starsArray [level - 1] = -1; 
			} else if (points >= 1 && points <= 499) {
//				ChangeLevel.starsArray [level - 1] = 0;
				GameControl.control.starsArray[level - 1] = 
					Mathf.Max(GameControl.control.starsArray[level - 1], 0);
			} else if (points >= 500 && points <= 1499) {
//				ChangeLevel.starsArray [level - 1] = 1;
				GameControl.control.starsArray [level - 1] = 
					Mathf.Max (GameControl.control.starsArray [level - 1], 1);
				currentStars = 1;
			} else if (points >= 1500 && points <= 1899) {
//				ChangeLevel.starsArray [level - 1] = 2;
				GameControl.control.starsArray[level - 1] = 
					Mathf.Max (GameControl.control.starsArray [level - 1], 2);
				currentStars = 2;
			} else if (points >= 1900) {
//				ChangeLevel.starsArray [level - 1] = 3;
				GameControl.control.starsArray[level - 1] = 
					Mathf.Max (GameControl.control.starsArray [level - 1], 3);
				currentStars = 3;
			}
		} else if (level >= 6 && level <= 10) {
			if (points <= 0) {
//				ChangeLevel.starsArray [level - 1] = -1;
				GameControl.control.starsArray [level - 1] = -1;
			} else if (points >= 1 && points <= 999) {
//				ChangeLevel.starsArray [level - 1] = 0;
				GameControl.control.starsArray [level - 1] = 
					Mathf.Max (GameControl.control.starsArray [level - 1], 0);
			} else if (points >= 1000 && points <= 1799) {
//				ChangeLevel.starsArray [level - 1] = 1;
				GameControl.control.starsArray [level - 1] = 
					Mathf.Max (GameControl.control.starsArray [level - 1], 1);
				currentStars = 1;
			} else if (points >= 1800 && points <= 1999) {
//				ChangeLevel.starsArray [level - 1] = 2;
				GameControl.control.starsArray [level - 1] = 
					Mathf.Max (GameControl.control.starsArray [level - 1], 2);
				currentStars = 2;
			} else if (points >= 2000) {
//				ChangeLevel.starsArray [level - 1] = 3;
				GameControl.control.starsArray [level - 1] = 
					Mathf.Max (GameControl.control.starsArray [level - 1], 3);
				currentStars = 3;
			}
		} else if (level >= 11 && level <= 20) {			
		}
		return currentStars;
	}
}