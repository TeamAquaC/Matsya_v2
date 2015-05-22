using UnityEngine;
using System.Collections;

public class fishInstancer : MonoBehaviour {
	GameObject clone;
	public int count = 0;
	float timer=0.0f;
	public float spawnRate;
	public GameObject fish;
	public GameObject tuna;
	public int fishCount;
	private PlayerHealth manInTheBoatScript;
	float health;

	// Use this for initialization
	void Start () {

		spawnRate = 100.0f;

		//Find man in the boat script.
		manInTheBoatScript = GameObject.Find ("GameManager").GetComponent<PlayerHealth> ();
		
		if (GameObject.FindGameObjectsWithTag ("fish").Length < 2) {
			spawn ();
			spawn ();
			Debug.Log ("Hello?");
		} else if (GameObject.FindGameObjectsWithTag ("fish").Length < 3) {
			spawn();
		}

	}
	
	// Update is called once per frame
	void Update () {
		spawnRate = gameObject.transform.parent.transform.localScale.x * 15;

		timer += Time.deltaTime;
		fishCount = transform.childCount;

		//Check man's health.
		health = manInTheBoatScript.health;


		//Spawn a fish once timer is reached.
		if (timer >= spawnRate) 
		{

			if(gameObject.transform.parent.transform.localScale.x < 0.9 && 
			   fishCount < 4 && this.transform.parent.transform.localScale.x > 0.5)
			{
				if (health < 45.0f && GameObject.FindGameObjectsWithTag ("tuna").Length < 2) {
					tunaSpawn();
				}else if (health < 30.0f && GameObject.FindGameObjectsWithTag ("tuna").Length < 4) {
					tunaSpawn();
				}else if (health < 15.0f && GameObject.FindGameObjectsWithTag("tuna").Length < 6){
					tunaSpawn();
				}else{
					spawn();
				}
				timer= 0.0f; 
			}

		}

	}
	
	void spawn() 
	{
		//Get ringhomes current scale.
		float currentScale = gameObject.transform.parent.transform.localScale.x;
		GameObject fishInstance = fish;

		//Script used to instantiate fish, inside an empty object, as a child of ring.
		float spawnOffset = gameObject.transform.parent.transform.localScale.x;
		GameObject newFish = Instantiate (fishInstance, new Vector3 (0 , -16f*spawnOffset, -1), fishInstance.transform.rotation) as GameObject;
		newFish.transform.parent = this.gameObject.transform;
		newFish.transform.localScale *= 1.75f*currentScale;
	}

	void tunaSpawn() 
	{
		//Get ringhomes current scale.
		float currentScale = gameObject.transform.parent.transform.localScale.x;
		GameObject fishInstance = tuna;
		
		//Script used to instantiate fish, inside an empty object, as a child of ring.
		float spawnOffset = gameObject.transform.parent.transform.localScale.x;
		GameObject newFish = Instantiate (fishInstance, new Vector3 (0 , -16f*spawnOffset, -1), fishInstance.transform.rotation) as GameObject;
		newFish.transform.parent = this.gameObject.transform;
		newFish.transform.localScale *= 1.75f*currentScale;
	}

}