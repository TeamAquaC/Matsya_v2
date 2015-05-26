using UnityEngine;
using System.Collections;

//This script requires a audioSource component if it is not already there it is added automatically.
[RequireComponent (typeof (AudioSource))]

public class SoundOnRotation : MonoBehaviour 
{

	private AudioClip clip01;
	private AudioSource source;
	private bool isRotating = false;
	private Rigidbody2D rig;

	private float volumeGoal;
	private float pitchGoal;


	// Use this for initialization
	void Awake () 
	{
		source = gameObject.GetComponent<AudioSource> ();
		clip01 = Resources.Load ("Sound/SoundEffects/Rowing A Boat-SoundBible.com-2108783030") as AudioClip;
		if (clip01 == null)
			Debug.LogWarning ("Missing Audio Clip!");
		source.clip = clip01;
		source.Play ();
		source.loop = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		isRotating = gameObject.GetComponentInChildren<RingRotation> ()._isRotating;
		if (isRotating) {
			volumeGoal = .8f;
			pitchGoal = .9f;

		} else {
			volumeGoal = 0.1f;
			pitchGoal = .2f;
		}

		float volume = Mathf.Lerp (source.volume, volumeGoal, Time.deltaTime);
		source.volume = volume;

		float pitch = Mathf.Lerp (source.pitch, pitchGoal, Time.deltaTime);
		source.pitch = pitch;
	
	}


}
