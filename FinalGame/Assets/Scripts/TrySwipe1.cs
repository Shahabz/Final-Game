using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class TrySwipe1 : MonoBehaviour {


	public UnityEvent onPlayerSwipeRight;
	public UnityEvent onPlayerSwipeLeft;
	float validInputThresold = 0.1f;
	bool playerIsMoving = false;

	enum Gestures {
		None,
		Stationary,
		SwipeRight,
		SwipeLeft,
		SwipeUp,
		SwipeDown
	}

	Gestures currentGesture;

	public void Update() {
		currentGesture = Gestures.None;
		if(Input.touchCount > 0 ){
		HandleTouch(Input.GetTouch(0));
		HandleCharacterMovement(currentGesture);
		}
	}

	Vector3 originalPosition;
	void HandleTouch(Touch touch) {
		if (touch.Equals(null)) return;



		switch (touch.phase) {
			case TouchPhase.Began:
				originalPosition = touch.position;
				break;
		case TouchPhase.Moved:
			
			Vector3 delta = new Vector3( touch.position.x - originalPosition.x, touch.position.y - originalPosition.y, originalPosition.z);
			if (delta.magnitude > validInputThresold) Moved(touch, delta);
			//playerIsMoving =true;
			break;
		case TouchPhase.Stationary:
			currentGesture = Gestures.Stationary;
			break;
		case TouchPhase.Ended:
			playerIsMoving =false;
			break;
		case TouchPhase.Canceled:
			playerIsMoving =false;
			currentGesture = Gestures.None;

			break;
		}
	}

	public float gestureThresold = 1f;

	void Moved(Touch touch, Vector3 delta) {
		if ((Mathf.Abs(delta.x)<=gestureThresold && Mathf.Abs(delta.y)<=gestureThresold)
			|| (Mathf.Abs(delta.x)>gestureThresold && Mathf.Abs(delta.y)>gestureThresold) )
			currentGesture = Gestures.Stationary; //IF FINGER MOVED IN DIAGONAL, INVALID STATE FALLSBACK TO STATIONARY
		else if (delta.x > gestureThresold) currentGesture = Gestures.SwipeRight;
		else if (delta.x < -gestureThresold) currentGesture = Gestures.SwipeLeft;
		else if (delta.y > gestureThresold) currentGesture = Gestures.SwipeUp;
		else if (delta.y < -gestureThresold) currentGesture = Gestures.SwipeDown;
	}




	// ALL THE ROUTINES HERE SET THE PLAYER IS MOVING FLAG
	// TO TRUE AND THEN TO FALSE WHEN THE MOVEMENT IS DONE
	void HandleCharacterMovement(Gestures gesture) {
		if (playerIsMoving) return;

		switch (gesture) {

		default:
		case Gestures.None:
		case Gestures.Stationary:
			return;

		case Gestures.SwipeRight:
			
			onPlayerSwipeRight.Invoke();	
			playerIsMoving =true;
			return;
		case Gestures.SwipeLeft:
			
			onPlayerSwipeLeft.Invoke();	
			playerIsMoving =true;
			return;
		case Gestures.SwipeUp:
			//StartCoroutine(Jump());
			return;
		case Gestures.SwipeDown:
			//StartCoroutine(Crouch());
			return;
		}
	}
}