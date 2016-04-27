using UnityEngine;
using System.Collections;

public class DragScript : MonoBehaviour {

	float distance = 10;

	void OnMouseDrag()
	{
		
		Vector3 mousePosiotion = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
		Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosiotion);
		transform.position = objPosition;

	}


}
