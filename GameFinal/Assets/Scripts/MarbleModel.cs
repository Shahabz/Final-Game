using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine.UI;

public class MarbleModel : MonoBehaviour
{

	public GameObject marble;
	public GameObject arrow;
	public bool pressedStart;
	public Vector2 arrowDirection;
	public float marbleSpeed;
	public UnityEvent outOfBounds;

	void Start ()
	{
		marble.GetComponent<Rigidbody2D> ().isKinematic = true;
		//marble.transform.position = new Vector3 (-2f, -3f, 0f);
	}

	void Update ()
	{
		if (pressedStart) {
			
			// uses addforce to push the marble so that the physics works, only needs to do this once 
			// arrowDirection coordinates the direction is shot with the arrow direction
			// speed of marble can be set by changing the marbleSpeed

			arrowDirection = arrow.transform.right;
			marbleSpeed = 90f;
			marble.GetComponent<Rigidbody2D>().AddForce(arrowDirection * marbleSpeed);
			pressedStart = false;
		}

		if (marble.transform.position.x < -3.8f || marble.transform.position.x > 3.8f ||
		    marble.transform.position.y < -5.5f || marble.transform.position.y > 5.5f) {
			outOfBounds.Invoke ();
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
		StartCoroutine (WaitToStart ());
		//pressedStart = true;
		//marble.GetComponent<Rigidbody2D> ().isKinematic = false;
	}

	public IEnumerator WaitToStart () {
		yield return new WaitForSeconds (0.02f);
		pressedStart = true;
		marble.GetComponent<Rigidbody2D> ().isKinematic = false;
	}
}