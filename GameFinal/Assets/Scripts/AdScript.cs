using UnityEngine;
using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class AdScript : MonoBehaviour {

	public static void ShowRewardedAd()
	{
		if (Advertisement.IsReady ("rewardedVideo")) {

//			ShowOptions options = new ShowOptions();
//			options.resultCallback = HandleShowResult;
//			Advertisement.Show("rewardedVideoZone", options);				

//			var options = new ShowOptions { resultCallback = HandleShowResult };

//			Advertisement.Show("rewardedVideoZone", options);				
//			Advertisement.Show(options,	"rewardedVideoZone");			
			Advertisement.Show ("rewardedVideo");
			GameControl.control.numOfBlocks += 5;
			GameControl.control.Save();
		} 
//		else {
//			StoreManager.disableAdButton = true;
//		}

	}

		private static void HandleShowResult(ShowResult result)
		{
			switch (result)
			{
			case ShowResult.Finished:
				Debug.Log("The ad was successfully shown.");
				GameControl.control.numOfBlocks += 5;
				//
				// YOUR CODE TO REWARD THE GAMER
				// Give coins etc.
				//GameControl.control.numOfBlocks += 5;
				break;
			case ShowResult.Skipped:
				Debug.Log("The ad was skipped before reaching the end.");
				break;
			default:
				Debug.Log("123");
			break;
		//	case ShowResult.Failed:
		//		Debug.LogError("The ad failed to be shown.");
		//		break;
			}
	}
}
