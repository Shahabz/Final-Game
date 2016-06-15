using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Diagnostics;

public class MarbleModel : MonoBehaviour
{

	public GameObject marble;
	public GameObject arrow;
	public bool pressedStart;
	public Vector2 arrowDirection;
	public float marbleSpeed;
	public UnityEvent outOfBounds;
	private Animator marbleAnimator;
	public GameObject marbleTrail;

	void Start ()
	{
		marble.GetComponent<Rigidbody2D> ().isKinematic = true;
		marbleAnimator = marble.GetComponent<Animator> ();
		//marble.transform.position = new Vector3 (-2f, -3f, 0f);

		marbleTrail.GetComponent<ParticleSystem>().Pause();
	}

	void Update ()
	{
		if (pressedStart) {
			marbleAnimator.SetBool ("pressedStart", true);
			
			// uses addforce to push the marble so that the physics works, only needs to do this once 
			// arrowDirection coordinates the direction is shot with the arrow direction
			// speed of marble can be set by changing the marbleSpeed

			arrowDirection = arrow.transform.right;
			marbleSpeed = 90f;
			marble.GetComponent<Rigidbody2D>().AddForce(arrowDirection * marbleSpeed);
			pressedStart = false;
		}

		if (marble.transform.position.x < -10.96f || marble.transform.position.x > 10.96f ||
		    marble.transform.position.y < -6.8f || marble.transform.position.y > 6.5f) {
			outOfBounds.Invoke ();
		}
	}
		
	public void HandleDestinationCollision ()
	{
		// freezes marble once it has reached its destination
		//marble.GetComponent<Rigidbody2D> ().isKinematic = true;

		// insert win level and transition
	}

	public void HandlePressedStart ()
	{
		LevelManager.sw = new Stopwatch();
		LevelManager.sw.Start();
//		LevelManager.startTime = Time.deltaTime;
		//Debug.Log(LevelManager.startTime);
		StartCoroutine (WaitToStart ());
		//pressedStart = true;
		//marble.GetComponent<Rigidbody2D> ().isKinematic = false;

		marbleTrail.GetComponent<ParticleSystem>().Play();
	}

	public IEnumerator WaitToStart () {
		yield return new WaitForSeconds (0.02f);
		pressedStart = true;
		marble.GetComponent<Rigidbody2D> ().isKinematic = false;
	}
}