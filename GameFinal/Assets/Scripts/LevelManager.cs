using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{
	public GameObject goodJob;
	public GameObject newBlock;
	public GameObject currentNewBlock;
	public int NUM_OF_LEVEL_BLOCKS;
	public static int numOfBlocks = 2;
	public static int numOfLevelBlocks;
	public static int numOfLeftBlocks;
	public static int numOfAvailableBlocks;
	public static int numOfUsedBlocks = 0;
	public static string[] blocksSizes;
	public Text scoreText;
	public Text numOfTotalBlocks;
	public Text numOfAvailableLevelBlocks;
	// Use this for initialization
	void Start ()
	{	
		scoreText.GetComponent<Text> ().enabled = false;
		numOfLevelBlocks = NUM_OF_LEVEL_BLOCKS;
		numOfAvailableBlocks = Mathf.Min (numOfLevelBlocks, numOfBlocks);
		numOfLeftBlocks = numOfAvailableBlocks;
		blocksSizes = new string[numOfLevelBlocks];
		for (int i = 0; i < blocksSizes.Length; i++) {
			blocksSizes [i] = "";
		}
	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButton (0) && currentNewBlock) {
			currentNewBlock.transform.position = new Vector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, 
				Camera.main.ScreenToWorldPoint (Input.mousePosition).y, 10f); 
		}
		if (Input.GetMouseButtonUp (0) && currentNewBlock) {
			currentNewBlock = null;
		}
		numOfTotalBlocks.text = "" + numOfBlocks;
		numOfAvailableLevelBlocks.text = "" + numOfLeftBlocks;
	}
	public void HandleOutOfBounds ()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
	public void HandleWinLevel ()
	{
		PointsCalc ();
		Instantiate (goodJob, new Vector2 (0f, 0f), Quaternion.identity);
	}
	public void HandleClickedForAnotherBlock ()
	{
		if (numOfLeftBlocks > 0) {
			currentNewBlock = (GameObject)Instantiate (newBlock, new Vector2 (-2.5f, -4.7f), Quaternion.identity);		
			numOfLeftBlocks--;
			numOfUsedBlocks++;
		}
	}
	public void PointsCalc ()
	{
		int points = 10000;
		int decreaseBig = 9900 / numOfLevelBlocks;
		int decreaseRegular = (int)(0.75 * decreaseBig);
		int decreaseSmall = decreaseBig / 2;
		int count = 0;
		for (int i = 0; i < blocksSizes.Length; i++) {
			if (blocksSizes [i].Equals ("big")) {
				points -= decreaseBig;
				count++;
			} else if (blocksSizes [i].Equals ("regular")) {
				points -= decreaseRegular;
				count++;
			} else if (blocksSizes [i].Equals ("small")) {
				points -= decreaseSmall;
				count++;
			}
		}
		if (count == 1) {
			points += decreaseSmall;
		}
		scoreText.GetComponent<Text> ().enabled = true;
		;
		scoreText.text += " " + points;
	}
}