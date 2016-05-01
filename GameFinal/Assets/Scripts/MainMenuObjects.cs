using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainMenuObjects : MonoBehaviour {

	public float FloatStrenght;
	public float RandomRotationStrenght;


	void Update () {
		GetComponent<Rigidbody2D>().AddForce(Vector2.up *FloatStrenght);
		transform.Rotate(0,0,RandomRotationStrenght);
	}

}
