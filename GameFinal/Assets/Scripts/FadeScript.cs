
using UnityEngine;
using System.Collections;

public class FadeScript : MonoBehaviour
{
	public float fadeSpeed = 0.5f;
	private bool isDone = false;
	private Color matCol;
	private Color newColor;
	private float alfa = 0;
	public static bool unlocked = false;

	// Use this for initialization
	void Start()
	{
		unlocked = false;
		matCol = gameObject.GetComponent<SpriteRenderer>().material.color;
	}

	// Update is called once per frame
	void Update()
	{
		if (unlocked) {
			if (!isDone)
			{
				alfa = gameObject.GetComponent<SpriteRenderer>().material.color.a - Time.deltaTime/(fadeSpeed==0?1:fadeSpeed);
				newColor = new Color(matCol.r, matCol.g, matCol.b, alfa);
				gameObject.GetComponent<SpriteRenderer>().material.SetColor("_Color", newColor);
				isDone = alfa <= 0 ? true : false;
			}
		}
	}
}
