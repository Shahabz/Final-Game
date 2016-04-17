using UnityEngine;
using System.Collections;

public class MarbleArrowModel : MonoBehaviour {

	public GameObject arrow;

	// Use this for initialization
	void Start () {
		arrow.transform.position = new Vector3 (-1.5f, -4.1f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
