using UnityEngine;
using System.Collections;

public class BlockData : MonoBehaviour {

	private float x;
	private float y;
	private string size;
	private Quaternion rotation;

	public BlockData(float x, float y, string size, Quaternion rotation) {
		this.x = x;
		this.y = y;
		this.size = size;
		this.rotation = rotation;
	}

	public float X {
		get { return x; }
		set { x = value; }
	}

	public float Y {
		get { return y; }
		set { y = value; }
	}

	public string Size {
		get { return size; }
		set { size = value; }
	}

	public Quaternion Rotation {
		get { return rotation; }
		set { rotation = value; }
	}
}
