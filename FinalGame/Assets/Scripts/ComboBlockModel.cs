using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class ComboBlockModel : MonoBehaviour {

	public GameObject combo;
	public float startY;
	public float onScreenY;
	public float exitScreenY;
	public UnityEvent comboDone;
	public bool chosen = false;
	public bool needsToMove = false;

	// Use this for initialization
	void Start () {
		//combo.transform.position = new Vector2 (0f, startY);
	}
	
	// Update is called once per frame
	void Update () {
		
		if ((chosen == true) && (onScreenY < combo.transform.position.y)) {
			comboDone.Invoke ();
			chosen = false;
		}

		//if (needsToMove) {
			combo.transform.position = new Vector2 (combo.transform.position.x, combo.transform.position.y + GravityModel.speed);
		//}
	}

	public void HandleChosen() 
	{
		if (exitScreenY < combo.transform.position.y) {
			combo.transform.position = new Vector2 (0f, startY);
			chosen = true;
		} else {
			comboDone.Invoke ();
			chosen = false;
		}
	}
}
