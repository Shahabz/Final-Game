using UnityEngine;
using System.Collections;

public class MovingLineModel : MonoBehaviour {

	private float speed = 0.04f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y > 0) {
			transform.position = new Vector2 (transform.position.x, transform.position.y + speed);
			if (transform.position.y > 4.5f) {
				transform.position = new Vector2 ( transform.position.x, 4.49f);
				speed = speed * (-1);
			}
			if (transform.position.y < 1.72f) {
				transform.position = new Vector2 ( transform.position.x,1.721f);
				speed = speed * (-1);
			}
		} else {
			transform.position = new Vector2 (transform.position.x, transform.position.y - speed);
			if (transform.position.y < -4.5f) {
				transform.position = new Vector2 (transform.position.x, -4.49f);
				speed = speed * (-1);
			}
			if (transform.position.y > -1.72f) {
				transform.position = new Vector2 (transform.position.x, -1.721f);
				speed = speed * (-1);
			}
		}
	
	}
}
