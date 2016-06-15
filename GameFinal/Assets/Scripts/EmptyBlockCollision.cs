using UnityEngine;
using System.Collections;

public class EmptyBlockCollision : MonoBehaviour {


	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "block") {
			
			UnityEngine.Debug.Log("Hit");
		}
	}
}
