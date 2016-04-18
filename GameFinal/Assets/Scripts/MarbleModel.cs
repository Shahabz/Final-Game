using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine.UI;

public class MarbleModel : MonoBehaviour
{

	public GameObject marble;
	public bool pressedStart;

	void Start ()
	{
		marble.transform.position = new Vector3 (-2f, -4f, 0f);
	}



	void Update ()
	{
		if (pressedStart)
			marble.transform.position = new Vector3 (marble.transform.position.x + 0.05f, marble.transform.position.y, 0);
	}
		
	public void HandleEnemyCollision ()
	{
		Debug.Log ("works");

	}

	public void HandlePressedStart ()
	{
		pressedStart = true;
	}
		
}