using UnityEngine;
using System.Collections;


public class GravityModel : MonoBehaviour
{

	//public GameObject player;
	public static float speed;
	public bool doNotChangeSpeed = false;
	private bool isDead = false;


	// Use this for initialization
	void Start ()
	{
		//	player.transform.position = new Vector2 (-1.5f, -8f);
		speed = 0.08f;
		//speed = 0.3f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isDead)
			speed = 0f;
		
		if (!doNotChangeSpeed) {
			doNotChangeSpeed = true;
			StartCoroutine (Gravity ());
		}
		//	player.transform.position = new Vector2 (player.transform.position.x, player.transform.position.y + speed);

		//	if (player.transform.position.y > 4f) {
		//		player.transform.position = new Vector2 (-1.5f, -8f);
		//	}
	}


	public void HandleSwipeUp ()
	{
		StartCoroutine (slowed ());
	}


	IEnumerator slowed ()
	{
		speed = speed * 0.55f;
		yield return new WaitForSeconds (2f);
		speed = speed * 1.6f;
	}

	IEnumerator Gravity ()
	{
		if (!isDead) {
			yield return new WaitForSeconds (3f);
			speed = speed + 0.005f;
			doNotChangeSpeed = false;
		}
	}

	public void HandleDeath ()
	{
		isDead = true;
		speed = 0f;
	}
}
