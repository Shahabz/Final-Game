using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine.UI;

public class MarbleModel : MonoBehaviour
{

	public GameObject marble;

	void Start ()
	{
		marble.transform.position = new Vector3 (-2f, -2f, 0f);
	}



	void Update ()
	{
		
	}
		
	public void HandleEnemyCollision ()
	{
		marble.transform.rotation = Quaternion.Euler (marble.transform.rotation.x, marble.transform.rotation.y, 50f);
	}
		
}