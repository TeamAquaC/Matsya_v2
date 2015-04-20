using UnityEngine;
using System.Collections;

public class rotateFish : MonoBehaviour {

	private float rotationSpeed = 0;


	// Use this for initialization
	void Start () 
	{
		rotationSpeed = Random.Range (10, 40); 
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.transform.RotateAround (Vector3.zero, Vector3.forward, rotationSpeed * Time.deltaTime);


	}
}
