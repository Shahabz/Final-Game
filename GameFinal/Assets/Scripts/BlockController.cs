using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class BlockController : MonoBehaviour {

	public UnityEvent onPlayerDragBlock;
	public UnityEvent onPlayerEnlargeBlock;
	public UnityEvent onPlayerShrinkBlock;
	public UnityEvent onPlayerRotateBlock;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		// for now to test out on computer..
		if (Input.GetMouseButtonDown(0))
			onPlayerDragBlock.Invoke ();
		if (Input.GetKey (KeyCode.Space))
			onPlayerRotateBlock.Invoke ();
		if (Input.GetKeyDown (KeyCode.UpArrow))
			onPlayerEnlargeBlock.Invoke ();
		if (Input.GetKeyDown (KeyCode.DownArrow))
			onPlayerShrinkBlock.Invoke ();
		
	}
}
