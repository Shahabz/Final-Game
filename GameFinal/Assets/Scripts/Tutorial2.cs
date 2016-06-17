using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tutorial2 : MonoBehaviour {

	public GameObject leftHand;
	public GameObject leftHandWithBlock;
	public GameObject text1;
	public GameObject text2;
	public GameObject text3;
	public GameObject text4;
	public GameObject emptyBlock;
	public GameObject ringWithBlock;
	public GameObject rightHand;
	public GameObject ringBlockHand;
	public GameObject handPinchBlock;
	public GameObject darkBeckground;
	public Button skipButton;

	public Sprite handRegularBlock1;
	public Sprite handRegularBlock2;
	public Sprite handSmallBlock;
	public Sprite handBigBlock;

	public bool skipTutorial = false;
	public static bool continueTutorial = false;
	private bool emptyBlockIsShowing = false;

	// Use this for initialization
	void Start () {

		LevelManager.isTutorialRunning = true;
		skipTutorial = false;
		leftHand.GetComponent<SpriteRenderer>().enabled = true;
		leftHandWithBlock.GetComponent<SpriteRenderer>().enabled = false;
		text1.GetComponent<SpriteRenderer>().enabled = true;
		text2.GetComponent<SpriteRenderer>().enabled = false;
		text3.GetComponent<SpriteRenderer>().enabled = false;
		text4.GetComponent<SpriteRenderer>().enabled = false;
		emptyBlock.GetComponent<SpriteRenderer>().enabled = false;
		ringWithBlock.GetComponent<SpriteRenderer>().enabled = false;
		rightHand.GetComponent<SpriteRenderer>().enabled = false;
		ringBlockHand.GetComponent<SpriteRenderer>().enabled = false;
		handPinchBlock.GetComponent<SpriteRenderer>().enabled = false;
		darkBeckground.GetComponent<SpriteRenderer>().enabled = true;
		StartCoroutine (Tutorial ());	
	
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log(continueTutorial);
		if (PauseMenuManager.MenuIsOpen && emptyBlockIsShowing) {
			emptyBlock.GetComponent<SpriteRenderer>().enabled = false;
		} else if (!PauseMenuManager.MenuIsOpen && emptyBlockIsShowing) {
			emptyBlock.GetComponent<SpriteRenderer>().enabled = true;
		}
		if (continueTutorial)
		{
			StartCoroutine (ContinueTutorial ());	
		}

		if (skipTutorial)
		{
			continueTutorial = false;
			leftHand.GetComponent<SpriteRenderer>().enabled = false;
			leftHandWithBlock.GetComponent<SpriteRenderer>().enabled = false;
			text1.GetComponent<SpriteRenderer>().enabled = false;
			text2.GetComponent<SpriteRenderer>().enabled = false;
			text3.GetComponent<SpriteRenderer>().enabled = false;
			text4.GetComponent<SpriteRenderer>().enabled = false;
			emptyBlock.GetComponent<SpriteRenderer>().enabled = false;
			ringWithBlock.GetComponent<SpriteRenderer>().enabled = false;
			rightHand.GetComponent<SpriteRenderer>().enabled = false;
			ringBlockHand.GetComponent<SpriteRenderer>().enabled = false;
			handPinchBlock.GetComponent<SpriteRenderer>().enabled = false;
			darkBeckground.GetComponent<SpriteRenderer>().enabled = false;
			skipButton.enabled = false;
			skipButton.image.enabled = false; 
			LevelManager.isTutorialRunning = false;

		}
	}


	public IEnumerator Tutorial() {
		
		yield return new WaitForSeconds (1.5f);
		if (!skipTutorial)
		{
		leftHand.GetComponent<SpriteRenderer>().enabled = false;
		leftHandWithBlock.GetComponent<SpriteRenderer>().enabled = true;
		yield return new WaitForSeconds (0.2f);
		text2.GetComponent<SpriteRenderer>().enabled = true;
		emptyBlock.GetComponent<SpriteRenderer>().enabled = true;
		emptyBlockIsShowing = true;
		}
		yield return new WaitForSeconds (1f);
		if (!skipTutorial)
		{
		ringWithBlock.GetComponent<SpriteRenderer>().enabled = true;
		yield return new WaitForSeconds (0.2f);
		leftHandWithBlock.GetComponent<SpriteRenderer>().enabled = false;
		rightHand.GetComponent<SpriteRenderer>().enabled = true;
		yield return new WaitForSeconds (1f);
		ringBlockHand.GetComponent<SpriteRenderer>().enabled = true;
		rightHand.GetComponent<SpriteRenderer>().enabled = false;
		ringWithBlock.GetComponent<SpriteRenderer>().enabled = false;
		}
		yield return new WaitForSeconds (2.2f);
		if (!skipTutorial)
		{
		ringBlockHand.GetComponent<SpriteRenderer>().enabled = false;
		darkBeckground.GetComponent<SpriteRenderer>().enabled = false;
		text1.GetComponent<SpriteRenderer>().enabled = false;
		text2.GetComponent<SpriteRenderer>().enabled = false;
		}
		LevelManager.isTutorialRunning = false;
	}

	public IEnumerator ContinueTutorial()		
	{
		LevelManager.isTutorialRunning = true;
		continueTutorial = false;
		yield return new WaitForSeconds (1f);
		if (!skipTutorial)
		{
		darkBeckground.GetComponent<SpriteRenderer>().enabled = true;

		text3.GetComponent<SpriteRenderer>().enabled = true;
		handPinchBlock.GetComponent<SpriteRenderer>().enabled = true;
		handPinchBlock.GetComponent<SpriteRenderer>().sprite = handRegularBlock1;
		emptyBlock.GetComponent<SpriteRenderer>().enabled = false;
		emptyBlockIsShowing = false;
		}
		yield return new WaitForSeconds (0.9f);
		handPinchBlock.GetComponent<SpriteRenderer>().sprite = handRegularBlock2;
		yield return new WaitForSeconds (0.9f);
		handPinchBlock.GetComponent<SpriteRenderer>().sprite = handBigBlock;
		yield return new WaitForSeconds (0.9f);
		if (!skipTutorial)
		{
		handPinchBlock.GetComponent<SpriteRenderer>().sprite = handSmallBlock;
		text3.GetComponent<SpriteRenderer>().enabled = false;
		text4.GetComponent<SpriteRenderer>().enabled = true;
		}
		yield return new WaitForSeconds (0.9f);
		handPinchBlock.GetComponent<SpriteRenderer>().sprite = handRegularBlock1;
		yield return new WaitForSeconds (0.9f);
		handPinchBlock.GetComponent<SpriteRenderer>().sprite = handSmallBlock;

		yield return new WaitForSeconds (1.6f);
		if (!skipTutorial)
		{
		handPinchBlock.GetComponent<SpriteRenderer>().enabled = false;
		text4.GetComponent<SpriteRenderer>().enabled = false;
		emptyBlock.GetComponent<SpriteRenderer>().enabled = true;
		emptyBlockIsShowing = true;
		darkBeckground.GetComponent<SpriteRenderer>().enabled = false;
		}
		emptyBlock.GetComponent<SpriteRenderer>().enabled = false;
		emptyBlockIsShowing = false;
		emptyBlockIsShowing = false;
		skipButton.image.enabled = false; 
		LevelManager.isTutorialRunning = false;
	}
		
	public void HandlePressStart()
	{
		emptyBlock.GetComponent<SpriteRenderer>().enabled = false;
		emptyBlockIsShowing = false;
		skipButton.image.enabled = false; 
	}

	public void HandleSkipTutorial()
	{		
		skipTutorial = true;
	}
}
