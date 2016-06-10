using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour {

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
	public static bool musicOn = true;
	public static bool soundOn = true;


	void Start() {
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

		if (soundOn) {
			soundButton.image.sprite = soundOnImage;
		} else {
			soundButton.image.sprite = soundOffImage;
		}

		if (musicOn) {
			musicButton.image.sprite = musicOnImage;
		} else {
			musicButton.image.sprite = musicOffImage;
		}
	}

	public void HandlePauseClicked() {

		//TODO: cant press play or touch blocks

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
		OnClickBack ();
		//TODO: return blocks to stash and reload
	}

	public void OnClickSound() {
		if (soundOn) {
			soundOn = false;
			soundButton.image.sprite = soundOffImage;
		} else {
			soundOn = true;
			soundButton.image.sprite = soundOnImage;
		}
	}

	public void OnClickMusic() {
		if (musicOn) {
			musicOn = false;
			musicButton.image.sprite = musicOffImage;
		} else {
			musicOn = true;
			musicButton.image.sprite = musicOnImage;
		}
	}

}
