using UnityEngine;
using System.Collections;

public class BasketController : MonoBehaviour {

	public GameObject basket;
	private float direction = 0.15f;
	public static bool stopped = false;

	// Use this for initialization
	void Start () {
		basket.transform.position = new Vector3 (-0.887f, -81.20f, 0f); 
	}
	
	// Update is called once per frame
	void Update () {
		if (!stopped) {
			if (basket.transform.position.x < -2.07f) {
				direction = 0.15f;
			}
			if (basket.transform.position.x > 2.07f) {
				direction = -0.15f;
			}
			basket.transform.position = new Vector3 (basket.transform.position.x + direction, basket.transform.position.y, 0);
		} 
	}
		

	public void HandleOnPlayerTap () {
		stopped = true;
	}
}
