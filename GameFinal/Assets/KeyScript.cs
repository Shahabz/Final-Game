using UnityEngine;
using System.Collections;

public class KeyScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void HandleKeyCollected() {
		StartCoroutine (removeKey ());
	}

	// DOESNT WORK...
	public IEnumerator removeKey() {
		yield return new WaitForSeconds (0.1f);
		Destroy (gameObject);
		SoundManager.openLock = true;
		// INSERT ANIMATION OR PARTICLES
		// INSERT SOUND
	}
}
