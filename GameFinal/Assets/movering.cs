using UnityEngine;
using System.Collections;

public class movering : MonoBehaviour
{
	private GameObject ring;

	private bool isPressed = false; 

	void OnMouseDown ()
	{
		isPressed = true;
		Destroy (ring);
		ring = Instantiate (Resources.Load ("ring"), new Vector2 (transform.position.x, transform.position.y), Quaternion.identity) as GameObject;		
	}

	void Update()
	{
		if(isPressed) 
		{
			ring.transform.position = transform.position;
			transform.rotation = ring.transform.rotation;
		}
	}
}
