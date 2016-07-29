using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;

public class TouchController : MonoBehaviour {

	public UnityEvent onPlayerPressStart;
	public UnityEvent onPlayerClickNewBlock;
	public Button playButton;
	public Button levelsButton;

	// Use this for initialization
	void Start () {	
	
	}
		
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyUp (KeyCode.Return)) {
			onPlayerPressStart.Invoke ();
			playButton.enabled = false;
			levelsButton.enabled = false;
		}
	}

	public void HandleStartButtonClicked () {
		SoundManager.playButtonClick = true;
		onPlayerPressStart.Invoke ();
		playButton.enabled = false;
		levelsButton.enabled = false;
	}
}
