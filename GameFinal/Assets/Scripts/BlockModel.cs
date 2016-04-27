﻿using UnityEngine;
using System.Collections;

public class BlockModel : MonoBehaviour
{
	private static Sprite currBlock;
	private static Sprite bigBlock;
	private static Sprite regularBlock;
	private static Sprite smallBlock;
	private SpriteRenderer blockSprite;
	private GameObject ring;
	bool isPressed;

	void OnMouseDown ()
	{
		StartCoroutine (MouseOnBlock ());
		//isPressed = true;
	}

	// Use this for initialization
	void Start ()
	{
		blockSprite = gameObject.GetComponent<SpriteRenderer>();
		bigBlock = Resources.Load<Sprite>("Textures/bigblock");
		regularBlock = Resources.Load<Sprite>("Textures/block");
		smallBlock = Resources.Load<Sprite>("Textures/smallblock");
		currBlock = regularBlock;
	}

	// Update is called once per frame
	void Update ()
	{
		//Debug.Log (isPressed);
		if(isPressed) 
		{
			if (Input.GetMouseButtonDown(0) && !RingScript.pressOnRing) {
				//Debug.Log ("hi");
				isPressed = false;
				Destroy (ring);
			}

			ring.transform.position = transform.position;
			transform.rotation = ring.transform.rotation;

			//blockSprite.sprite = currBlock;
		}
		blockSprite.sprite = currBlock;
	}

	public void HandlePlayerEnlargeBlock ()
	{
		Debug.Log (1);
		Debug.Log (isPressed);
		if (isPressed) {
			Debug.Log (2);
			if (currBlock == smallBlock) {			
				currBlock = regularBlock;
			} else if (currBlock == bigBlock) {			
				currBlock = bigBlock;
			} else if (currBlock == regularBlock) {			
				currBlock = bigBlock;
			}
		}
	}

	public void HandlePlayerShrinkBlock ()
	{
		if (isPressed) {
			if (currBlock == smallBlock) {
				currBlock = smallBlock;
			} else if (currBlock == bigBlock) {			
				currBlock = regularBlock;
			} else if (currBlock == regularBlock) {
				currBlock = smallBlock;
			}
		}
	}

	public void HandleCollisionWithMarble ()
	{
		Destroy (gameObject);
	}

	public void HandleClickOnScreen() {
		//Debug.Log ("click screen");
		//isPressed = false;
		//Destroy (ring);
	}

	public IEnumerator MouseOnBlock () {
		//Debug.Log (isPressed);
		yield return new WaitForSeconds (0.02f);
		isPressed = true;
		Destroy (ring);
		ring = Instantiate (Resources.Load ("ring"), new Vector2 (transform.position.x, transform.position.y), Quaternion.identity) as GameObject;		
		ring.transform.rotation = transform.rotation;
	}
}
