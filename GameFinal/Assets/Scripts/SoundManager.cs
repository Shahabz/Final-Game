using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	
	private AudioSource sourceAudio;

	public AudioClip marbleHitsBlock;
	public AudioClip crystalShatter;

	public AudioClip levelMusic;
	public AudioClip menuMusic;

	private bool musicIsPlaying;

	public static bool musicOn = true;
	public static bool soundOn = true;

	public static bool inLevel;
	public static bool inMenu;

	private static SoundManager instance;

	void Awake()
	{
		if (instance != null && instance != this)
		{
			Destroy(gameObject);
			return;
		}
		else
		{
			instance = this;
		}
		DontDestroyOnLoad(gameObject);
	}

	void OnApplicationQuit()
	{
		instance = null;
	}

	// Use this for initialization
	void Start () {
		sourceAudio = GetComponent<AudioSource> ();
		musicIsPlaying = true;
	}
	
	// Update is called once per frame
	void Update () {

		if(inLevel)
		{
			sourceAudio.Stop();
			sourceAudio.clip = levelMusic;
			StartCoroutine(PlayMusic());
			inLevel = false;
		}

		if(inMenu)
		{
			sourceAudio.Stop();
			sourceAudio.clip = menuMusic;
			StartCoroutine(PlayMusic());
			inMenu = false;
		}

		if (soundOn) {
			if (MarbleCollision.playMarbleHitsBlock) {
				sourceAudio.PlayOneShot (marbleHitsBlock, 1f);
				MarbleCollision.playMarbleHitsBlock = false;
			}
		
			if (DestinationModel.playCrystalShatter) {
				sourceAudio.PlayOneShot (crystalShatter, 0.6f);
				DestinationModel.playCrystalShatter = false;
			}
		}
		if (!musicOn && musicIsPlaying) {
			//sourceAudio.Pause();
			sourceAudio.Stop();
			musicIsPlaying = false;
		}
		if (musicOn && !musicIsPlaying) {
			//sourceAudio.UnPause();
			sourceAudio.Play();
			musicIsPlaying = true;
		}
				
	}

	public IEnumerator PlayMusic()
	{
		yield return new WaitForSeconds(0.2f);
		sourceAudio.Play();
	}
}


