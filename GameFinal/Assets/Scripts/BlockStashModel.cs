using UnityEngine;
using System.Collections;
using UnityEngine.Events;
public class BlockStashModel : MonoBehaviour
{
	public Sprite empty;
	public Sprite full;
	public UnityEvent onPlayerClickNewBlock;
	public UnityEvent onPlayerClickEmptyStash;
	//private bool isIncreaseBlockTime = true;
	public int MAX_NUM_OF_BLOCK_TO_ICREASE;
	private bool gameStarted;
	private bool noMoreBlocks = false;

	public static bool canDragFromStash = true;

	void OnMouseDown ()
	{
		if (!gameStarted && !LevelManager.isTutorialRunning && canDragFromStash) {
			onPlayerClickNewBlock.Invoke ();
		} 

		if (noMoreBlocks && canDragFromStash) {
			onPlayerClickEmptyStash.Invoke ();
		}
	}
	void Update ()
	{
		//if (LevelManager.numOfLeftBlocks == 0) {
		if (GameControl.control.numOfBlocks == 0) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = empty;
			noMoreBlocks = true;
		} else {
			gameObject.GetComponent<SpriteRenderer> ().sprite = full;
			noMoreBlocks = false;
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