using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class MarbleCollision : MonoBehaviour
{
	public UnityEvent onMarbleCollisionDestination;
	public UnityEvent winLevel;

	void OnCollisionEnter2D (Collision2D other)
	{		
		if (other.gameObject.tag == "block") {
			StartCoroutine (DestroyBlock (other.gameObject));
			//Destroy (other.gameObject);
		}

		if (other.gameObject.tag == "destination") {
			onMarbleCollisionDestination.Invoke ();
			winLevel.Invoke ();
		}
	}

	public IEnumerator DestroyBlock(GameObject other) {
		yield return new WaitForSeconds (0.01f);
		Destroy (other);
	}
}

