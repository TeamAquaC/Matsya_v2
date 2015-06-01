using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(AudioListener))]

public class AudioManager : MonoBehaviour {

	public AudioClip menuMusic;
	public AudioClip inGameMusic;
	public AudioClip winLevelMusic;

	private AudioSource audioSource;

	bool turnVolumeDown = false;
	bool turnVolumeUp = false;
	float volumeGoal;
	AudioClip newClip;
	float audioFadingSpeed = 1;
	
	void Awake () 
	{
		audioSource = gameObject.GetComponent<AudioSource> ();
		audioSource.volume = 0f;

		menuMusic = Resources.Load ("Sound/Music/Cryptic") as AudioClip;
		inGameMusic = Resources.Load ("Sound/Music/DistantWaters") as AudioClip;
		winLevelMusic = Resources.Load ("Sound/Music/JustGrace_Clipped") as AudioClip;

		audioSource.Play ();

		FadeAudio (menuMusic);
	}
	
	void Update () 
	{
		//mute function for main sound
		if (Input.GetKeyDown(KeyCode.M)){
				audioSource.mute = !audioSource.mute;
		}

		if (turnVolumeDown) 
		{
			float volume = Mathf.Lerp(audioSource.volume, volumeGoal, Time.deltaTime * audioFadingSpeed);
			audioSource.volume = volume;

			if(audioSource.volume < volumeGoal + 0.1f)
			{
				turnVolumeDown = false;
				audioSource.clip = newClip;
				audioSource.Play();
				volumeGoal = 1f;
				turnVolumeUp = true;
			}
		} 
		else if(turnVolumeUp)
		{
			float volume = Mathf.Lerp(audioSource.volume, volumeGoal, Time.deltaTime * audioFadingSpeed);
			audioSource.volume = volume;

			if(audioSource.volume > volumeGoal - 0.1f)
				turnVolumeUp = false;
		}
//		Debug.Log ("Volume: " + audioSource.volume + " IsPlaying:" + audioSource.isPlaying);
	}

	void OnLevelWasLoaded(int _level) 
	{
//		Debug.Log ("Level: " + _level + "was loaded");

		switch (_level) 
		{
		case 0:
			FadeAudio(menuMusic);
			break;
		case 1:
			FadeAudio(menuMusic);
			break;
		case 2:
			FadeAudio(inGameMusic);
			break;
		case 3:
			FadeAudio(inGameMusic);
			break;
		}
	}

	void FadeAudio(AudioClip _fadeToThisAudioClip)
	{
		if (_fadeToThisAudioClip != audioSource.clip) {
			newClip = _fadeToThisAudioClip;
			turnVolumeDown = true;
			volumeGoal = 0.0f;
		} else {
//			Debug.Log("Clips are the same.");
		}
	}

}
