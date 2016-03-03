using UnityEngine;
using System.Collections;

public class PlayerModel : MonoBehaviour {

	public GameObject player;
	public bool isDead = false;
	public GameObject gameover;


	void Start(){
		player.transform.position = new Vector3(0.84f,8.97f,player.transform.position.z);
	}



	void Update(){
		if (!isDead)
		player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y-0.1f,0f);
	}
		

	//public SwipeController swipe; 


	public void HandleSwipeRight() {
		if (player.transform.position.x < 2.33f)
		player.transform.position = new Vector3(player.transform.position.x + 1.49f, player.transform.position.y,0);
		}

	public void HandleSwipeLeft() {
		if (player.transform.position.x > -2f)
		player.transform.position = new Vector3(player.transform.position.x - 1.49f, player.transform.position.y,0);
	}

	public void HandleEnemyCollision() {
		isDead = true;
		Instantiate(gameover, new Vector2(0,-2), Quaternion.identity);


	}

}
