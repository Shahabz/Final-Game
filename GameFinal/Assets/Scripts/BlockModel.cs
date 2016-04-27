using UnityEngine;
using System.Collections;

public class BlockModel : MonoBehaviour
{

	//public GameObject block;
	private static Sprite bigBlock;
	private static Sprite regularBlock;
	private Texture regular;
	private static Sprite smallBlock;
	private SpriteRenderer blockSprite;
	private static Sprite currBlock;


	// Use this for initialization
	void Start ()
	{
		blockSprite = gameObject.GetComponent<SpriteRenderer>();

		bigBlock = Resources.Load<Sprite>("Textures/bigblock");
		regularBlock = Resources.Load<Sprite>("Textures/block");
		regular = Resources.Load<Texture>("Textures/block");
		smallBlock = Resources.Load<Sprite>("Textures/smallblock");
		//smallBlock = Resources.Load<UnityEngine.Sprite>("Textures/smallblock");

		currBlock = regularBlock;
		currBlock = smallBlock;
		//blockSprite.sprite = currBlock;

		// the starting location of the block
		transform.position = new Vector3 (2.25f, -3.96f, 0f);

		// the rotation of the block - change the z value to change the rotation
		transform.rotation = Quaternion.Euler (transform.rotation.x, transform.rotation.y, 50f);
	}

	// Update is called once per frame
	void Update ()
	{
		blockSprite.sprite = currBlock;

		//GetComponent<SpriteRenderer> ().sprite = currBlock;
	}

	public void HandlePlayerDraggedBlock ()
	{
		
	}

	public void HandlePlayerRotatedBlock ()
	{

	}

	public void HandlePlayerEnlargeBlock ()
	{
		//GetComponent<SpriteRenderer> ().sprite = bigBlock;
		Debug.Log("hi");
		if (currBlock == smallBlock) {
			//Debug.Log (currBlock.name);
			currBlock = regularBlock;
		} else if (currBlock == bigBlock) {
			Debug.Log ("here3");
			currBlock = bigBlock;
		} else if (currBlock == regularBlock) {
			Debug.Log ("here1");
			currBlock = bigBlock;
		}
	}

	public void HandlePlayerShrinkBlock ()
	{

		if (currBlock == smallBlock) {
			//Debug.Log (currBlock.name);
			currBlock = smallBlock;
		} else if (currBlock == bigBlock) {
			Debug.Log ("here3");
			currBlock = regularBlock;
		} else if (currBlock == regularBlock) {
			Debug.Log ("here1");
			currBlock = smallBlock;
		}



		//Debug.Log ("ds");
		//gameObject.GetComponent<SpriteRenderer>().sprite = regularBlock;
		//blockSprite.sprite = regularBlock;
		//if (gameObject.GetComponent<SpriteRenderer>().sprite.texture == regular) {
		//	Debug.Log (gameObject.GetComponent<SpriteRenderer> ().sprite.texture);
		//	Debug.Log ("here4");
		//	currBlock = smallBlock;
		//}

		//if (gameObject.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("Textures/bigblock")) {
		//	Debug.Log ("here5");
		//	currBlock = regularBlock;
		//}

		//if (gameObject.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("Textures/smallblock")) {
		//	Debug.Log ("here6");
		//	currBlock = smallBlock;

		//}

	}

	public void HandleCollisionWithMarble ()
	{
		Destroy (gameObject);
	}


}
