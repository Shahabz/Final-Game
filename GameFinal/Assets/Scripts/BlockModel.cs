﻿using UnityEngine;
using System.Collections;

public class BlockModel : MonoBehaviour
{
	private Sprite currBlock;
	private static Sprite bigBlock;
	private static Sprite regularBlock;
	private static Sprite smallBlock;
	private SpriteRenderer blockSprite;
	private GameObject ring;
	private bool isPressed;
	private static bool gameStarted = false;

	private int blockIndex;

	void OnMouseDown ()
	{
		if (!gameStarted) {
			StartCoroutine (MouseOnBlock ());
		}
	}

	// Use this for initialization
	void Start ()
	{
		gameStarted = false;
		blockSprite = gameObject.GetComponent<SpriteRenderer> ();
		bigBlock = Resources.Load<Sprite> ("Textures/bigblock");
		regularBlock = Resources.Load<Sprite> ("Textures/block");
		smallBlock = Resources.Load<Sprite> ("Textures/smallblock");
		currBlock = regularBlock;
		blockSprite.sprite = currBlock;
		if (Input.GetMouseButton (0)) {
			OnMouseDown ();		
		}

		for (int i = 0; i < LevelManager.blocksSizes.Length; i++) {
			//Debug.Log (i);
			if (LevelManager.blocksSizes[i].Equals("")) {
				//Debug.Log ("index: " + i);
				blockIndex = i;
				break;
			}
		}
		LevelManager.blocksSizes[blockIndex] = "regular";
	}
	// Update is called once per frame
	void Update ()
	{
		if (gameStarted) {
			isPressed = false;
			Destroy (ring);
		} 
		//Destroy (GetComponent<PolygonCollider2D> ());
		//gameObject.AddComponent<PolygonCollider2D> ();
		//only if the block is highlighted
		if (isPressed) {
			PinchUpdate ();
			if (Input.GetKeyDown (KeyCode.UpArrow))
				HandlePlayerEnlargeBlock ();
			if (Input.GetKeyDown (KeyCode.DownArrow))
				HandlePlayerShrinkBlock ();
			
			//if click on background- remove highlight
			if (Input.GetMouseButtonDown (0) && !RingScript.pressOnRing) {
				StartCoroutine (RemoveRing ());
			}
			//ring follow block  and block rotate with ring
			ring.transform.position = transform.position;
			transform.rotation = ring.transform.rotation;
		}

	}
	public void HandlePlayerEnlargeBlock ()
	{
		if (currBlock == smallBlock) {			
			currBlock = regularBlock;
			LevelManager.blocksSizes [blockIndex] = "regular";
		} else if (currBlock == bigBlock) {			
			currBlock = bigBlock;
			LevelManager.blocksSizes [blockIndex] = "big";
		} else if (currBlock == regularBlock) {			
			currBlock = bigBlock;
			LevelManager.blocksSizes [blockIndex] = "big";
		}
			

		blockSprite.sprite = currBlock;
		Destroy(GetComponent<PolygonCollider2D>());
		gameObject.AddComponent<PolygonCollider2D>();
	}
	public void HandlePlayerShrinkBlock ()
	{
		if (currBlock == smallBlock) {
			currBlock = smallBlock;
			LevelManager.blocksSizes [blockIndex] = "small";
		} else if (currBlock == bigBlock) {			
			currBlock = regularBlock;
			LevelManager.blocksSizes [blockIndex] = "regular";
		} else if (currBlock == regularBlock) {
			currBlock = smallBlock;
			LevelManager.blocksSizes [blockIndex] = "small";
		}
		blockSprite.sprite = currBlock;
		Destroy(GetComponent<PolygonCollider2D>());
		gameObject.AddComponent<PolygonCollider2D>();
	}
	public IEnumerator RemoveRing ()
	{
		yield return new WaitForSeconds (0.1f);
		if (!twoFingers) {
			isPressed = false;
			Destroy (ring);
		}
	}
	//create new highlight with click on block
	public IEnumerator MouseOnBlock ()
	{
		yield return new WaitForSeconds (0.11f);
		isPressed = true;
		Destroy (ring);
		ring = Instantiate (Resources.Load ("ring"), new Vector2 (transform.position.x, transform.position.y), Quaternion.identity) as GameObject;		
		ring.transform.rotation = transform.rotation;
	}
	public void HandleGameStarted ()
	{
		gameStarted = true;
	}
	//pinch Code
	private bool isTouch = false;
	private float firstDistance = 0f;
	private float currentDistance = 0f;
	private float distance = 0f;
	public static bool twoFingers = false;
	void PinchUpdate ()
	{
		if (Input.touchCount == 2) {
			twoFingers = true;
			Touch firstFinger = Input.GetTouch (0);
			Touch secondFinger = Input.GetTouch (1);
			if (!isTouch) {				
				firstDistance = (firstFinger.position - secondFinger.position).magnitude;
				isTouch = true;
			} else {								
				currentDistance = (firstFinger.position - secondFinger.position).magnitude;				
				distance = firstDistance - currentDistance;
				if (distance > 52f) {
					HandlePlayerShrinkBlock ();
					isTouch = false;
				} else if (distance < -52f) {
					HandlePlayerEnlargeBlock ();
					isTouch = false;
				}
			}                  
		} else
			twoFingers = false;
	}
		
	void OnMouseUp ()
	{
		checkIfInStash();
	}


	private void checkIfInStash(){
		float positionX = gameObject.transform.position.x;
		float positionY = gameObject.transform.position.y;
		if (-2.65 < positionX  && positionX < -1.28 && -4.9 < positionY  && positionY < -4){
			LevelManager.blocksSizes [blockIndex] = null;
			Destroy(gameObject);
			Destroy(ring);
			isPressed = false;
			LevelManager.numOfLeftBlocks++;
			LevelManager.numOfUsedBlocks--;
		}			
	}


}