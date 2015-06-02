using UnityEngine;
using System.Collections;

public class fishStats : MonoBehaviour {

	int currentLevel;
	public float fishValue;

	// Use this for initialization
	void Awake () 
	{
		currentLevel = Application.loadedLevel - 1;

		if (gameObject.tag == "angelFish") {
			if (currentLevel == 8)
			{
				fishValue = 16.0f;
			}
			else
			{
			fishValue = 11.0f;
			}
		}
		if (gameObject.tag == "tuna") {
			fishValue = 7.0f;
		}
		if (gameObject.tag == "shark") {
			fishValue = 15.0f;
		}
	}


	// Update is called once per frame
	void Update () 
	{
	
	}
}
