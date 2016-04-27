using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class PinchController : MonoBehaviour
{

	public UnityEvent onPlayerPinchOut;
	public UnityEvent onPlayerPinchIn;
	Touch firstFinger; 
	Touch secondFinger;
	bool touching = false;
	Vector2 firstFingerPrevPos;
	Vector2 secondFingerPrevPos;

	void Update ()
	{

		// If there are two touches on the device...

		if (Input.touchCount == 2) {

			if (!touching) {
				// Store both touches.
				firstFinger = Input.GetTouch (0);
				secondFinger = Input.GetTouch (1);
				touching = true;
				firstFingerPrevPos = firstFinger.position;
				secondFingerPrevPos = secondFinger.position;
			}

			if (touching) {
				// Find the position in the previous frame of each touch.
				//firstFingerPrevPos = firstFinger.position - firstFinger.deltaPosition;
				//secondFingerPrevPos = secondFinger.position - secondFinger.deltaPosition;

				// Find the magnitude of the vector (the distance) between the touches in each frame.
				float prevTouchDeltaMag = (firstFingerPrevPos - secondFingerPrevPos).magnitude;
				float touchDeltaMag = (firstFinger.position - secondFinger.position).magnitude;

				if (Mathf.Abs (touchDeltaMag - prevTouchDeltaMag) > 1f) {
					touching = false;
					if (prevTouchDeltaMag < touchDeltaMag)
						onPlayerPinchOut.Invoke ();
					else if (prevTouchDeltaMag > touchDeltaMag)
						onPlayerPinchIn.Invoke ();	
				}
			}
		}
		//		float endingDistance = 0;
		//		float initialDistance = 0;
		//
		//		if (Input.touchCount == 2) {
		//
		//			if (!touching) {
		//				firstFinger = Input.GetTouch (0);
		//				secondFinger = Input.GetTouch (1);
		//
		//				if (firstFinger.phase == TouchPhase.Began && secondFinger.phase == TouchPhase.Began) {
		//					initialDistance = Vector2.Distance (firstFinger.position, secondFinger.position);
		//				}
		//				touching = true;
		//			}
		//
		//			if (touching) {
		//				if (firstFinger.phase == TouchPhase.Ended && secondFinger.phase == TouchPhase.Ended) {
		//					endingDistance = Vector2.Distance (firstFinger.position, secondFinger.position);
		//
		//					if (Mathf.Abs (initialDistance - endingDistance) > 1f) {
		//						if (initialDistance > endingDistance)
		//							onPlayerPinchIn.Invoke ();
		//						if (endingDistance > initialDistance)
		//							onPlayerPinchOut.Invoke ();
		//					}
		//					touching = false;
		//				}
		//			}

		//if (Input.GetKeyDown (KeyCode.UpArrow))
		//	onPlayerPinchIn.Invoke ();
		//if (Input.GetKeyDown (KeyCode.DownArrow))
		//	onPlayerPinchOut.Invoke ();
		//}
	}
}