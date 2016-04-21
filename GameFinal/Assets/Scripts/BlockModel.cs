using UnityEngine;
using System.Collections;

public class BlockModel : MonoBehaviour {

	public GameObject block;

	// Use this for initialization
	void Start () {

		// the starting location of the block
		block.transform.position = new Vector3 (2.25f, -3.96f, 0f);

		// the rotation of the block - change the z value to change the rotation
		block.transform.rotation = Quaternion.Euler (block.transform.rotation.x, block.transform.rotation.y, 50f);
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void HandlePlayerDraggedBlock ()
	{
		
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
		Destroy (block);
	}
}
