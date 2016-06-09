using UnityEngine;
using System.Collections;

public class StarScript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
		StartCoroutine (ChangeStarScale ());
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	
	}

	public IEnumerator ChangeStarScale ()
	{
		while (true) {
			int i = 0;
			float width = this.GetComponent<RectTransform>().localScale.x;
			do {
				yield return new WaitForSeconds (0.04f);
				this.GetComponent<RectTransform>().localScale += new Vector3(0.02f, 0.02f, 0f);
				i++;
			} while(i < 10);

			do {
				yield return new WaitForSeconds (0.04f);
				this.GetComponent<RectTransform>().localScale -= new Vector3(0.02f, 0.02f, 0f);
				i--;
			} while(i > 0);
			yield return new WaitForSeconds (0.1f);
		}
	}
}
