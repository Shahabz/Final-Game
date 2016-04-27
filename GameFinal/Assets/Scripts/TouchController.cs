using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class TouchController : MonoBehaviour {

	public UnityEvent onPlayerPressStart;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyUp(KeyCode.Return))
			onPlayerPressStart.Invoke ();
	}
}
