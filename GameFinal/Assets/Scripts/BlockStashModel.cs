using UnityEngine;
using System.Collections;
using UnityEngine.Events;
public class BlockStashModel : MonoBehaviour
{
	public Sprite empty;
	public Sprite full;
	public UnityEvent onPlayerClickNewBlock;
	//private bool isIncreaseBlockTime = true;
	public int MAX_NUM_OF_BLOCK_TO_ICREASE;
	private bool gameStarted;

	void OnMouseDown ()
	{
		if (!gameStarted) {
			onPlayerClickNewBlock.Invoke ();
		}
	}
	void Update ()
	{
		//if (LevelManager.numOfLeftBlocks == 0) {
			if (LevelManager.numOfBlocks == 0) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = empty;
		} else {
			gameObject.GetComponent<SpriteRenderer> ().sprite = full;
		}
	}
	public void HandlePressStart ()
	{
		//LevelManager.numOfBlocks = LevelManager.numOfBlocks - LevelManager.numOfUsedBlocks;
		//LevelManager.numOfAvailableBlocks = Mathf.Min (LevelManager.numOfLevelBlocks - LevelManager.numOfUsedBlocks, LevelManager.numOfBlocks);
		//LevelManager.numOfUsedBlocks = 0;
		//isIncreaseBlockTime = true;
		gameStarted = true;
	}
}