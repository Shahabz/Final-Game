using UnityEngine;
using System.Collections;

public class MovingLineModel : MonoBehaviour {

	private float speed = 0.04f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x > 0) {
			transform.position = new Vector2 (transform.position.x + speed, transform.position.y);
			if (transform.position.x > 4.5f) {
				transform.position = new Vector2 (4.49f, transform.position.y);
				speed = speed * (-1);
			}
			if (transform.position.x < 1.72f) {
				transform.position = new Vector2 (1.721f, transform.position.y);
				speed = speed * (-1);
			}
		} else {
			transform.position = new Vector2 (transform.position.x - speed, transform.position.y);
			if (transform.position.x < -4.5f) {
				transform.position = new Vector2 (-4.49f, transform.position.y);
				speed = speed * (-1);
			}
			if (transform.position.x > -1.72f) {
				transform.position = new Vector2 (-1.721f, transform.position.y);
				speed = speed * (-1);
			}
		}
	
	}
}
