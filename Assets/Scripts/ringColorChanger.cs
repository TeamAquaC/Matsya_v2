using UnityEngine;
using System.Collections;

// this script changes the sprite render color based on the scale of the parent object.
public class ringColorChanger : MonoBehaviour {
	SpriteRenderer sprRender;
	float scaleX;
	// Use this for initialization
	void Start () {
		//find and set the sprite renderer
		sprRender = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		//find the scale value of the parent
		// since the parent began with a scale of 2 the number is divided to get a value from 0-1
		scaleX = gameObject.transform.parent.localScale.x/2;
		/* set the color value to the invers of the scale
		 * (1,1,1) would we white so red and green are set to get closer to that as the scale decreses
		 * */
		sprRender.color = new Color((1 - scaleX), (1 - scaleX), 1);
		
	}
}
