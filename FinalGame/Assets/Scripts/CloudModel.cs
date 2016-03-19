using UnityEngine;
using System.Collections;

public class CloudModel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.y > 12.3f) {
			transform.position = new Vector2 (transform.position.x, -11f);
		} else {
			transform.position = new Vector2 (transform.position.x, transform.position.y + GravityModel.speed * 0.8f);
		}
	}
}
