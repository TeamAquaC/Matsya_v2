using UnityEngine;
using System.Collections;

public class rotateTuna : MonoBehaviour {

	private float rotationSpeed = 0;
	private float newSpeed;
	float inboundTimer;
	float fishGoalPos;

	// Use this for initialization
	void Start () 
	{
		inboundTimer = 0.0f;
		fishGoalPos = 7.5f;
		rotationSpeed = Random.Range (10, 40); 

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

		//Rotate the fish's around the origin.
		this.transform.RotateAround (Vector3.zero, Vector3.forward, newSpeed * Time.deltaTime);


		/*float s = gameObject.transform.localScale.x; 
		s -= s / 1500; 
		Vector3 xyS = new Vector3 (s, s);
		gameObject.transform.localScale = xyS;*/
	}
}
