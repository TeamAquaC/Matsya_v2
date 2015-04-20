using UnityEngine;
using System.Collections;

public class Swim : MonoBehaviour {

	public float thrustForward = 10.0f;
	private float thrustToCenter;
	private float thrustAwayFromCenter = 1.0f;
	public float radius = 10.0f;
	public bool clockwise = true;

	private Vector2 fForward;
	private Vector2 fCenter;
	Rigidbody2D rig2D;
	Vector2 center;

	// Use this for initialization
	void Start () 
	{
		rig2D = GetComponent<Rigidbody2D>();
		center = GameObject.Find("Center").transform.position;
	
	}
	

	void Update () 
	{
		//
		thrustToCenter = thrustForward * 20;

		Vector2 vToCenter = (center - rig2D.position).normalized;
		Vector2 vAwayFromCenter = (rig2D.position - center).normalized;


		float distToCenter = rig2D.position.magnitude;

		if (distToCenter > radius) {
			rig2D.AddForce ((vToCenter.normalized * thrustToCenter * (1/distToCenter)));


		} else {

			rig2D.AddForce((vAwayFromCenter.normalized * thrustAwayFromCenter * (1/distToCenter)));
		}

		//Force to move the 
		if (clockwise) {
			Vector2 vForward = new Vector2 (-vToCenter.y, vToCenter.x);
			rig2D.AddForce (vForward * thrustForward);
		} else {
			Vector2 vForward = new Vector2 (vToCenter.y, -vToCenter.x);
			rig2D.AddForce (vForward * thrustForward);
		}



	}
}
