using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class PinchController : MonoBehaviour {

	public UnityEvent onPlayerPinchOut;
	public UnityEvent onPlayerPinchIn;

	void Update () {
		
		// If there are two touches on the device...
		if (Input.touchCount == 2) {
			// Store both touches.
			Touch touchZero = Input.GetTouch (0);
			Touch touchOne = Input.GetTouch (1);

			// Find the position in the previous frame of each touch.
			Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
			Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

			// Find the magnitude of the vector (the distance) between the touches in each frame.
			float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
			float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

			if (prevTouchDeltaMag < touchDeltaMag)
				onPlayerPinchOut.Invoke ();
			else if (prevTouchDeltaMag > touchDeltaMag)
				onPlayerPinchIn.Invoke ();	
		}

		//if (Input.GetKeyDown (KeyCode.UpArrow))
		//	onPlayerPinchIn.Invoke ();
		//if (Input.GetKeyDown (KeyCode.DownArrow))
		//	onPlayerPinchOut.Invoke ();
	}
}
