using UnityEngine;
using System.Collections;

public class ringColorChanger : MonoBehaviour {
	SpriteRenderer sprRender;
	Color color;
	float scaleX;
	// Use this for initialization
	void Start () {
		sprRender = gameObject.GetComponent<SpriteRenderer>();
		color = sprRender.color;
	}
	
	// Update is called once per frame
	void Update () {
		scaleX = gameObject.transform.parent.localScale.x/2;
		Debug.Log("scaleValue = " + scaleX);
		sprRender.color = new Color((255 / scaleX), (255 / scaleX), 255);
		
	}
}
