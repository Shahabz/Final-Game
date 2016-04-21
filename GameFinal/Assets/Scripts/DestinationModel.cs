using UnityEngine;
using System.Collections;

public class DestinationModel : MonoBehaviour {

	public GameObject destination;

	// Use this for initialization
	void Start () {
		destination.transform.position = new Vector3 (0.7f, 1f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
