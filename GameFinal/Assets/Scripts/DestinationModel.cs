using UnityEngine;
using System.Collections;

public class DestinationModel : MonoBehaviour {

	private bool moveVertical = true;
	private float speed = 0.04f;
	private float startX;
	private float startY;
	private Animator crystalAnimator;
	public static bool playCrystalShatter = false;

	// Use this for initialization
	void Start () {
		startX = transform.position.x;
		startY = transform.position.y;

		crystalAnimator = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		transform.Rotate (0, 0, 0.2f, Space.Self);

		if (Application.loadedLevelName.Equals ("Level8")) {
			if (moveVertical) {
				MoveUpAndDown ();
			} else
				MoveLeftAndRight();
		}

		if (Application.loadedLevelName.Equals ("Level13")) {
				MoveDiagonal();
		}
	}

	public void MoveDiagonal(){
		transform.position = new Vector2(transform.position.x + (speed*0.5f), transform.position.y + speed);
		if (transform.position.y >= 3f) {
			transform.position = new Vector2(transform.position.x, 2.99f);
			speed = speed * (-1);
		} else if (transform.position.y <= startY) {
			transform.position = new Vector2(transform.position.x, startY);
			speed = speed * (-1);
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
		transform.localScale = new Vector3 (0.6f, 0.6f, 1);
		playCrystalShatter = true;
		crystalAnimator.SetBool ("crystalHit", true);
		speed = 0f;
		StartCoroutine (destroyTarget());
	}

	public IEnumerator destroyTarget() {
		yield return new WaitForSeconds (0.75f);
		Destroy(gameObject);
	}
}
