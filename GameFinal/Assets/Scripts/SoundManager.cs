using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	
	private AudioSource sourceAudio;
	public AudioClip marbleHitsBlock;
	public AudioClip crystalShatter;
	public AudioClip levelMusic;
	public AudioClip menuMusic;
	public AudioClip buttonSound;

	public AudioClip firstStarSound;
	public AudioClip secondStarSound;
	public AudioClip thirdStarSound;
	public AudioClip lastStarSound;

	public AudioClip openLockSound;

	private bool musicIsPlaying;

	public static bool musicOn = true;
	public static bool soundOn = true;
	public static bool playButtonClick = false;

	public static bool oneStar;
	public static bool twoStars;
	public static bool threeStars;

	public static bool openLock;

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

			if (playButtonClick) {
				sourceAudio.PlayOneShot (buttonSound, 1f);
				playButtonClick = false;
			}

			if (oneStar) {
				sourceAudio.PlayOneShot (firstStarSound, 1f);
				oneStar = false;
			}

			if (twoStars) {
				sourceAudio.PlayOneShot (secondStarSound, 1f);
				twoStars = false;
			}

			if (threeStars) {
				sourceAudio.PlayOneShot (thirdStarSound, 1f);
				threeStars = false;
				StartCoroutine(fullStars());
			}

			if (openLock) {
				sourceAudio.PlayOneShot (openLockSound, 1f);
				openLock = false;
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

	public IEnumerator fullStars()
	{
		yield return new WaitForSeconds(0.3f);
		sourceAudio.PlayOneShot (lastStarSound, 1f);
	}
}


