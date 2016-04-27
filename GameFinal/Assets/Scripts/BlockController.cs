using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class BlockController : MonoBehaviour {

	public UnityEvent onPlayerEnlargeBlock;
	public UnityEvent onPlayerShrinkBlock;


	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.UpArrow))
			onPlayerEnlargeBlock.Invoke ();
		if (Input.GetKeyDown (KeyCode.DownArrow))
			onPlayerShrinkBlock.Invoke ();	
	}
}
