using UnityEngine;
using System.Collections;

public class DestinationModel : MonoBehaviour {

	private bool moveVertical = true;
	private float speed = 0.04f;
	private float startX;
	private float startY;

	// Use this for initialization
	void Start () {
		startX = transform.position.x;
		startY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevelName.Equals ("Level3")) {
			if (moveVertical) {
				MoveUpAndDown ();
			} else
				MoveLeftAndRight();
		}
	}

	public void MoveUpAndDown() {
		transform.position = new Vector2(transform.position.x, transform.position.y + speed);
		if (transform.position.y >= 3f) {
			transform.position = new Vector2(transform.position.x, 2.99f);
			speed = speed * (-1);
		} else if (transform.position.y <= startY) {
			transform.position = new Vector2(transform.position.x, startY);
			speed = speed * (-1);
			moveVertical = false;
		}
	}

	public void MoveLeftAndRight() {
		transform.position = new Vector2(transform.position.x - speed, transform.position.y);
		if (transform.position.x <= -0.5f) {
			transform.position = new Vector2(-0.499f, transform.position.y);
			speed = speed * (-1);
		} else if (transform.position.x >= startX) {
			transform.position = new Vector2(startX, transform.position.y);
			speed = speed * (-1);
			moveVertical = true;
		}
	}

	public void HandleWinLevel() {
		speed = 0f;
	}
}
