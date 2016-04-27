using UnityEngine;
using System.Collections;

public class RingScript : MonoBehaviour {

	private float baseAngle = 0.0f;



	void OnMouseDown(){
		Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
		pos = Input.mousePosition - pos;
		baseAngle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
		baseAngle -= Mathf.Atan2(transform.right.y, transform.right.x) *Mathf.Rad2Deg;
	}

	void OnMouseDrag(){
		Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
		pos = Input.mousePosition - pos;
		float ang = Mathf.Atan2(pos.y, pos.x) *Mathf.Rad2Deg - baseAngle;
		transform.rotation = Quaternion.AngleAxis(ang, Vector3.forward);
	}



	// Use this for initialization
	//void Start () {
	
	//}
	
	// Update is called once per frame
	//void Update () {	
	//	for( int i = 0; i< Input.touchCount ; i++){

	//		if (Input.GetTouch(i).phase == TouchPhase.Began){
	//			Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
	//			pos = Input.mousePosition - pos;
	//			baseAngle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
	//			baseAngle -= Mathf.Atan2(transform.right.y, transform.right.x) *Mathf.Rad2Deg;
	//		}
	//		else if (Input.GetTouch(i).phase == TouchPhase.Moved){
	//			Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
	//			pos = Input.mousePosition - pos;
	//			float ang = Mathf.Atan2(pos.y, pos.x) *Mathf.Rad2Deg - baseAngle;
	//			transform.rotation = Quaternion.AngleAxis(ang, Vector3.forward);
	//		}				
	//	}
	//}
}
