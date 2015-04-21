using UnityEngine;
using System.Collections;

public class fishInstancer : MonoBehaviour {
	GameObject clone;
	public int count = 0;
	float timer= 6.0f;
	public float spawnRate;
	public GameObject g ;
	private GameObject parentObject;

	// Use this for initialization
	void Start () {
		parentObject = transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		//Count the number of small fish using tags. If length condition is not surpassed,
		//spawn a new fish according to rate.

		//GameObject [] objectsWithTag = GameObject.FindGameObjectsWithTag("innerFish");



		/*if (objectsWithTag.Length > 6)
		{
			timer = 0.0f;
		}*/

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
		//Get rings current scale.
		float currentScale = gameObject.transform.localScale.x;


		//Script used to instantiate fish, inside an empty object, as a child of ring's parent.
		GameObject fishInstance = g;
		GameObject newFish = Instantiate (fishInstance, new Vector3 (0 , -1.8f-6*currentScale, 0), fishInstance.transform.rotation) as GameObject;
		Transform fishHome = new GameObject ("fishHome").transform;
		newFish.transform.SetParent (fishHome);
		fishHome.transform.parent = parentObject.transform;
		fishHome.gameObject.AddComponent<rotateFish> ();

		//Orient and scale fish properly.
		newFish.transform.localScale += new Vector3 (1.5f, 1.5f, 1.5f);
		newFish.transform.Rotate (new Vector3(0, 90 , 45));
		

	}
	
}
