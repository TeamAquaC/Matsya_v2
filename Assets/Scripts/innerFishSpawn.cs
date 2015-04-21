using UnityEngine;
using System.Collections;

public class innerFishSpawn : MonoBehaviour {
	GameObject clone;
	public int count = 0;
	float timer= 6.0f;
	public float spawnRate;
	public GameObject g ;
	public GameObject guiTextBox;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//Count the number of small fish using tags. If length condition is not surpassed,
		//spawn a new fish according to rate.

		GameObject [] objectsWithTag = GameObject.FindGameObjectsWithTag("innerFish");



		if (objectsWithTag.Length > 6)
		{
			timer = 0.0f;
		}

		timer += Time.deltaTime;

		if (timer >= spawnRate && objectsWithTag.Length < 6) 
		{
			spawn(count);
			count++;
			timer= 0.0f; 

		}

	}
	
	void spawn(int count) 
	{
		//Script used to instantiate fish as child of ring.

		clone = (GameObject)Instantiate (g, new Vector3 (0 , -1.7f, 0), g.transform.rotation);
		clone.transform.parent = GameObject.Find ("smallRingHome").transform;
		clone.transform.localScale -= new Vector3 (0.1f, 0.1f, 0.1f);
	}
	
}
