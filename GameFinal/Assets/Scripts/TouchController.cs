using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;

public class TouchController : MonoBehaviour {

	public UnityEvent onPlayerPressStart;
	public UnityEvent onPlayerClickNewBlock;
	public Button button;

	// Use this for initialization
	void Start () {
	
	}
		
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyUp (KeyCode.Return)) {
			onPlayerPressStart.Invoke ();
			button.enabled = false;
		}
	}

	public void HandleStartButtonClicked () {
		onPlayerPressStart.Invoke ();
		button.enabled = false;
	}
}
