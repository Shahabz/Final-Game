using UnityEngine;
using System.Collections;

public class BlockModel : MonoBehaviour
{
	private static Sprite currBlock;
	private static Sprite bigBlock;
	private static Sprite regularBlock;
	private static Sprite smallBlock;
	private SpriteRenderer blockSprite;
	private GameObject ring;
	private bool isPressed = false;

	void OnMouseDown ()
	{
		isPressed = true;
		Destroy (ring);
		ring = Instantiate (Resources.Load ("ring"), new Vector2 (transform.position.x, transform.position.y), Quaternion.identity) as GameObject;		
		ring.transform.rotation = transform.rotation;
	}

	// Use this for initialization
	void Start ()
	{
		blockSprite = gameObject.GetComponent<SpriteRenderer>();
		bigBlock = Resources.Load<Sprite>("Textures/bigblock");
		regularBlock = Resources.Load<Sprite>("Textures/block");
		smallBlock = Resources.Load<Sprite>("Textures/smallblock");
		currBlock = regularBlock;
	}

	// Update is called once per frame
	void Update ()
	{
		if(isPressed) 
		{
			ring.transform.position = transform.position;
			transform.rotation = ring.transform.rotation;
		}
		blockSprite.sprite = currBlock;
	}

	public void HandlePlayerEnlargeBlock ()
	{
		if (currBlock == smallBlock) {			
			currBlock = regularBlock;
		} else if (currBlock == bigBlock) {			
			currBlock = bigBlock;
		} else if (currBlock == regularBlock) {			
			currBlock = bigBlock;
		}
	}

	public void HandlePlayerShrinkBlock ()
	{
		if (currBlock == smallBlock) {
			currBlock = smallBlock;
		} else if (currBlock == bigBlock) {			
			currBlock = regularBlock;
		} else if (currBlock == regularBlock) {
			currBlock = smallBlock;
		}
	}

	public void HandleCollisionWithMarble ()
	{
		Destroy (gameObject);
	}
}
