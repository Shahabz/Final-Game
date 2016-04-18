using UnityEngine;
using System.Collections;

public class BlockModel : MonoBehaviour {

	public GameObject block;

	// Use this for initialization
	void Start () {
		block.transform.position = new Vector3 (2.25f, -3.96f, 0f);
		block.transform.rotation = Quaternion.Euler (block.transform.rotation.x, block.transform.rotation.y, 50f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void HandlePlayerDraggedBlock ()
	{
		block.transform.position = new Vector3 (block.transform.position.x + 0.05f, block.transform.position.y, 0f); 
	}

	public void HandlePlayerRotatedBlock ()
	{

	}

	public void HandlePlayerEnlargeBlock ()
	{

	}

	public void HandlePlayerShrinkBlock ()
	{

	}

	public void HandleCollisionWithMarble ()
	{

	}
}
