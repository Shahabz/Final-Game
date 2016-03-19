using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{
	public UnityEvent onPlayerCollisionObsticle;
	public UnityEvent winLevel;
	public GameObject blood;
	public UnityEvent onPlayerCollisionCoin;
	public UnityEvent onPlayerCollisionBubble;
	public UnityEvent onPlayerCollisionFire;
	public UnityEvent popBubble;

	void OnCollisionEnter2D (Collision2D other)
	{
		
		if (other.gameObject.tag == "obsticle") {

			if (PlayerModel.inFire) {
				Destroy (other.gameObject);
			} else if (PlayerModel.inBubble) {
				PlayerModel.inBubble = false;
				Destroy (other.gameObject);
				popBubble.Invoke ();
			} else {
				onPlayerCollisionObsticle.Invoke ();
				Instantiate (blood, new Vector2 (transform.position.x, transform.position.y), Quaternion.identity);
			}
		}

		if (other.gameObject.tag == "coin") {
			onPlayerCollisionCoin.Invoke ();
			Destroy(other.gameObject);
			// insert sound effect and yay! effect
		}

		if (other.gameObject.tag == "bubble") {
			onPlayerCollisionBubble.Invoke ();
			Destroy(other.gameObject);
			// change player image to with bubble for few seconds...
		}

		if (other.gameObject.tag == "fire") {
			onPlayerCollisionFire.Invoke ();
			Destroy(other.gameObject);
			// change player image to with fire for few seconds...
		}
	}


		
}

