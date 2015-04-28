using UnityEngine;
using System.Collections;

public class CollisionObject : MonoBehaviour {

	//Used on spear head to destroy any object with a collider that it hits.

	void OnTriggerEnter(Collider coll)
	{

			Destroy(coll.gameObject);
			Destroy (transform.parent.gameObject);
			Debug.Log("Collision");
			

	}
}
