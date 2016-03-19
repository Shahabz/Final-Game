using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerModel : MonoBehaviour
{

	public GameObject player;
	public int score = 0;
	public Text scoreText;
	public Sprite chickInBubble;
	public Sprite chickInFire;
	public Sprite chickNormal;
	private SpriteRenderer chick;
	public static bool inFire = false;
	public static bool inBubble = false;

	void Start ()
	{
		chick = player.GetComponent<SpriteRenderer>();
		chick.sprite = chickNormal;
		scoreText.text = "Score: " + score;
		//player.transform.position = new Vector3 (0.84f, 8.97f - 1f, player.transform.position.z);
	}



	void Update ()
	{
	}
		

	//public SwipeController swipe;


	public void HandleSwipeRight ()
	{
		if (player.transform.position.x < 2.3f)
			player.transform.position = new Vector3 (player.transform.position.x + 2.2f, player.transform.position.y, 0);
	}

	public void HandleSwipeLeft ()
	{
		if (player.transform.position.x > -2f)
			player.transform.position = new Vector3 (player.transform.position.x - 2.2f, player.transform.position.y, 0);
	}
		
	public void HandleEnemyCollision ()
	{
		//if (!inBubble) {
		//	chick.sprite = chickNormal;
		//} else {	
			player.transform.rotation = Quaternion.Euler (player.transform.rotation.x, player.transform.rotation.y, 50f);
	//	}
	}

	public void HandleCoinCollision ()
	{
		score = score + 1;
		scoreText.text = "Score: " + score;
	}

	public void HandleBubbleCollision()
	{
		inBubble = true;
		chick.sprite = chickInBubble;
	}

	public void HandleFireCollision ()
	{
		StartCoroutine (Fire ());
		chick.sprite = chickInFire;
	}

	public void HandlePopBubble ()
	{
		chick.sprite = chickNormal;
	}

	IEnumerator Fire() {
		inFire = true;
		yield return new WaitForSeconds (3f);
		chick.sprite = chickNormal;
		inFire = false;
	}
		
}