using UnityEngine;
using System.Collections;

public class fishInstancer : MonoBehaviour {
	GameObject clone;
	public int count = 0;
	float timer=0.0f;
	float sharkTimer = 0.0f;
	public float spawnRate;
	public GameObject fish;
	public int fishCount;
	private ManInTheBoatScript manInTheBoatScript;
	public GameObject shark;

	// Use this for initialization
	void Start () {

		spawnRate = 100.0f;
		//Find man in the boat script.
		manInTheBoatScript = GameObject.Find ("ManInTheBoatObject").GetComponent<ManInTheBoatScript> ();
		
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
		float health = manInTheBoatScript.health;

		//If health is too high and not enough sharks, add to shark timer
		if (GameObject.FindGameObjectsWithTag ("shark").Length == 0 && health > 70.0f)
		{
			sharkTimer +=Time.deltaTime;
		} else if (GameObject.FindGameObjectsWithTag ("shark").Length == 1 && health > 80.0f) {
			sharkTimer += Time.deltaTime;
		} else if (GameObject.FindGameObjectsWithTag ("shark").Length == 2 && health > 90.0f) {
			sharkTimer += Time.deltaTime;
		}

		if (timer >= spawnRate) 
		{

			if(gameObject.transform.parent.transform.localScale.x < 0.9 && 
			   fishCount < 4 && this.transform.parent.transform.localScale.x > 0.5)
			{
			//Spawn a shark instead of fish if sharkTimer limit is reached.
			if (sharkTimer > 5.0f)
				{
					sharkSpawn();
					sharkTimer = 0.0f;
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

		void sharkSpawn() 
		{
			//Get ringhomes current scale.
			float currentScale = gameObject.transform.parent.transform.localScale.x;
			
			GameObject sharkInstance = shark;
			
			//Script used to instantiate fish, inside an empty object, as a child of sharkRing.
			float spawnOffset = gameObject.transform.parent.transform.localScale.x;
			GameObject newFish = Instantiate (sharkInstance, new Vector3 (0 , -8f*spawnOffset, -1), sharkInstance.transform.rotation) as GameObject;
			Transform herro = this.gameObject.transform.parent.transform;
			newFish.transform.parent = herro.transform.FindChild("sharkRing");
		}
}