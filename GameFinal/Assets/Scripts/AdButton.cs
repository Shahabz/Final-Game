using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class AdButton : MonoBehaviour {

	void OnGUI() {
		Rect buttonRect = new Rect(10,10,150,50);
		string buttonText = Advertisement.IsReady ("rewardedVideoZone") ? "Show Ad" : "Waiting...";

		if (GUI.Button (buttonRect, buttonText)) {
			Advertisement.Show("rewardedVideoZone");
			GameControl.control.numOfBlocks += 10;
		}
	}
}
