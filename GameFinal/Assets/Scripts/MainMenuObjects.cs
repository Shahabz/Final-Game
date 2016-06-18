using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainMenuObjects : MonoBehaviour {

	public float FloatStrenght;
	public float RandomRotationStrenght;
	public bool isUp;


	void Update () {
		if (isUp) {
			GetComponent<Rigidbody2D> ().AddForce (Vector2.up * FloatStrenght);
			transform.Rotate (0, 0, RandomRotationStrenght);
		} else {
			GetComponent<Rigidbody2D> ().AddForce (Vector2.down * FloatStrenght);
			transform.Rotate (0, 0, RandomRotationStrenght);
		}
	}

}
