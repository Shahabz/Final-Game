using UnityEngine;
using System.Collections;

public class InventoryBlockstatusSrips : MonoBehaviour
{

	public Sprite empty;
	public Sprite full;


	
	// Update is called once per frame
	void Update ()
	{
		if (GameControl.control.numOfBlocks > 0) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = full;
		} else {
			gameObject.GetComponent<SpriteRenderer> ().sprite = empty;
		}
	}
}
