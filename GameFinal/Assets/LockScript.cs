using UnityEngine;
using System.Collections;

public class LockScript : MonoBehaviour {

	private bool keyCollected = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void HandleKeyCollected() {
		if(!keyCollected) {
			keyCollected = true;
			StartCoroutine (removeLock ());
		}
	}

	// DOESNT WORK...
	public IEnumerator removeLock() {
		FadeScript.unlocked = true;
		yield return new WaitForSeconds (0.2f);
		Instantiate (Resources.Load ("keyParticle"), new Vector2 (transform.position.x, transform.position.y - 1), Quaternion.identity);
		yield return new WaitForSeconds (0.1f);
		Destroy (gameObject);
		// INSERT ANIMATION OR PARTICLES
		// INSERT SOUND
	}
}
