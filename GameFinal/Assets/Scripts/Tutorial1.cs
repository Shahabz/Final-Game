using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Tutorial1 : MonoBehaviour {



	public GameObject leftHand;
	public GameObject handWithBlock;
	public GameObject emptyBlock;
	public GameObject text1;
	public GameObject text2;
	public GameObject darkBeckground;

	public GameObject ring;
	public GameObject text3;
	public GameObject handBlockRing;
	public GameObject rightHand;
	public GameObject text4;

	public  bool continueTutorial = false;
	public static bool continueTutorial1 = false;
	public static bool continueTutorial2 = false;
	private bool emptyBlockIsShowing = false;

	// Use this for initialization
	void Start () {
		continueTutorial1 = false;
		continueTutorial2 = false;
		LevelManager.isTutorialRunning = true;
		leftHand.GetComponent<SpriteRenderer>().enabled = true;
		handWithBlock.transform.position = new Vector3(-2.44f, -8.31f,0f);
		text1.transform.position = new Vector3(7.13f,-0.63f,0f);
		text2.GetComponent<SpriteRenderer>().enabled = false;
		emptyBlock.GetComponent<SpriteRenderer>().enabled = false;
		ring.GetComponent<SpriteRenderer>().enabled = false;
		text3.GetComponent<SpriteRenderer>().enabled = false;
		handBlockRing.GetComponent<SpriteRenderer>().enabled = false;
		rightHand.GetComponent<SpriteRenderer>().enabled = false;
		text4.GetComponent<SpriteRenderer>().enabled = false;
		darkBeckground.GetComponent<SpriteRenderer>().enabled = true;
		StartCoroutine (Tutorial ());	

	}
	
	// Update is called once per frame
	void Update () {
		if (PauseMenuManager.MenuIsOpen && emptyBlockIsShowing) {
			emptyBlock.GetComponent<SpriteRenderer>().enabled = false;
		} else if (!PauseMenuManager.MenuIsOpen && emptyBlockIsShowing) {
			emptyBlock.GetComponent<SpriteRenderer>().enabled = true;
		}

		if(continueTutorial1)
		{
			StartCoroutine (ContinueTutorial1 ());	
		}

		if(continueTutorial2)
		{
			StartCoroutine (ContinueTutorial2 ());	
		}
	}
		
		public IEnumerator Tutorial() {
			yield return new WaitForSeconds (3f);
		leftHand.GetComponent<SpriteRenderer>().enabled = false;
		yield return new WaitForSeconds (0.7f);
		emptyBlock.GetComponent<SpriteRenderer>().enabled = true;
		emptyBlockIsShowing = true;
		yield return new WaitForSeconds (0.6f);
		text2.GetComponent<SpriteRenderer>().enabled = true;
		yield return new WaitForSeconds (3f);
		text1.GetComponent<SpriteRenderer>().enabled = false;
		text2.GetComponent<SpriteRenderer>().enabled = false;
		handWithBlock.GetComponent<SpriteRenderer>().enabled = false;
		darkBeckground.GetComponent<SpriteRenderer>().enabled = false;
		LevelManager.isTutorialRunning = false;
//		StartCoroutine (Tutorial2 ());
	}

	public IEnumerator Tutorial2() {
		yield return new WaitForSeconds (3f);
		darkBeckground.GetComponent<SpriteRenderer>().enabled = true;
//		emptyBlock.transform.position = new Vector3(3.23f, -1.27f, 0f);
		emptyBlock.transform.rotation =  Quaternion.Euler(0, 0, 238);
		ring.GetComponent<SpriteRenderer>().enabled = true;
		text3.GetComponent<SpriteRenderer>().enabled = true;
		rightHand.GetComponent<SpriteRenderer>().enabled = true;
		yield return new WaitForSeconds (5.95f);
		handBlockRing.GetComponent<SpriteRenderer>().enabled = true;
		ring.GetComponent<SpriteRenderer>().enabled = false;
		rightHand.GetComponent<SpriteRenderer>().enabled = false;
		yield return new WaitForSeconds (6f);
		handBlockRing.GetComponent<SpriteRenderer>().enabled = false;
		darkBeckground.GetComponent<SpriteRenderer>().enabled = false;
		text3.GetComponent<SpriteRenderer>().enabled = false;
		yield return new WaitForSeconds (4f);
		text4.GetComponent<SpriteRenderer>().enabled = true;
		darkBeckground.GetComponent<SpriteRenderer>().enabled = true;
		yield return new WaitForSeconds (5f);
		text4.GetComponent<SpriteRenderer>().enabled = false;
		darkBeckground.GetComponent<SpriteRenderer>().enabled = false;

		emptyBlock.layer = 10;
	}

	public IEnumerator ContinueTutorial1() 
	{
		LevelManager.isTutorialRunning = true;
		continueTutorial1 = false;
		yield return new WaitForSeconds (1f);
		darkBeckground.GetComponent<SpriteRenderer>().enabled = true;
		//		emptyBlock.transform.position = new Vector3(3.23f, -1.27f, 0f);
		emptyBlock.transform.rotation =  Quaternion.Euler(0, 0, 238);
		ring.GetComponent<SpriteRenderer>().enabled = true;
		text3.GetComponent<SpriteRenderer>().enabled = true;
		rightHand.GetComponent<SpriteRenderer>().enabled = true; 
		yield return new WaitForSeconds (5.95f);
		handBlockRing.GetComponent<SpriteRenderer>().enabled = true; 
		ring.GetComponent<SpriteRenderer>().enabled = false;
		rightHand.GetComponent<SpriteRenderer>().enabled = false; 
		yield return new WaitForSeconds (6f);
		handBlockRing.GetComponent<SpriteRenderer>().enabled = false;
		darkBeckground.GetComponent<SpriteRenderer>().enabled = false;
		text3.GetComponent<SpriteRenderer>().enabled = false;
		LevelManager.isTutorialRunning = false;

	}

	public IEnumerator ContinueTutorial2() 
	{
		LevelManager.isTutorialRunning = true;
		continueTutorial2 = false;
		yield return new WaitForSeconds (1f);
		text4.GetComponent<SpriteRenderer>().enabled = true;
		darkBeckground.GetComponent<SpriteRenderer>().enabled = true;
		yield return new WaitForSeconds (5f);
		text4.GetComponent<SpriteRenderer>().enabled = false;
		darkBeckground.GetComponent<SpriteRenderer>().enabled = false;

		emptyBlock.layer = 10;
		LevelManager.isTutorialRunning = false;
	}


	public void HandleBlockInPosition()
	{
//		continueTutorial = true;
	}

	public void HandleBlockWasRotationed()
	{
//		continueTutorial = true;
	}

	public void HandlePressStart()
	{
		emptyBlock.GetComponent<SpriteRenderer>().enabled = false;
		emptyBlockIsShowing = false;
	}
}
