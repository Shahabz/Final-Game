using UnityEngine;
using System.Collections;

public class MenuModel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void HandleClickedPlay ()
	{
		//Application.LoadLevel ("LevelMenu");
		Application.LoadLevel ("Level1");
	}

	public void HandleClickedLevelsButton ()
	{
		//Application.LoadLevel ("LevelMenu");
		Application.LoadLevel ("Levels");
	}

	public void HandleClickedAbout ()
	{
		//Application.LoadLevel ("About");
	}

	public void HandleClickedHelp ()
	{
		Application.LoadLevel ("Help");
	}

	public void HandleClickedBackToMainMenu()
	{
		Application.LoadLevel ("StartMenu");
	}
}
