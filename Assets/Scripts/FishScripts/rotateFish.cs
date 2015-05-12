using UnityEngine;
using System.Collections;

public class rotateFish : MonoBehaviour {

	private float rotationSpeed = 0;
	private float newSpeed;
	float inboundTimer;
	float fishGoalPos;
	bool fishSpawn;

	// Use this for initialization
	void Start () 
	{
		inboundTimer = 0.0f;
		fishGoalPos = 8.0f;
		rotationSpeed = Random.Range (10, 40); 
		gameObject.GetComponent<BoxCollider>().enabled = false;
		gameObject.GetComponentInChildren<SkinnedMeshRenderer> ().enabled = false;
		fishSpawn = true;

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
		//((x1-x2)*(x1-x2)+(y1-y2)*(y1-y2)) < d*d
		//Fish swims into position.
		inboundTimer += Time.deltaTime;
		float spawnOffset = gameObject.transform.parent.parent.transform.transform.localScale.x;

		if (Mathf.Pow(transform.localPosition.x, 2) + Mathf.Pow (transform.localPosition.y, 2) > Mathf.Pow(fishGoalPos, 2)) {
			transform.Translate (Vector3.down * Time.deltaTime * -1.0f);
		}

		//There's probably a better way to do this.
		//For now, add a small number to distance.
		if((Mathf.Pow(transform.localPosition.x, 2) + Mathf.Pow (transform.localPosition.y, 2)  + .005 < Mathf.Pow(fishGoalPos, 2)) && fishSpawn) {
			fishSpawn = false;
			turnOnFish ();
		}

		//Rotate the fish's around the origin.
		this.transform.RotateAround (Vector3.zero, Vector3.forward, newSpeed * Time.deltaTime);
		
	}
	
	void turnOnFish()
	{
		gameObject.GetComponent<BoxCollider>().enabled = true;
		gameObject.GetComponentInChildren<SkinnedMeshRenderer> ().enabled = true;
		
	}
}
