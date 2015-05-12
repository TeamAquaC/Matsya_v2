using UnityEngine;
using System.Collections;

public class fishStats : MonoBehaviour {


	public float fishValue;

	// Use this for initialization
	void Awake () 
	{
		if (gameObject.tag == "angelFish") {
			fishValue = 11.0f;
		}
		if (gameObject.tag == "tuna") {
			fishValue = 7.0f;
		}
		if (gameObject.tag == "angelFish") {
			fishValue = 15.0f;
		}
	}


	// Update is called once per frame
	void Update () 
	{
	
	}
}
