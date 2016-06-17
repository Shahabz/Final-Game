using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PauseMenuManager : MonoBehaviour {
	public Button startButton;
	public Button pauseButton;
	public GameObject MenuBackground;
	public Button backButton;
	public Button replayButton;
	public Button menuButton;
	public Button soundButton;
	public Button musicButton;
	public Sprite musicOffImage;
	public Sprite musicOnImage;
	public Sprite soundOffImage;
	public Sprite soundOnImage;
	public static bool MenuIsOpen = false;
	public static int activeBlocksCounter;
	void Start() {
		activeBlocksCounter = 0;
		backButton.image.enabled = false;
		backButton.enabled = false;
		replayButton.image.enabled = false;
		replayButton.enabled = false;
		menuButton.image.enabled = false;
		menuButton.enabled = false;
		soundButton.image.enabled = false;
		soundButton.enabled = false;
		musicButton.image.enabled = false;
		musicButton.enabled = false;
		MenuBackground.GetComponent<SpriteRenderer> ().enabled = false;
		if (SoundManager.soundOn) {
			soundButton.image.sprite = soundOnImage;
		} else {
			soundButton.image.sprite = soundOffImage;
		}
		if (SoundManager.musicOn) {
			musicButton.image.sprite = musicOnImage;
		} else {
			musicButton.image.sprite = musicOffImage;
		}
	}
	public void HandlePauseClicked() {
		startButton.enabled = false;
		pauseButton.enabled = false;
		BlockStashModel.canDragFromStash = false;
		DragScript.canDragBlock = false;
		MenuIsOpen = true;
		backButton.image.enabled = true;
		backButton.enabled = true;
		replayButton.image.enabled = true;
		replayButton.enabled = true;
		menuButton.image.enabled = true;
		menuButton.enabled = true;
		soundButton.image.enabled = true;
		soundButton.enabled = true;
		musicButton.image.enabled = true;
		musicButton.enabled = true;
		MenuBackground.GetComponent<SpriteRenderer> ().enabled = true;
	}
	public void OnClickBack() {
		startButton.enabled = true;
		pauseButton.enabled = true;
		BlockStashModel.canDragFromStash = true;
		DragScript.canDragBlock = true;
		MenuIsOpen = false;
		backButton.image.enabled = false;
		backButton.enabled = false;
		replayButton.image.enabled = false;
		replayButton.enabled = false;
		menuButton.image.enabled = false;
		menuButton.enabled = false;
		soundButton.image.enabled = false;
		soundButton.enabled = false;
		musicButton.image.enabled = false;
		musicButton.enabled = false;
		MenuBackground.GetComponent<SpriteRenderer> ().enabled = false;
	}
	public void OnClickReplay() {
		
		startButton.enabled = true;
		pauseButton.enabled = true;
		BlockStashModel.canDragFromStash = true;
		DragScript.canDragBlock = true;
		MenuIsOpen = false;
		GameControl.control.numOfBlocks = GameControl.control.numOfBlocks + activeBlocksCounter;
		Application.LoadLevel (Application.loadedLevel);
	}
	public void OnClickSound() {
		if (SoundManager.soundOn) {
			SoundManager.soundOn = false;
			soundButton.image.sprite = soundOffImage;
		} else {
			SoundManager.soundOn = true;
			soundButton.image.sprite = soundOnImage;
		}
	}
	public void OnClickMusic() {
		if (SoundManager.musicOn) {
			SoundManager.musicOn = false;
			musicButton.image.sprite = musicOffImage;
		} else {
			SoundManager.musicOn = true;
			musicButton.image.sprite = musicOnImage;
		}
	}
}