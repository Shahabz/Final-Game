using UnityEngine;
using System.Collections;

public class RingScript : MonoBehaviour
{

	private float baseAngle = 0.0f;
	public static bool pressOnRing = false;
	//private bool startRotation = true;

	void Update() 
	{
	//	if (startRotation) {
	//		transform.Rotate(new Vector3(0, 0, 0.75f));
	//	}
	}

	void OnMouseDown ()
	{
	//	startRotation = false;
		pressOnRing = true;
		if (!BlockModel.twoFingers) {
			Vector3 pos = Camera.main.WorldToScreenPoint (transform.position);
			pos = Input.mousePosition - pos;
			baseAngle = Mathf.Atan2 (pos.y, pos.x) * Mathf.Rad2Deg;
			baseAngle -= Mathf.Atan2 (transform.right.y, transform.right.x) * Mathf.Rad2Deg;
		}
	}

	void OnMouseUp () {
		pressOnRing = false;
	//	startRotation = true;
	}

	void OnMouseDrag ()
	{
	//	startRotation = false;
		if (!BlockModel.twoFingers) {
			Vector3 pos = Camera.main.WorldToScreenPoint (transform.position);
			pos = Input.mousePosition - pos;
			float ang = Mathf.Atan2 (pos.y, pos.x) * Mathf.Rad2Deg - baseAngle;
			transform.rotation = Quaternion.AngleAxis (ang, Vector3.forward);
		}
	}
}
