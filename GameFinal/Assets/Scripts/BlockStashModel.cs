using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class BlockStashModel : MonoBehaviour {

	public Sprite empty;
	public Sprite full;
	public UnityEvent onPlayerClickNewBlock;
	private bool isIncreaseBlockTime = true;
	public int MAX_NUM_OF_BLOCK_TO_ICREASE;

	void OnMouseDown () {
		onPlayerClickNewBlock.Invoke ();
	}
		
	void Update(){

		if (LevelManager.numOfLeftBlocks == 0){
			gameObject.GetComponent<SpriteRenderer>().sprite = empty;
		}
		else{
			gameObject.GetComponent<SpriteRenderer>().sprite = full;
		}
		if(isIncreaseBlockTime && (LevelManager.numOfBlocks < MAX_NUM_OF_BLOCK_TO_ICREASE)){				
			StartCoroutine (IncreaseTime());
		}
	}

	public void HandlePressStart(){
		LevelManager.numOfBlocks = LevelManager.numOfBlocks - (LevelManager.numOfAvailableBlocks - LevelManager.numOfLeftBlocks);
		LevelManager.numOfAvailableBlocks = Mathf.Min(LevelManager.numOfLevelBlocks - LevelManager.numOfUsedBlocks,LevelManager.numOfBlocks);
		isIncreaseBlockTime = true;
		Debug.Log(isIncreaseBlockTime);

	}

	public IEnumerator IncreaseTime ()
	{		
		isIncreaseBlockTime = false;
		yield return new WaitForSeconds (5f);

			//MOVE TO BAR SCRIPT
		//LevelManager.numOfBlocks++;
		//LevelManager.numOfLeftBlocks = Mathf.Min(LevelManager.numOfBlocks - LevelManager.numOfUsedBlocks, LevelManager.numOfLevelBlocks - LevelManager.numOfUsedBlocks);
		isIncreaseBlockTime = true;
	}
}

  