using UnityEngine;
using System.Collections;

public class KeyScript : MonoBehaviour {

	private bool keyCollected = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void HandleKeyCollected() {
		if (!keyCollected) {
			keyCollected =true;
			StartCoroutine (removeKey ());
		}
	}

	// DOESNT WORK...
	public IEnumerator removeKey() {
		yield return new WaitForSeconds (0.1f);
		SoundManager.openLock = true;
		Instantiate (Resources.Load ("keyParticle"), new Vector2 (transform.position.x, transform.position.y), Quaternion.identity);
		Destroy (gameObject);
		// INSERT ANIMATION OR PARTICLES
		// INSERT SOUND
	}
}
