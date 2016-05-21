using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LastPlacedBlocks : MonoBehaviour
{

	public GameObject lastPlacedSmall;
	public GameObject lastPlacedBig;
	public GameObject lastPlacedRegular;
	// need to initialize again when we leave the scene (when loading any scene but the current one)
	public static List<BlockData> lastBlocksList = new List<BlockData> ();

	// Use this for initialization
	void Start ()
	{
		if (lastBlocksList.Count > 0) {
			// iterate over list and show grey blocks 
			// then empty the list
			foreach (BlockData block in lastBlocksList) {
				switch (block.Size) {
				case "block":
					Instantiate (lastPlacedRegular, new Vector2 (block.X, block.Y), block.Rotation);
					break;
				case "bigblock":
					Instantiate (lastPlacedBig, new Vector2 (block.X, block.Y), block.Rotation);
					break;
				case "smallblock":
					Instantiate (lastPlacedSmall, new Vector2 (block.X, block.Y), block.Rotation);
					break;
				}
			}
			lastBlocksList = new List<BlockData> ();
		}
	}
	
	// Update is called once per frame
}
