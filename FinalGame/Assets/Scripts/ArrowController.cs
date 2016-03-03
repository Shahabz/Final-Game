using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class ArrowController : MonoBehaviour {

	public UnityEvent onPlayerSwipeRight;
	public UnityEvent onPlayerSwipeLeft;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.RightArrow))			
			onPlayerSwipeRight.Invoke();		
		if (Input.GetKeyDown(KeyCode.LeftArrow))
			onPlayerSwipeLeft.Invoke();	
	}
}
