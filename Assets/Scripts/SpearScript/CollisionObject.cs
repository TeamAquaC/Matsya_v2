using UnityEngine;
using System.Collections;

public class CollisionObject : MonoBehaviour {

	//Used on spear head to destroy any object with a collider that it hits.

	void OnTriggerEnter(Collider coll)
	{
		//get value of fish
		float fishValue = coll.gameObject.GetComponent<fishStats>().fishValue;
		Debug.Log ("fishValue"+fishValue);

		//send fish value to man in the boat
		GameObject.Find ("ManInTheBoatObject").gameObject.SendMessage("FishKilled",fishValue);
		
		//send fish killed to level changer
		GameObject.Find ("GameManager").gameObject.SendMessage("AnyFishKilled");
	
		if(fishValue == 7.0)
			GameObject.Find ("GameManager").gameObject.SendMessage("TunaFishKilled");

		if(fishValue == 11.0)
			GameObject.Find ("GameManager").gameObject.SendMessage("AngelFishKilled");

		if(fishValue == 15.0)
			GameObject.Find ("GameManager").gameObject.SendMessage("SharkFishKilled");

		//kill fish
		Destroy(coll.gameObject);
		Destroy (transform.parent.gameObject);
		Debug.Log("Collision");

	

			

	}
}
