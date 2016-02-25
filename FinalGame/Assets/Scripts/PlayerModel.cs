using UnityEngine;
using System.Collections;

public class PlayerModel : MonoBehaviour {

	//public SwipeController swipe; 
	public GameObject player;

	public void HandleSwipeRight() {
		if (player.transform.position.x < 1f)
		player.transform.position = new Vector3(player.transform.position.x + 1.64f, player.transform.position.y,0);
		}

	public void HandleSwipeLeft() {
		if (player.transform.position.x > -2f)
		player.transform.position = new Vector3(player.transform.position.x - 1.64f, player.transform.position.y,0);
	}


}
