using UnityEngine;
using System.Collections;

public class MovingBalls2 : MonoBehaviour {
	
	private float speed = 0.04f;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		transform.position = new Vector2 (transform.position.x + speed, transform.position.y);
		if (transform.position.x > 2f) 
		{
			speed = speed * (-1);
		}
		else if (transform.position.x < -6.4f) 
		{
			speed = speed * (-1);
		}
	}
}
