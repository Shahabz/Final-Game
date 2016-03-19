using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;

public class ComboManager : MonoBehaviour
{
	public int num = 1;
	public UnityEvent Chose1;
	public UnityEvent Chose2;
	public UnityEvent Chose3;
	public UnityEvent Chose4;
	public UnityEvent Chose5;
	public UnityEvent Chose6;
	private bool isDead = false;

	// Use this for initialization
	void Start ()
	{
		Chose1.Invoke ();
	}

	// Update is called once per frame
	void Update ()
	{
		
	}

	public void HandleDone ()
	{
		if (!isDead) {
			num = Random.Range (0, 6);
		
			switch (num) {

			case 0:
				Debug.Log (num);
				Chose1.Invoke ();
				break;
			case 1:
				Debug.Log (num);
				Chose2.Invoke ();
				break;
			case 2:
				Debug.Log (num);
				Chose3.Invoke ();
				break;
		
			case 3:
				Debug.Log (num);
				Chose4.Invoke ();
				break;
			case 4:
				Debug.Log (num);
				Chose5.Invoke ();
				break;

			default:
				Debug.Log (num);
				Chose6.Invoke ();
				break;

			}
		}
	}

	public void HandleDeath() {
		isDead = true;
	}
}
