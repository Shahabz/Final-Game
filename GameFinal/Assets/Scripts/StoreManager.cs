﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class StoreManager : MonoBehaviour {
	
	public GameObject StoreBackground;
	public Button closeButton;
	public Button watchAdVideoButton;
	public Button buyBlocks1Button;
	public Button buyBlocks2Button;
	public Button buyBlocks3Button;
	public static bool MenuIsOpen = false;

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
	}

	public void HandleGameStoreClicked() {

		//TODO: cant press play or touch blocks
		MenuIsOpen = true;
		closeButton.image.enabled = true;
		closeButton.enabled = true;
		watchAdVideoButton.image.enabled = true;
		watchAdVideoButton.enabled = true;
		buyBlocks1Button.image.enabled = true;
		buyBlocks1Button.enabled = true;
		buyBlocks2Button.image.enabled = true;
		buyBlocks2Button.enabled = true;
		buyBlocks3Button.image.enabled = true;
		buyBlocks3Button.enabled = true;
		StoreBackground.GetComponent<SpriteRenderer> ().enabled = true;
	}

	public void OnClickBack() {
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
	}

	public void OnClickWatchAdVideo() {
		MenuIsOpen = false;
		Advertisement.Show("rewardedVideoZone");
		GameControl.control.numOfBlocks += 5;
	}

	public void OnClickBuyBlocks1() {
		MenuIsOpen = false;
		// TODO: add buying action here - buy through google play store check out how to do this...
		GameControl.control.numOfBlocks += 5; // TODO: update how many blocks are added for each purchase
	}

	public void OnClickBuyBlocks2() {
		MenuIsOpen = false;
		// TODO: add buying action here - buy through google play store check out how to do this...
		GameControl.control.numOfBlocks += 10; // TODO: update how many blocks are added for each purchase
	}

	public void OnClickBuyBlocks3() {
		MenuIsOpen = false;
		// TODO: add buying action here - buy through google play store check out how to do this...
		GameControl.control.numOfBlocks += 15; // TODO: update how many blocks are added for each purchase
	}

}
