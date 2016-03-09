using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;

public class SwipeController : MonoBehaviour
{

	public UnityEvent onPlayerSwipeRight;
	public UnityEvent onPlayerSwipeLeft;
	public UnityEvent onPlayerSwipeUp;
	public UnityEvent onPlayerTap;

	private Vector2 fingerStart;
	private Vector2 fingerEnd;

	public int leftRight = 0;
	public int upDown = 0;

	private bool isMoving = false;

	public enum Movement
	{
		Left,
		Right,
		Up,
		Down}
	;

	public List<Movement> movements = new List<Movement> ();

	void Update ()
	{

		//if (!PlayerModel.levelEnd) {
		foreach (Touch touch in Input.touches) {
				
			if (touch.phase == TouchPhase.Began) {
				fingerStart = touch.position;
				fingerEnd = touch.position;
			}

			if (touch.phase == TouchPhase.Moved) {
				if (!isMoving) {

					fingerEnd = touch.position;

					//There is more movement on the X axis than the Y axis
					if (Mathf.Abs (fingerStart.x - fingerEnd.x) > Mathf.Abs (fingerStart.y - fingerEnd.y)) {

						//Right Swipe
						if (((fingerEnd.x - fingerStart.x) > 0) && (!PlayerModel.levelEnd)) {
							onPlayerSwipeRight.Invoke ();
							isMoving = true;
						}
						//movements.Add(Movement.Right);
					//Left Swipe
						else {
							//movements.Add(Movement.Left);
							if (!PlayerModel.levelEnd) {	
								onPlayerSwipeLeft.Invoke ();	
								isMoving = true;
							}
						}
					}

				//More movement along the Y axis than the X axis
				else {
						//Upward Swipe
						if (((fingerEnd.y - fingerStart.y) > 0) && (!PlayerModel.levelEnd)) {
							onPlayerSwipeUp.Invoke ();
							isMoving = true;

							//movements.Add (Movement.Up);
						}
					//Downward Swipe
							else {
							//if (PlayerModel.levelEnd) {
							onPlayerTap.Invoke ();
							isMoving = true;
								
						}
					}
					//After the checks are performed, set the fingerStart & fingerEnd to be the same
					fingerStart = touch.position;   

				}
			}

			if (touch.phase == TouchPhase.Ended) {
				isMoving = false;
				fingerStart = Vector2.zero;
				fingerEnd = Vector2.zero;
				movements.Clear ();

			}
		}
		//	}

		if ((Input.GetKeyDown (KeyCode.Space)) && PlayerModel.levelEnd)
			onPlayerTap.Invoke ();

		//if ((Input.touchCount > 0) && PlayerModel.levelEnd)
		//onPlayerTap.Invoke ();
	}
		
}