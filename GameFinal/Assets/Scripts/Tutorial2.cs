using UnityEngine;
using System.Collections;

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

	public Sprite handRegularBlock1;
	public Sprite handRegularBlock2;
	public Sprite handSmallBlock;
	public Sprite handBigBlock;

	// Use this for initialization
	void Start () {

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
	
	}


	public IEnumerator Tutorial() {
		yield return new WaitForSeconds (2.5f);
		leftHand.GetComponent<SpriteRenderer>().enabled = false;
		leftHandWithBlock.GetComponent<SpriteRenderer>().enabled = true;
		yield return new WaitForSeconds (0.2f);
		text2.GetComponent<SpriteRenderer>().enabled = true;
		emptyBlock.GetComponent<SpriteRenderer>().enabled = true;
		yield return new WaitForSeconds (2f);
		ringWithBlock.GetComponent<SpriteRenderer>().enabled = true;
		yield return new WaitForSeconds (0.2f);
		leftHandWithBlock.GetComponent<SpriteRenderer>().enabled = false;
		rightHand.GetComponent<SpriteRenderer>().enabled = true;
		yield return new WaitForSeconds (1f);
		ringBlockHand.GetComponent<SpriteRenderer>().enabled = true;
		rightHand.GetComponent<SpriteRenderer>().enabled = false;
		ringWithBlock.GetComponent<SpriteRenderer>().enabled = false;

		yield return new WaitForSeconds (2.2f);
		ringBlockHand.GetComponent<SpriteRenderer>().enabled = false;
		darkBeckground.GetComponent<SpriteRenderer>().enabled = false;
		text1.GetComponent<SpriteRenderer>().enabled = false;
		text2.GetComponent<SpriteRenderer>().enabled = false;

		yield return new WaitForSeconds (4f);
		darkBeckground.GetComponent<SpriteRenderer>().enabled = true;

		text3.GetComponent<SpriteRenderer>().enabled = true;
		handPinchBlock.GetComponent<SpriteRenderer>().enabled = true;
		handPinchBlock.GetComponent<SpriteRenderer>().sprite = handRegularBlock1;
		emptyBlock.GetComponent<SpriteRenderer>().enabled = false;
		yield return new WaitForSeconds (1.5f);
		handPinchBlock.GetComponent<SpriteRenderer>().sprite = handRegularBlock2;
		yield return new WaitForSeconds (1.5f);
		handPinchBlock.GetComponent<SpriteRenderer>().sprite = handBigBlock;
		yield return new WaitForSeconds (1.5f);
		handPinchBlock.GetComponent<SpriteRenderer>().sprite = handSmallBlock;
		text3.GetComponent<SpriteRenderer>().enabled = false;
		text4.GetComponent<SpriteRenderer>().enabled = true;
		yield return new WaitForSeconds (1.5f);
		handPinchBlock.GetComponent<SpriteRenderer>().sprite = handRegularBlock1;
		yield return new WaitForSeconds (1.5f);
		handPinchBlock.GetComponent<SpriteRenderer>().sprite = handSmallBlock;

		yield return new WaitForSeconds (3f);
		handPinchBlock.GetComponent<SpriteRenderer>().enabled = false;
		text4.GetComponent<SpriteRenderer>().enabled = false;
		emptyBlock.GetComponent<SpriteRenderer>().enabled = true;
		darkBeckground.GetComponent<SpriteRenderer>().enabled = false;
	}

	public void HandlePressStart()
	{
		emptyBlock.GetComponent<SpriteRenderer>().enabled = false;
	}
}
