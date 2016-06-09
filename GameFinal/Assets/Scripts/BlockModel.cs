using UnityEngine;
using System.Collections;
public class BlockModel : MonoBehaviour
{
	private Sprite currBlock;
	private static Sprite bigBlock;
	private static Sprite regularBlock;
	private static Sprite smallBlock;
	private SpriteRenderer blockSprite;
	private GameObject ring;
	private bool isPressed;
	private static bool gameStarted = false;
	private int blockIndex;
	private bool updateCollider = false;
	public static bool inStash = false;

	void OnMouseDown ()
	{				
		//checkIfInStash ();
		if (!gameStarted) {
			StartCoroutine (MouseOnBlock ());
		}
	}
	// Use this for initialization
	void Start ()
	{
		gameStarted = false;
		blockSprite = gameObject.GetComponent<SpriteRenderer> ();
		bigBlock = Resources.Load<Sprite> ("Textures/bigblock");
		regularBlock = Resources.Load<Sprite> ("Textures/block");
		smallBlock = Resources.Load<Sprite> ("Textures/smallblock");
		currBlock = regularBlock;
		blockSprite.sprite = currBlock;
		if (Input.GetMouseButton (0)) {
			OnMouseDown ();		
		}
		updateCollider = false;
		gameObject.GetComponent<CircleCollider2D>().enabled = true;
		gameObject.GetComponent<PolygonCollider2D>().enabled = false;
	}
	// Update is called once per frame
	void Update ()
	{
		if (inStash && isPressed) {
			Destroy(gameObject);
			Destroy (ring);
			isPressed = false;
			GameControl.control.numOfBlocks++;
			inStash = false;
		}

		if (gameStarted && !updateCollider) {

			gameObject.GetComponent<CircleCollider2D>().enabled = false;
			//GetComponent<CircleCollider2D> ();
			gameObject.GetComponent<PolygonCollider2D> ().enabled = true;
			saveBlockInList ();
//			Destroy(gameObject.GetComponent<PolygonCollider2D> ());
//			gameObject.AddComponent<PolygonCollider2D> ();
			isPressed = false;
			Destroy (ring);
			updateCollider = true;
		}
		//only if the block is highlighted
		if (isPressed) {
			PinchUpdate ();
			if (Input.GetKeyDown (KeyCode.UpArrow))
				HandlePlayerEnlargeBlock ();
			if (Input.GetKeyDown (KeyCode.DownArrow))
				HandlePlayerShrinkBlock ();

			//if click on background- remove highlight
			if (Input.GetMouseButtonDown (0) && !RingScript.pressOnRing) {
				StartCoroutine (RemoveRing ());
			}
			//ring follow block  and block rotate with ring
			ring.transform.position = transform.position;
			transform.rotation = ring.transform.rotation;
		}
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

		blockSprite.sprite = currBlock;
		Destroy (GetComponent<PolygonCollider2D> ());
		gameObject.AddComponent<PolygonCollider2D> ();
		gameObject.GetComponent<PolygonCollider2D>().enabled = false;
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
		blockSprite.sprite = currBlock;
		Destroy (GetComponent<PolygonCollider2D> ());
		gameObject.AddComponent<PolygonCollider2D> ();
		gameObject.GetComponent<PolygonCollider2D>().enabled = false;
	}
	public IEnumerator RemoveRing ()
	{
		yield return new WaitForSeconds (0.1f);
		if (!twoFingers) {
			isPressed = false;
			Destroy (ring);
		}
	}
	//create new highlight with click on block
	public IEnumerator MouseOnBlock ()
	{
		yield return new WaitForSeconds (0.11f);
		isPressed = true;
		Destroy (ring);
		ring = Instantiate (Resources.Load ("ring"), new Vector2 (transform.position.x, transform.position.y), Quaternion.identity) as GameObject;		
		ring.transform.rotation = transform.rotation;
	}
	public void HandleGameStarted ()
	{
		gameStarted = true;
	}

	public void saveBlockInList () {
		BlockData myBlock = new BlockData (transform.position.x,
			transform.position.y, currBlock.name, transform.rotation);
		LastPlacedBlocks.lastBlocksList.Add (myBlock);
	}
		

	//pinch Code
	private bool isTouch = false;
	private float firstDistance = 0f;
	private float currentDistance = 0f;
	private float distance = 0f;
	public static bool twoFingers = false;
	void PinchUpdate ()
	{
		if (Input.touchCount == 2) {
			twoFingers = true;
			Touch firstFinger = Input.GetTouch (0);
			Touch secondFinger = Input.GetTouch (1);
			if (!isTouch) {				
				firstDistance = (firstFinger.position - secondFinger.position).magnitude;
				isTouch = true;
			} else {								
				currentDistance = (firstFinger.position - secondFinger.position).magnitude;				
				distance = firstDistance - currentDistance;
				if (distance > 60f) {
					HandlePlayerShrinkBlock ();
					isTouch = false;
				} else if (distance < -60f) {
					HandlePlayerEnlargeBlock ();
					isTouch = false;
				}
			}                  
		} else
			twoFingers = false;
	}

	void OnMouseUp ()
	{
		//Debug.Log("sfsdfasd");
		checkIfInStash ();
	}

	public void checkIfInStash ()
	{
		//Debug.Log("xxxx");
		float positionX = gameObject.transform.position.x;
		float positionY = gameObject.transform.position.y;
		if (7.15f < positionX && positionX < 8.62f && -4.75f < positionY && positionY < -3.24f) {
	//		LevelManager.blocksSizes [blockIndex] = null;
			Destroy (gameObject);
			Destroy (ring);
			isPressed = false;
			GameControl.control.numOfBlocks++;
			//LevelManager.numOfLeftBlocks++;
			//LevelManager.numOfUsedBlocks--;
		}			
	}

}