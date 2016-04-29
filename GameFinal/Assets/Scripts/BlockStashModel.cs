using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class BlockStashModel : MonoBehaviour {

	public Sprite empty;
	public Sprite full;
	public UnityEvent onPlayerClickNewBlock;

	void OnMouseDown () {
		onPlayerClickNewBlock.Invoke ();
	}

	void Update(){
		if (LevelManager.numOfBlocks == 0){
			gameObject.GetComponent<SpriteRenderer>().sprite = empty;
		}
		else{
			gameObject.GetComponent<SpriteRenderer>().sprite = full;
		}
	}
}
