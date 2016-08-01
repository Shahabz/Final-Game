using UnityEngine;
using System.Collections;

public class threestarsyay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.transform.Rotate (new Vector3 (0, 0, 90));
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (transform.rotation.z);
		gameObject.transform.position = new Vector3 (gameObject.transform.position.x + 0.15f, gameObject.transform.position.y, gameObject.transform.position.z);
	}
}
