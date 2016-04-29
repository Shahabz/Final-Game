using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	public GameObject goodJob;
	public GameObject newBlock;
	public GameObject currentNewBlock;

	public int NUM_OF_LEVEL_BLOCKS;
	public int NUM_OF_SECOND_TO_ADD_BLOCK;

	public static int numOfBlocks = 2;
	public static int numOfLevelBlocks;
	public static int numOfLeftBlocks;
	public static int numOfAvailableBlocks;
	public static int numOfUsedBlocks = 0;

	public Text numOfTotalBlocks;
	public Text numOfAvailableLevelBlocks;

	// Use this for initialization
	void Start () {		
		numOfLevelBlocks = NUM_OF_LEVEL_BLOCKS;
		numOfAvailableBlocks = Mathf.Min(numOfLevelBlocks,numOfBlocks);
		numOfLeftBlocks = numOfAvailableBlocks;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0) && currentNewBlock){
			currentNewBlock.transform.position = new Vector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, 
				Camera.main.ScreenToWorldPoint (Input.mousePosition).y, 10f); 
		}
		if(Input.GetMouseButtonUp(0) && currentNewBlock){
			currentNewBlock = null;
		}
		numOfTotalBlocks.text = "" + numOfBlocks;
		numOfAvailableLevelBlocks.text = "" + numOfLeftBlocks;
		//numOfAvailableBlocks = Mathf.Min(numOfLevelBlocks,numOfBlocks);
	}	

	public void HandleOutOfBounds()
	{
		Application.LoadLevel (Application.loadedLevel);
	}

	public void HandleWinLevel() {
		Instantiate (goodJob, new Vector2(0f,0f), Quaternion.identity);
	}

	public void HandleClickedForAnotherBlock() {
		if (numOfLeftBlocks > 0){
		currentNewBlock = (GameObject) Instantiate (newBlock, new Vector2 (-2.5f, -4.7f), Quaternion.identity);		
			numOfLeftBlocks--;
			numOfUsedBlocks++;
		}
	}
}
