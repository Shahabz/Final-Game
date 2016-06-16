using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PrefrencesMenu : MonoBehaviour {

	public GameObject MenuBackground;
	public GameObject CreditsBackground;
	public Button playButton;
	public Button backButton;
	public Button backCreditsButton;
	public Button soundButton;
	public Button musicButton;
	public Button creditsButton;
	public Sprite musicOffImage;
	public Sprite musicOnImage;
	public Sprite soundOffImage;
	public Sprite soundOnImage;

	public static bool MenuIsOpen = false;


	void Start() {
		backButton.image.enabled = false;
		backButton.enabled = false;
		creditsButton.image.enabled = false;
		creditsButton.enabled = false;
		backCreditsButton.image.enabled = false;
		backCreditsButton.enabled = false;
		soundButton.image.enabled = false;
		soundButton.enabled = false;
		musicButton.image.enabled = false;
		musicButton.enabled = false;
		MenuBackground.GetComponent<SpriteRenderer> ().enabled = false;
		CreditsBackground.GetComponent<SpriteRenderer> ().enabled = false;

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

		//TODO: cant press play or touch blocks
		MenuIsOpen = true;
		backButton.image.enabled = true;
		backButton.enabled = true;
		creditsButton.image.enabled = true;
		creditsButton.enabled = true;
		soundButton.image.enabled = true;
		soundButton.enabled = true;
		musicButton.image.enabled = true;
		musicButton.enabled = true;
		playButton.image.enabled = false;
		playButton.enabled = false;
		MenuBackground.GetComponent<SpriteRenderer> ().enabled = true;
	}

	public void OnClickBack() {
		MenuIsOpen = false;
		backButton.image.enabled = false;
		backButton.enabled = false;
		creditsButton.image.enabled = false;
		creditsButton.enabled = false;
		soundButton.image.enabled = false;
		soundButton.enabled = false;
		musicButton.image.enabled = false;
		musicButton.enabled = false;
		playButton.image.enabled = true;
		playButton.enabled = true;
		MenuBackground.GetComponent<SpriteRenderer> ().enabled = false;
	}

	public void OnClickCredits() {
		backButton.image.enabled = false;
		backButton.enabled = false;
		creditsButton.image.enabled = false;
		creditsButton.enabled = false;
		soundButton.image.enabled = false;
		soundButton.enabled = false;
		musicButton.image.enabled = false;
		musicButton.enabled = false;
		backCreditsButton.image.enabled = true;
		backCreditsButton.enabled = true;
		CreditsBackground.GetComponent<SpriteRenderer> ().enabled = true;
		MenuBackground.GetComponent<SpriteRenderer> ().enabled = false;
	}

	public void OnClickBackCredits() {
		backButton.image.enabled = true;
		backButton.enabled = true;
		creditsButton.image.enabled = true;
		creditsButton.enabled = true;
		soundButton.image.enabled = true;
		soundButton.enabled = true;
		musicButton.image.enabled = true;
		musicButton.enabled = true;
		creditsButton.image.enabled = true;
		creditsButton.enabled = true;
		backCreditsButton.image.enabled = false;
		backCreditsButton.enabled = false;
		CreditsBackground.GetComponent<SpriteRenderer> ().enabled = false;
		MenuBackground.GetComponent<SpriteRenderer> ().enabled = true;
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
