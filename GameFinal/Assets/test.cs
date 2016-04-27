using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {
	private Sprite bigBlock;
	private Sprite regularBlock;
	private Sprite smallBlock;
	private SpriteRenderer blockSprite;
	private Sprite currBlock;


	// Use this for initialization
	void Start () {
		blockSprite = GetComponent<SpriteRenderer> ();

		bigBlock = Resources.Load<UnityEngine.Sprite>("Textures/bigblock");
		regularBlock = Resources.Load<UnityEngine.Sprite>("Textures/block");
		smallBlock = Resources.Load<UnityEngine.Sprite>("Textures/smallblock");

		currBlock = regularBlock;

		blockSprite.sprite = currBlock;

		// the starting location of the block
		transform.position = new Vector3 (0f, 0f, 0f);

		// the rotation of the block - change the z value to change the rotation
		transform.rotation = Quaternion.Euler (transform.rotation.x, transform.rotation.y, 50f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
}
