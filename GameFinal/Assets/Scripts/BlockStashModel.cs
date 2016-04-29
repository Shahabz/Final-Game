using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class BlockStashModel : MonoBehaviour {

	public Sprite empty;
	public Sprite full;
	public UnityEvent onPlayerClickNewBlock;
	public static bool isIncreaseBlockTime = true;

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
		if(isIncreaseBlockTime && LevelManager.numOfBlocks < 5){	
			StartCoroutine (IncreaseTime());
		}
	}

	public void HandlePressStart(){
		LevelManager.numOfBlocks = LevelManager.numOfBlocks - (LevelManager.numOfAvailableBlocks - LevelManager.numOfLeftBlocks);
		LevelManager.numOfAvailableBlocks = Mathf.Min(LevelManager.numOfLevelBlocks,LevelManager.numOfBlocks);
	}

	public IEnumerator IncreaseTime ()
	{		
		isIncreaseBlockTime = false;
		yield return new WaitForSeconds (5f);
		LevelManager.numOfBlocks++;
		isIncreaseBlockTime = true;
		Debug.Log(isIncreaseBlockTime);
	}
}

  