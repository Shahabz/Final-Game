using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class PinchController : MonoBehaviour
{

	public UnityEvent onPlayerPinchOut;
	public UnityEvent onPlayerPinchIn;
	private Touch pinchFinger1;
	private Touch pinchFinger2;

	void Update ()
	{

		// If there are two touches on the device...

		//		if (Input.touchCount == 2) {
		//			// Store both touches.
		//			Touch touchZero = Input.GetTouch (0);
		//			Touch touchOne = Input.GetTouch (1);
		//
		//			// Find the position in the previous frame of each touch.
		//			Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
		//			Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
		//
		//			// Find the magnitude of the vector (the distance) between the touches in each frame.
		//			float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
		//			float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;
		//
		//			if (Mathf.Abs (touchDeltaMag - prevTouchDeltaMag) > 0.5f) {
		//				if (prevTouchDeltaMag < touchDeltaMag)
		//					onPlayerPinchOut.Invoke ();
		//				else if (prevTouchDeltaMag > touchDeltaMag)
		//					onPlayerPinchIn.Invoke ();	
		//			}
		//		}
		float currDistance;
		float baseDistance;

		if (Input.touchCount == 2) {
			Touch firstFinger = Input.GetTouch (0);
			Touch secondFinger = Input.GetTouch (1);

			if (firstFinger.phase == TouchPhase.Began && secondFinger.phase == TouchPhase.Began) {
				pinchFinger1 = firstFinger;
				pinchFinger2 = secondFinger;
			}
			if (firstFinger.phase == TouchPhase.Ended && secondFinger.phase == TouchPhase.Ended) {
				baseDistance = Vector2.Distance (pinchFinger1.position, pinchFinger2.position);
				currDistance = Vector2.Distance (firstFinger.position, secondFinger.position);

				if (Mathf.Abs (baseDistance - currDistance) > 0.001f) {
					if (baseDistance > currDistance)
						onPlayerPinchIn.Invoke ();
					if (currDistance > baseDistance)
						onPlayerPinchOut.Invoke ();
				}
			}

			//if (Input.GetKeyDown (KeyCode.UpArrow))
			//	onPlayerPinchIn.Invoke ();
			//if (Input.GetKeyDown (KeyCode.DownArrow))
			//	onPlayerPinchOut.Invoke ();
		}
	}
}