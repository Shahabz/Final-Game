using UnityEngine;
using System.Collections;

public class SpinningObstacle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.back * Time.deltaTime * 30);
		//Debug.Log (1);
		//transform.rotation = Quaternion.Euler (transform.rotation.x + 0.2f, transform.rotation.y + 0.2f, transform.rotation.z + 0.2f);
	}
}
