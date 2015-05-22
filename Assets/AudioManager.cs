using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public AudioClip menuMusic;
	public AudioClip inGameMusic;

	private AudioSource audioSource;

	// Use this for initialization
	void Awake () 
	{
		audioSource = gameObject.GetComponent<AudioSource> ();

		menuMusic = Resources.Load ("Sound/Music/Cryptic") as AudioClip;
		inGameMusic = Resources.Load ("Sound/Music/DistantWaters") as AudioClip;

		audioSource.clip = menuMusic;
		audioSource.Play ();
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (Input.GetKeyDown(KeyCode.M))
			audioSource.Pause ();
//		if (Level < 2)
//			musicPlayer.clip = menuMusic;
//		if (Level >= 2)
//			musicPlayer.clip = inGameMusic;
	}

	void OnLevelWasLoaded(int _level) 
	{
		Debug.Log ("Level: " + _level + "was loaded");

		switch (_level) 
		{
		case 0:
			audioSource.clip = menuMusic;
			break;
		case 1:
			audioSource.clip = menuMusic;
			break;
		case 2:
			audioSource.Stop();
			Debug.Log(inGameMusic);
			audioSource.clip = inGameMusic;
			audioSource.Play();
			Debug.Log(audioSource.isPlaying);
			break;
		}
	}


}
