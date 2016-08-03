using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class StoreManager : MonoBehaviour {

	public Button startButton;
	public Button pauseButton;

	public GameObject StoreBackground;
	//public GameObject comingSoon;
	public Button closeButton;
	public Button watchAdVideoButton;
	public Button buyBlocks1Button;
	public Button buyBlocks2Button;
	public Button buyBlocks3Button;
	public static bool MenuIsOpen = false;
//	public static bool disableAdButton = false;

	void Start() {
		closeButton.image.enabled = false;
		closeButton.enabled = false;
		watchAdVideoButton.image.enabled = false;
		watchAdVideoButton.enabled = false;
		buyBlocks1Button.image.enabled = false;
		buyBlocks1Button.enabled = false;
		buyBlocks2Button.image.enabled = false;
		buyBlocks2Button.enabled = false;
		buyBlocks3Button.image.enabled = false;
		buyBlocks3Button.enabled = false;
		StoreBackground.GetComponent<SpriteRenderer> ().enabled = false;
		//comingSoon.GetComponent<SpriteRenderer> ().enabled = false;
	}

//	void Update() {
//		if (disableAdButton) {
//			watchAdVideoButton.enabled = false;
//			disableAdButton = false;
//		} 
//	}

	public void HandleGameStoreClicked() {
		SoundManager.playButtonClick = true;
		startButton.enabled = false;
		pauseButton.enabled = false;
		BlockStashModel.canDragFromStash = false;
		DragScript.canDragBlock = false;

		MenuIsOpen = true;
		closeButton.image.enabled = true;
		closeButton.enabled = true;
		watchAdVideoButton.image.enabled = true;
		watchAdVideoButton.enabled = true;
		buyBlocks1Button.image.enabled = true;
		//buyBlocks1Button.enabled = true;
		buyBlocks2Button.image.enabled = true;
		//buyBlocks2Button.enabled = true;
		buyBlocks3Button.image.enabled = true;
		//buyBlocks3Button.enabled = true;
		StoreBackground.GetComponent<SpriteRenderer> ().enabled = true;
		//comingSoon.GetComponent<SpriteRenderer> ().enabled = true;
	}

	public void OnClickBack() {
		SoundManager.playButtonClick = true;
		startButton.enabled = true;
		pauseButton.enabled = true;
		BlockStashModel.canDragFromStash = true;
		DragScript.canDragBlock = true;

		MenuIsOpen = false;
		closeButton.image.enabled = false;
		closeButton.enabled = false;
		watchAdVideoButton.image.enabled = false;
		watchAdVideoButton.enabled = false;
		buyBlocks1Button.image.enabled = false;
		buyBlocks1Button.enabled = false;
		buyBlocks2Button.image.enabled = false;
		buyBlocks2Button.enabled = false;
		buyBlocks3Button.image.enabled = false;
		buyBlocks3Button.enabled = false;
		StoreBackground.GetComponent<SpriteRenderer> ().enabled = false;
		//comingSoon.GetComponent<SpriteRenderer> ().enabled = false;
	}

	public void OnClickWatchAdVideo() {
		SoundManager.playButtonClick = true;
		MenuIsOpen = false;
		//		Advertisement.Show("rewardedVideo");
//		GameControl.control.numOfBlocks += 5;
		AdScript.ShowRewardedAd();
	}

	public void OnClickBuyBlocks1() {
		SoundManager.playButtonClick = true;
		MenuIsOpen = false;
		// TODO: add buying action here - buy through google play store check out how to do this...
		GameControl.control.numOfBlocks += 5; // TODO: update how many blocks are added for each purchase
	}

	public void OnClickBuyBlocks2() {
		SoundManager.playButtonClick = true;
		MenuIsOpen = false;
		// TODO: add buying action here - buy through google play store check out how to do this...
		GameControl.control.numOfBlocks += 10; // TODO: update how many blocks are added for each purchase
	}

	public void OnClickBuyBlocks3() {
		SoundManager.playButtonClick = true;
		MenuIsOpen = false;
		// TODO: add buying action here - buy through google play store check out how to do this...
		GameControl.control.numOfBlocks += 15; // TODO: update how many blocks are added for each purchase
	}

}
