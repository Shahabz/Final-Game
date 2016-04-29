using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class BlockStashModel : MonoBehaviour {

	public UnityEvent onPlayerClickNewBlock;

	void OnMouseDown () {
		onPlayerClickNewBlock.Invoke ();
	}
}
