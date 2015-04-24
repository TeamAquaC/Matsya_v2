using UnityEngine;
using System.Collections;

public class boat : MonoBehaviour {

	// Use this for initialization

	public Vector3 boatDirection;
	public float timer = 0.0f;
	private float degreeVariable;
	public float boatRate;
	public Vector3 spearDirection;
	public GameObject guiTextBox;
	public GameObject front;
	public GameObject back;


	void Start () 
	{
		degreeVariable = Random.Range (20, 100);
	}
	
	// Update is called once per frame
	void Update () {
		//Define boat vector using empty game objects at front and back.

		boatDirection = Vector3.forward;
		front.transform.RotateAround(Vector3.zero, Vector3.forward, boatRate * Time.deltaTime);
		back.transform.RotateAround (Vector3.zero, Vector3.forward, boatRate * Time.deltaTime);
		this.transform.Rotate(boatDirection * boatRate * Time.deltaTime);
		timer += Time.deltaTime;

		//Get selected game speed.

		speedChange speedScript = guiTextBox.GetComponent<speedChange>();
		float speedModBoat = speedScript.speedMod;

		//Randomize boat rotational speed. Even ints rotate counterclockwise, odds rotate clockwise.

		if (timer >= 2) {

			degreeVariable = speedModBoat * Random.Range(20,100);
		
			timer = 0.0f;
			}
		if (degreeVariable % 2 == 0)
		{
			boatRate = - degreeVariable;
		}
		else
		{
			boatRate = degreeVariable;
		}
	}
}

