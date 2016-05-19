using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeLevel : MonoBehaviour
{
	public int numOfCloseLevel = 0;
	public int numOfGainedStars = 0;
	public int numOfLevels = 0;
	public int[] starsArray;
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
			setLevelImage(buttonsArray[i], starsArray[i]);
		}
	}

	public void setLevelImage (Button button, int numOfStars)
	{

		switch (numOfStars) {
		case -1:
			button.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Levels/lockLevel");
			button.GetComponent<Button>().interactable = false;
			numOfCloseLevel++;
			break;
		
		case 0:
			button.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Levels/zeroStars");
			button.GetComponent<Button>().interactable = true;
			break;
	
		case 1:
			button.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Levels/oneStars");
			button.GetComponent<Button>().interactable = true;
			numOfGainedStars++;
			break;

		case 2:
			button.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Levels/twoStars");
			button.GetComponent<Button>().interactable = true;
			numOfGainedStars = numOfGainedStars + 2;
			break;
		case 3:
			button.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Levels/threeStars");
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
}
