using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	public GameObject goodJob;
	public GameObject newBlock;
	public GameObject currentNewBlock;
	public static int numOfBlocks = 2;
	public static int numOfLevelBlocks = 5;
	public static int numOfLeftBlocks = 5;
	public static int numOfAvailableBlocks = 5;
	public Text numOfTotalBlocks;
	public Text numOfAvailableLevelBlocks;

	// Use this for initialization
	void Start () {		
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
		}
	}
}
