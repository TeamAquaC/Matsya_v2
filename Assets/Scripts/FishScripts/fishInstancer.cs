using UnityEngine;
using System.Collections;

public class fishInstancer : MonoBehaviour {
	GameObject clone;
	public int count = 0;
	float timer;
	public float spawnRate;
	public GameObject g;
	//private GameObject parentObject;

	// Use this for initialization
	void Start () {
		timer = 0.0f;
		spawnRate = 100.0f;
	}
	
	// Update is called once per frame
	void Update () {
		/*if (objectsWithTag.Length > 6)
		{
			timer = 0.0f;
		}*/
		if (gameObject.transform.parent.transform.localScale.x < 0.6) {
			spawnRate = 8;
		} else if (gameObject.transform.parent.transform.localScale.x < 0.9) {
			spawnRate = 10;
		}


		timer += Time.deltaTime;

		if (timer >= spawnRate /*&& objectsWithTag.Length < 6*/) 
		{
			spawn(count);
			count++;
			timer= 0.0f; 

		}

	}
	
	void spawn(int count) 
	{
		//Get ringhomes current scale.
		float currentScale = gameObject.transform.localScale.x;


		//Script used to instantiate fish, inside an empty object, as a child of ring's parent.
		GameObject fishInstance = g;
		float spawnOffset = gameObject.transform.parent.transform.localScale.x;
		GameObject newFish = Instantiate (fishInstance, new Vector3 (0 , -16f*spawnOffset, 0), fishInstance.transform.rotation) as GameObject;
		//Transform fishHome = new GameObject ("fishHome").transform;
		//newFish.transform.SetParent (this.gameObject);
		newFish.transform.parent = this.gameObject.transform;
		//fishHome.gameObject.AddComponent<rotateFish> ();

		//Orient and scale fish properly.

		//fishHome.transform.localScale += new Vector3 (4f, 4f, 4f);
		//newFish.transform.localScale += new Vector3 (1f, 1f, 1f);
		//Vector3 parentscale = fishHome.transform.localScale;
		//newFish.transform.localScale = parentscale * 0.05f;

		newFish.transform.Rotate (new Vector3(0, -90 , 0));
		

	}
}