using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeLevel : MonoBehaviour
{
	public int numOfCloseLevel = 0;
	public int numOfGainedStars = 0;
	public int numOfLevels = 0;
	public static int lastLevel = 10; 
	public static int[] starsArray = new int[10];
	public Button[] buttonsArray;
	public Text starsText;

	// Use this for initialization
	void Start ()
	{				
		HandleCheckLevelsStars();
		starsText.text =  numOfGainedStars +  "/" + ((numOfLevels - numOfCloseLevel) * 3);
	}

	public void HandleCheckLevelsStars ()
	{		
		for (int i = 0; i < numOfLevels; i++) {
			setLevelImage(buttonsArray[i], GameControl.control.starsArray[i]);
		}
	}

	public void setLevelImage (Button button, int numOfStars)
	{
		GameObject locked = button.transform.FindChild("lockImage").gameObject;
		switch (numOfStars) {
		case -1:
			button.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Levels/lockLevel");
			locked.GetComponent<Image> ().enabled = true;
			button.GetComponent<Button>().enabled = false;
			numOfCloseLevel++;
			break;
		
		case 0:
			button.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Levels/zeroStars");
			locked.GetComponent<Image> ().enabled = false;
			button.GetComponent<Button>().interactable = true;
			break;
	
		case 1:
			button.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Levels/oneStars");
			locked.GetComponent<Image> ().enabled = false;
			button.GetComponent<Button>().interactable = true;
			numOfGainedStars++;
			break;

		case 2:
			button.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Levels/twoStars");
			locked.GetComponent<Image> ().enabled = false;
			button.GetComponent<Button>().interactable = true;
			numOfGainedStars = numOfGainedStars + 2;
			break;
		case 3:
			button.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Levels/threeStars");
			locked.GetComponent<Image> ().enabled = false;
			button.GetComponent<Button>().interactable = true;
			numOfGainedStars = numOfGainedStars + 3;
			break;
		}
	}

	public void HandlePressReturnButteun ()
	{
		Application.LoadLevel ("StartMenu");
	}

	public void HadleLoadLevel (int Level)
	{
		
		Application.LoadLevel ("Level" + Level);
	}


	public void HadleLoadLevels (int Levels)
	{

		Application.LoadLevel ("Levels" + Levels);
	}
}
