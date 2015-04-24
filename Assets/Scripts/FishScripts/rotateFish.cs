using UnityEngine;
using System.Collections;

public class rotateFish : MonoBehaviour {

	private float rotationSpeed = 0;
	private float newSpeed;

	// Use this for initialization
	void Start () 
	{
		rotationSpeed = Random.Range (10, 40); 

		if (rotationSpeed % 2 == 0)
		{
			newSpeed = -rotationSpeed;
		}
		
		else
		{
			newSpeed = rotationSpeed;
			this.transform.Rotate (new Vector3(180, 0 , 180));
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
		//Rotate the fish's around the origin.
		this.transform.RotateAround (Vector3.zero, Vector3.forward, newSpeed * Time.deltaTime);

		float s = gameObject.transform.localScale.x; 
		s -= s / 1500; 
		Vector3 xyS = new Vector3 (s, s);
		gameObject.transform.localScale = xyS;
	}
}
