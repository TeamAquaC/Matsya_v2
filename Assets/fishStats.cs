using UnityEngine;
using System.Collections;

public class fishStats : MonoBehaviour {


	public float fishValue;

	// Use this for initialization
	void Awake () 
	{
		fishValue = Random.Range (0.5f, 2f);
	}


	// Update is called once per frame
	void Update () 
	{
	
	}
}
