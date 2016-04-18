using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class MarbleCollision : MonoBehaviour
{
	public UnityEvent onMarbleCollisionBlock;
	public UnityEvent onMarbleCollisionDestination;
	public UnityEvent winLevel;

	void OnCollisionEnter2D (Collision2D other)
	{
		
		if (other.gameObject.tag == "block") {
			onMarbleCollisionBlock.Invoke ();
			//Instantiate (blood, new Vector2 (transform.position.x, transform.position.y), Quaternion.identity);

		}

		if (other.gameObject.tag == "destination") {
			onMarbleCollisionDestination.Invoke ();
		}
			
	}


		
}

