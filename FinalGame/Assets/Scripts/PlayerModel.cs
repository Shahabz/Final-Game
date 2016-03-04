using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;

public class PlayerModel : MonoBehaviour
{

	public GameObject player;
	public bool isDead = false;
	private bool swipedUp = false;
	public static bool levelEnd = false;
	public GameObject gameover;
	public GameObject winner;


	void Start ()
	{
		player.transform.position = new Vector3 (0.84f, 8.97f - 1f, player.transform.position.z);
	}



	void Update ()
	{
		if (!isDead) {
			if (!swipedUp) {
				if (player.transform.position.y < -75f) {
					if (!levelEnd) {
						levelEnd = true;
					}
				} else {
					player.transform.position = new Vector3 (player.transform.position.x, player.transform.position.y - 0.1f, 0f);
				}
			} else {
				player.transform.position = new Vector3 (player.transform.position.x, player.transform.position.y - 0.02f, 0f);
			}
		}

		if (BasketController.stopped)
			player.transform.position = new Vector3 (player.transform.position.x, player.transform.position.y - 0.15f, 0f);
		
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

	public void HandleSwipeUp ()
	{
		StartCoroutine (slowed());
	}

	public void HandleEnemyCollision ()
	{
		isDead = true;
		Instantiate (gameover, new Vector2 (0, player.transform.position.y - 2.5f), Quaternion.identity);

	}

	public void HandleWinLevel () {
		Instantiate (winner, new Vector2 (0, player.transform.position.y - 2.5f), Quaternion.identity);
	}
		

	IEnumerator slowed() {
		swipedUp = true;
		yield return new WaitForSeconds (2f);
		swipedUp = false;
	}

}
