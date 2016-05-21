using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class MarbleCollision : MonoBehaviour
{
	public UnityEvent onMarbleCollisionDestination;
	public UnityEvent winLevel;
	public static int[] kindOfBlock;
	public GameObject starParticles;


	void OnCollisionEnter2D (Collision2D other)
	{		
		if (other.gameObject.tag == "block") {
			Vector3 blockPos = other.transform.position;
			Instantiate (starParticles, blockPos, other.transform.rotation);
			StartCoroutine (DestroyBlock (other.gameObject));
			//Destroy (other.gameObject);
		}

		if (other.gameObject.tag == "destination") {
			onMarbleCollisionDestination.Invoke ();
			winLevel.Invoke ();
		}
	}

	public IEnumerator DestroyBlock(GameObject other) {
		//Instantiate (starParticles, other.transform.position, other.transform.rotation);
		yield return new WaitForSeconds (0.01f);
//		Debug.Log( other.GetComponent<SpriteRenderer>().sprite.name);
		addKindOfBlock(other.GetComponent<SpriteRenderer>().sprite.name);
//		Debug.Log(kindOfBlock[0] + " " + kindOfBlock[1] + " " + kindOfBlock[2]);	
		Destroy (other);
	}

	public void addKindOfBlock(string kindOfCurrentBlock){
		switch(kindOfCurrentBlock){
		case"smallblock":
			kindOfBlock[0]++;
			break;
		case"block":
			kindOfBlock[1]++;
			break;
		case"bigblock":
			kindOfBlock[2]++;
			break;
		}
	}
}

