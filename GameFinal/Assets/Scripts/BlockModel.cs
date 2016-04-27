using UnityEngine;
using System.Collections;

public class BlockModel : MonoBehaviour
{

	public GameObject block;
	public Sprite bigBlock;
	public Sprite regularBlock;
	public Sprite smallBlock;
	private SpriteRenderer blockSprite;
	private Sprite currBlock;


	// Use this for initialization
	void Start ()
	{
		blockSprite = block.GetComponent<SpriteRenderer> ();
		currBlock = regularBlock;

		// the starting location of the block
		block.transform.position = new Vector3 (2.25f, -3.96f, 0f);

		// the rotation of the block - change the z value to change the rotation
		block.transform.rotation = Quaternion.Euler (block.transform.rotation.x, block.transform.rotation.y, 50f);
	}

	// Update is called once per frame
	void Update ()
	{
		blockSprite.sprite = currBlock;
	}

	public void HandlePlayerDraggedBlock ()
	{
		
	}

	public void HandlePlayerRotatedBlock ()
	{

	}

	public void HandlePlayerEnlargeBlock ()
	{
		if (blockSprite.sprite == regularBlock)
			currBlock = bigBlock;

		if (blockSprite.sprite == smallBlock)
			currBlock = regularBlock;

		if (blockSprite.sprite == bigBlock)
			currBlock = bigBlock;
	}

	public void HandlePlayerShrinkBlock ()
	{
		if (blockSprite.sprite == regularBlock)
			currBlock = smallBlock;

		if (blockSprite.sprite == bigBlock)
			currBlock = regularBlock;

		if (blockSprite.sprite == smallBlock)
			currBlock = smallBlock;
	}

	public void HandleCollisionWithMarble ()
	{
		Destroy (block);
	}


}
