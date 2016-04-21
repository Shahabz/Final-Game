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
		if (pressedStart) {
			
			// uses addforce to push the marble so that the physics works, only needs to do this once 
			// has to be in the direction of the vector that the marble arrow points to (for now set to right
			// as arrow is set pointing right)
			marble.GetComponent<Rigidbody2D>().AddForce(transform.right * 90f);
			pressedStart = false;
		}
	}
		
	public void HandleDestinationCollision ()
	{
		// freezes marble once it has reached its destination
		marble.GetComponent<Rigidbody2D> ().isKinematic = true;

		// insert win level and transition
	}

	public void HandlePressedStart ()
	{
		pressedStart = true;
	}
		
}