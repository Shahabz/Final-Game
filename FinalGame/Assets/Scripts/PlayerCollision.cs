using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{
	public UnityEvent onPlayerCollisionEnemy;
	public UnityEvent winLevel;
	public GameObject player;


	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "enemy") {
			onPlayerCollisionEnemy.Invoke ();
		}
	}
		
}

