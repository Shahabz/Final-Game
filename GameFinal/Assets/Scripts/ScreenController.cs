using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class ScreenController : MonoBehaviour {


	public UnityEvent clickOnScreen;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		Debug.Log("1");
		clickOnScreen.Invoke ();
	}
}
