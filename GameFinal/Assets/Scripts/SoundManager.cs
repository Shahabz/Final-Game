using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	
	private AudioSource sourceAudio;

	public AudioClip marbleHitsBlock;
	public AudioClip crystalShatter;
	private bool musicIsPlaying;
	
	
	// Use this for initialization
	void Start () {
		sourceAudio = GetComponent<AudioSource> ();
		musicIsPlaying = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (PauseMenuManager.soundOn) {
			if (MarbleCollision.playMarbleHitsBlock) {
				sourceAudio.PlayOneShot (marbleHitsBlock, 1f);
				MarbleCollision.playMarbleHitsBlock = false;
			}
		
			if (DestinationModel.playCrystalShatter) {
				sourceAudio.PlayOneShot (crystalShatter, 0.6f);
				DestinationModel.playCrystalShatter = false;
			}
		}
		if (!PauseMenuManager.musicOn && musicIsPlaying) {
			//sourceAudio.Pause();
			sourceAudio.Stop();
			musicIsPlaying = false;
		}
		if (PauseMenuManager.musicOn && !musicIsPlaying) {
			//sourceAudio.UnPause();
			sourceAudio.Play();
			musicIsPlaying = true;
		}
				
	}

}


