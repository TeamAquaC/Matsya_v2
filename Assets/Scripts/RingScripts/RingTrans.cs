using UnityEngine;
using System.Collections;

public class RingTrans : MonoBehaviour {

	public GameObject ringManager;

	private Color lerpedColor;
	private Renderer rend;
	 
	private float fadeInThreshold;
	private float fadeOutThreshold;


	void Start () 
	{
		rend = GetComponent<Renderer> ();											//Set sprite to be transperent when instantiated
		rend.material.color = new Color (1f, 1f, 1f, 0f);

		RingManagerScript script = ringManager.GetComponent<RingManagerScript> ();				//Get variables from RingManager Script
		fadeInThreshold = script.FadeInThreshold;
		fadeOutThreshold = script.FadeOutThreshold;
	}
	

	void Update () 
	{
		if (rend.material.color.a < 0.99f) { 															//Fade in after instantiated
			lerpedColor = Color.Lerp(rend.material.color, new Color (1f,1f,1f,1f), Time.deltaTime*4);
			rend.material.color = lerpedColor;
		}
	
//		if (transform.localScale.x < fadeOutThreshold) {												//Fade Out when smaller than fade out threshold
//			lerpedColor = Color.Lerp (rend.material.color, new Color (1f, 1f, 1f, 0f), Time.deltaTime);
//			rend.material.color = lerpedColor;
//		}
	}
}
