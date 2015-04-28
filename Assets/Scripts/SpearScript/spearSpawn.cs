using UnityEngine;
using System.Collections;

public class spearSpawn : MonoBehaviour {
 	GameObject [] spearClone = new GameObject[5];
	int count = 0;
	public float timer= 0.0f;
	public float spawnRate;
	public float newSpawnRate;
	public GameObject g ;
	//public GameObject h;
	public GameObject boatFront;
	public GameObject boatBack;
	public Vector3 randomDirection;
	Quaternion t;
	public float spearSpeed;
	GameObject [] indicClone = new GameObject[5];
	//public GameObject guiTextBox;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		speedChange speedScript = gameObject.GetComponent<speedChange>();
		float speedModSpearSpawn = speedScript.speedMod;

		newSpawnRate = spawnRate;

		//Get boat vector direction at time of instantiation.

		randomDirection = boatFront.transform.position - boatBack.transform.position;
		timer += Time.deltaTime;

		/*if (timer >= (newSpawnRate - .4f) && count < 5) 
		{
			indicator (count);
		}*/

		if (timer >= newSpawnRate && count < 5) 
		{
			spawn(count);
			count++;
			timer= 0.0f; 
			count = count % 5;
		}
	}

	/*void indicator (int count)
	{
		indicClone [count] = (GameObject)Instantiate (h, new Vector3 (0, 0, 0), Quaternion.identity);
	}*/

	void spawn(int count) 
	{
		//Spear instantiated velocity relative to selected game speed.

		speedChange speedScript = gameObject.GetComponent<speedChange>();
		float speedModSpear = speedScript.speedMod;

		//Instantiate spear at origin according to boat's direction.

		if (spearClone [count] != null) {
			Object.Destroy( spearClone[count]);

		}
		t = Quaternion.LookRotation(randomDirection);
		spearClone[count] = (GameObject)Instantiate (g, new Vector3 (0, 0, 0), t);
		/*spearClone[count].transform.Rotate(0, 90, 90);
		spearClone[count].transform.localScale = new Vector3 (.1F, .1F, .1F);*/
		spearClone[count].GetComponent<Rigidbody>().velocity = speedModSpear * randomDirection * spearSpeed;


	}

}


