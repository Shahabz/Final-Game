using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject goodJob;
	public GameObject newBlock;
	public GameObject currentNewBlock;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0) && currentNewBlock){
			currentNewBlock.transform.position = new Vector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, 
				Camera.main.ScreenToWorldPoint (Input.mousePosition).y, 10f); 
		}
		if(Input.GetMouseButtonUp(0) && currentNewBlock){
			currentNewBlock = null;
		}
	}

	public void HandleOutOfBounds()
	{
		Application.LoadLevel (Application.loadedLevel);
	}

	public void HandleWinLevel() {
		Instantiate (goodJob, new Vector2(0f,0f), Quaternion.identity);
	}

	public void HandleClickedForAnotherBlock() {
		currentNewBlock = (GameObject) Instantiate (newBlock, new Vector2 (-2.5f, -4.7f), Quaternion.identity);
	}
}
