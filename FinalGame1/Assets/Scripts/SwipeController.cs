using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;

public class SwipeController : MonoBehaviour {


	public UnityEvent onPlayerSwipeRight;
	public UnityEvent onPlayerSwipeLeft;

	private Vector2 fingerStart;
	private Vector2 fingerEnd;

	public int leftRight = 0;
	public int upDown = 0;



	public enum Movement
	{
		Left,
		Right, 
		Up,
		Down
	};

	public List<Movement> movements = new List<Movement>();




	void Update () {
		foreach(Touch touch in Input.touches)
		{

			if (touch.phase == TouchPhase.Began) {
				fingerStart = touch.position;
				//fingerEnd  = touch.position;
			}

			if(touch.phase == TouchPhase.Moved) {
				fingerEnd = touch.position;

				//There is more movement on the X axis than the Y axis
				if(Mathf.Abs(fingerStart.x - fingerEnd.x) > Mathf.Abs(fingerStart.y - fingerEnd.y)) {

					//Right Swipe
					if((fingerEnd.x - fingerStart.x) > 0)
						onPlayerSwipeRight.Invoke();	
						//movements.Add(Movement.Right);
					//Left Swipe
					else
						//movements.Add(Movement.Left);
						onPlayerSwipeLeft.Invoke();	
				}

				//More movement along the Y axis than the X axis
				else {
					//Upward Swipe
					if((fingerEnd.y - fingerStart.y) > 0)
						movements.Add(Movement.Up);
					//Downward Swipe
					else
						movements.Add(Movement.Down);
				}
				//After the checks are performed, set the fingerStart & fingerEnd to be the same
				fingerStart = touch.position;   

				//Now let's check if the Movement pattern is what we want
				//In this example, I'm checking whether the pattern is Left, then Right, then Left again
				//Debug.Log (CheckForPatternMove(0, 3, new List<Movement>() { Movement.Left, Movement.Right, Movement.Left } ));
			}


			if(touch.phase == TouchPhase.Ended)
			{
				fingerStart = Vector2.zero;
				fingerEnd = Vector2.zero;
				movements.Clear();
			}
		}
	}



}