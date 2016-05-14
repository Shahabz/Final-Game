using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
	public GameObject goodJob;
	public GameObject newBlock;
	public GameObject currentNewBlock;
	//public int NUM_OF_LEVEL_BLOCKS;
	//public static int numOfBlocks = 10;
	//public static int numOfLevelBlocks;
	//public static int numOfLeftBlocks;
	//public static int numOfAvailableBlocks;
	//public static int numOfUsedBlocks = 0;
	public static int numOfBlocks = 10;
	//public static string[] blocksSizes;
	public Text scoreText;
	public Text numOfTotalBlocks;
	public Text numOfAvailableLevelBlocks;
	public Button nextLevel;
	public UnityEvent draggedABlock;

	// Use this for initialization
	void Start ()
	{	
		nextLevel.gameObject.SetActive (false);
		scoreText.GetComponent<Text> ().enabled = false;

		//blocksSizes = new string[numOfLevelBlocks];
		//for (int i = 0; i < blocksSizes.Length; i++) {
		//	blocksSizes [i] = "";
		//}
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
				BlockModel.stamCheck = true;
			}
			currentNewBlock = null; 
		}
		numOfTotalBlocks.text = "" + numOfBlocks;
		//numOfAvailableLevelBlocks.text = "" + numOfLeftBlocks + " / " + numOfLevelBlocks;
	}

	public void HandleOutOfBounds ()
	{
		Application.LoadLevel (Application.loadedLevel);
	}

	public void HandleWinLevel ()
	{
		nextLevel.gameObject.SetActive (true);
		PointsCalc ();
		Instantiate (goodJob, new Vector2 (0f, 0f), Quaternion.identity);
	}

	public void HandleClickedForAnotherBlock ()
	{
		//if (numOfLeftBlocks > 0) {
		//	currentNewBlock = (GameObject)Instantiate (newBlock, new Vector2 (-2.5f, -4.7f), Quaternion.identity);		
		//	numOfLeftBlocks--;
		//	numOfUsedBlocks++;
		//}

		if (numOfBlocks > 0) {
			currentNewBlock = (GameObject)Instantiate (newBlock, new Vector2 (-2.5f, -4.7f), Quaternion.identity);
			//draggedABlock.Invoke();	
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
		;
		scoreText.text += " " + points;
	}

	public void HandleMoveNextLevel ()
	{
		string levelName = Application.loadedLevelName;
		switch (levelName) {
		case "Level1":
			Application.LoadLevel ("Level2");
			break;

		case "Level2":
			Application.LoadLevel ("Level3");
			break;

		case "Level3":
			Application.LoadLevel ("Level4");
			break;

		case "Level4":
			Application.LoadLevel ("Level5");
			break;
		}
	}
}