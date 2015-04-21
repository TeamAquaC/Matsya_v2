using UnityEngine;
using System.Collections;

public class fishExplode : MonoBehaviour {


	//Instantiates a particle effect for when a fish is destroyed.

	GameObject boom;
	public GameObject fishDying;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider coll) {
		boom = (GameObject) Instantiate(fishDying, transform.position, Quaternion.identity);
	
	}
}
