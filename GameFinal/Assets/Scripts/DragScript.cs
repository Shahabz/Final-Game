using UnityEngine;
using System.Collections;

public class DragScript : MonoBehaviour {

	float distance = 10;
	private static bool gameStarted = false;

	void Start () {
		gameStarted = false;
	}

	void OnMouseDown ()
	{
		OnMouseDrag ();
	}

	void OnMouseDrag()
	{	
		if (!BlockModel.twoFingers && !gameStarted) {
			Vector3 mousePosiotion = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance);
			Vector3 objPosition = Camera.main.ScreenToWorldPoint (mousePosiotion);
			transform.position = objPosition;
		}
	}
		

	public void HandleGameStarted ()
	{
		gameStarted = true;
	}
}
