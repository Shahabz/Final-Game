using UnityEngine;
using System.Collections;

public class BubbleModel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector2 (transform.position.x, transform.position.y + GravityModel.speed);
	}
}
