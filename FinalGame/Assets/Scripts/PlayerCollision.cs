using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour {
	public UnityEvent onPlayerCollisionEnemy;


	void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag == "enemy")			
			onPlayerCollisionEnemy.Invoke();
		}
	}

