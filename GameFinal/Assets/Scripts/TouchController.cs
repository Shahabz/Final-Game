using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class TouchController : MonoBehaviour {

	public UnityEvent onPlayerPressStart;
	public UnityEvent onPlayerClickNewBlock;
	public GameObject button;

	// Use this for initialization
	void Start () {
	
	}
		
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyUp (KeyCode.Return))
			onPlayerPressStart.Invoke ();
	}

	public void HandleStartButtonClicked () {
		onPlayerPressStart.Invoke ();
	}
}
