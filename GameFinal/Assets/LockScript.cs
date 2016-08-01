using UnityEngine;
using System.Collections;

public class LockScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void HandleKeyCollected() {
		StartCoroutine (removeLock ());
	}

	// DOESNT WORK...
	public IEnumerator removeLock() {
		yield return new WaitForSeconds (0.3f);
		Destroy (gameObject);
		// INSERT ANIMATION OR PARTICLES
		// INSERT SOUND
	}
}
