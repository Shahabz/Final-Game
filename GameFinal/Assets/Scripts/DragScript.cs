using UnityEngine;
using System.Collections;

public class DragScript : MonoBehaviour {

	//float distance = 10;
	private static bool gameStarted = false;
	private Vector3 distance;

	void Start () {
		gameStarted = false;
	}



	void OnMouseDown()
	{
		distance = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,0)) - transform.position;
	}

	void OnMouseDrag()
	{
		if (!BlockModel.twoFingers && !gameStarted) {
			Vector3 distance_to_screen = Camera.main.WorldToScreenPoint (gameObject.transform.position);
			Vector3 pos_move = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance_to_screen.z));
			transform.position = new Vector3 (pos_move.x - distance.x, pos_move.y - distance.y, pos_move.z);
		}
	}

//	void OnMouseDown ()
//	{
//		OnMouseDrag ();
//	}
//
//	void OnMouseDrag()
//	{	
//		if (!BlockModel.twoFingers && !gameStarted) {
//			Vector3 mousePosiotion = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance);
//			Vector3 objPosition = Camera.main.ScreenToWorldPoint (mousePosiotion);
//			transform.position = objPosition;
//		}
//	}
		

	public void HandleGameStarted ()
	{
		gameStarted = true;
	}
}
