using UnityEngine;
using System.Collections;

public class MenuModel : MonoBehaviour {

	// Use this for initialization
	void Start () {

		// FOR REAL VERSION: use load() here
		// FOR DEBUGGING: use save() here

		//GameControl.control.Save ();
		GameControl.control.Load ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void HandleClickedPlay ()
	{
		Application.LoadLevel ("Levels1");
		SoundManager.playButtonClick = true;
		//Application.LoadLevel ("Level1");
	}

//	public void HandleClickedLevelsButton ()
//	{
//		//Application.LoadLevel ("LevelMenu");
//		Application.LoadLevel ("Levels");
//	}

	public void HandleClickedAbout ()
	{
		//Application.LoadLevel ("About");
	}

	public void HandleClickedHelp ()
	{
		Application.LoadLevel ("Help");
		SoundManager.playButtonClick = true;
	}

	public void HandleClickedBackToMainMenu()
	{
		Application.LoadLevel ("StartMenu");
		SoundManager.playButtonClick = true;
	}
}
