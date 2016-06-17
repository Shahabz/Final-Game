using UnityEngine;
using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class AdScript : MonoBehaviour {

	public static void ShowRewardedAd()
	{
		if (Advertisement.IsReady ("rewardedVideoZone")) {
			//var options = new ShowOptions { resultCallback = HandleShowResult };
			//Advertisement.Show("rewardedVideoZone", options);				
			Advertisement.Show ("rewardedVideoZone");
			GameControl.control.numOfBlocks += 5;
		}

	}

		private void HandleShowResult(ShowResult result)
		{
			switch (result)
			{
			case ShowResult.Finished:
				Debug.Log("The ad was successfully shown.");
				//
				// YOUR CODE TO REWARD THE GAMER
				// Give coins etc.
				GameControl.control.numOfBlocks += 5;
				break;
			case ShowResult.Skipped:
				Debug.Log("The ad was skipped before reaching the end.");
				break;
			case ShowResult.Failed:
				Debug.LogError("The ad failed to be shown.");
				break;
			}
		}
	}
