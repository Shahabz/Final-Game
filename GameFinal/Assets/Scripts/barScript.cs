using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class barScript : MonoBehaviour {

	public Image bar;
	private float secondsOver = 0 ;
	public float NUM_OF_SECOND_TO_ADD_BLOCK = 5;
	private bool isIncreaseBar = true;
	public int MAX_NUM_OF_BLOCK_TO_ICREASE = 5;


	// Update is called once per frame
	void Update () {
		bar.fillAmount = secondsOver / (NUM_OF_SECOND_TO_ADD_BLOCK);
		if(isIncreaseBar && LevelManager.numOfBlocks < MAX_NUM_OF_BLOCK_TO_ICREASE){
		StartCoroutine (IncreaseBar());
		}
	}


	public IEnumerator IncreaseBar ()
	{		
		isIncreaseBar = false;
		yield return new WaitForSeconds (1f);
		if(secondsOver == NUM_OF_SECOND_TO_ADD_BLOCK){
			secondsOver = 0;
		}else {
			secondsOver++;
		}
		isIncreaseBar = true;
		if(secondsOver == NUM_OF_SECOND_TO_ADD_BLOCK){
		LevelManager.numOfBlocks++;
		LevelManager.numOfLeftBlocks = Mathf.Min(LevelManager.numOfBlocks - LevelManager.numOfUsedBlocks, LevelManager.numOfLevelBlocks - LevelManager.numOfUsedBlocks);
		}
	}
}
