using UnityEngine;
using System.Collections;

public class boat : MonoBehaviour {

	// Use this for initialization

	public Vector3 boatDirection;
	public float boatMoveTimer = 0.0f;
	private float degreeVariable;
	public float boatRate;
	public Vector3 spearDirection;
	public GameObject front;
	public GameObject back;
	public GameObject GameManager;
	private int intDegrees;
	public float spearThrowTimer;


	void Start () 
	{
		boatMoveTimer = 0.0f;
		degreeVariable = Random.Range (20, 100);
		intDegrees = Mathf.RoundToInt (degreeVariable);
	}
	
	// Update is called once per frame
	void Update () {
		//Define boat vector using empty game objects at front and back.
		//That's wrong don't listen to him. This part's weird but working. 

		boatDirection = Vector3.forward;
		//front.transform.RotateAround(Vector3.zero, Vector3.forward, boatRate * Time.deltaTime);
		//back.transform.RotateAround (Vector3.zero, Vector3.forward, boatRate * Time.deltaTime);
		this.transform.Rotate(boatDirection * boatRate * Time.deltaTime);
		boatMoveTimer += Time.deltaTime;

		//Set spear timers between boat and spear spawn equal.
		
		spearSpawn spearScript = GameManager.GetComponent<spearSpawn>();
		float spearThrowTimer = spearScript.timer;

		//Get game speed modifier
		speedChange speedScript = GameManager.GetComponent<speedChange>();
		float speedModBoat = speedScript.speedMod;

		//Get spear spawn rate.

		float spearSpawnRate = spearScript.newSpawnRate;

		//Pause briefly for spear throw
		if (spearThrowTimer < 0.5){
			boatRate = 0.0f;
		}else if (spearThrowTimer > spearSpawnRate - 1.0f) {
			boatRate=0.0f;
		} else{
			if (boatMoveTimer >= 2) {
				
				degreeVariable = speedModBoat * Random.Range(20,100);
				intDegrees = Mathf.RoundToInt(degreeVariable);
				boatMoveTimer = 0.0f;
			}
			
			if (degreeVariable % 2 == 0)
			{
				boatRate = - intDegrees;
			}
			
			else
			{
				boatRate = intDegrees;
			}
		}


	}
}

