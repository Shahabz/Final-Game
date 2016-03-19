using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;

public class PlayerModel : MonoBehaviour
{

	public GameObject player;

	void Start ()
	{
		//player.transform.position = new Vector3 (0.84f, 8.97f - 1f, player.transform.position.z);
	}



	void Update ()
	{
	}


	//public SwipeController swipe;


	public void HandleSwipeRight ()
	{
		if (player.transform.position.x < 2.33f)
			player.transform.position = new Vector3 (player.transform.position.x + 1.49f, player.transform.position.y, 0);
	}

	public void HandleSwipeLeft ()
	{
		if (player.transform.position.x > -2f)
			player.transform.position = new Vector3 (player.transform.position.x - 1.49f, player.transform.position.y, 0);
	}
		
	public void HandleEnemyCollision ()
	{
		//Instantiate (gameover, new Vector2 (0, player.transform.position.y - 2.5f), Quaternion.identity);
		//Add blood reaction dead!!!!
	}
}