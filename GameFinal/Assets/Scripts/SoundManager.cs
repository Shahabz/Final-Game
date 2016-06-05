using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	
	private AudioSource sourceAudio;

	public AudioClip marbleHitsBlock;
	public AudioClip crystalShatter;
	
	
	// Use this for initialization
	void Start () {
		sourceAudio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (MarbleCollision.playMarbleHitsBlock) {
			sourceAudio.PlayOneShot(marbleHitsBlock, 1f);
			MarbleCollision.playMarbleHitsBlock = false;
		}
		
		if (DestinationModel.playCrystalShatter) {
			sourceAudio.PlayOneShot(crystalShatter, 0.6f);
			DestinationModel.playCrystalShatter = false;
		}
				
	}

}


