using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckIfUnlocked : MonoBehaviour {

	int levelCheck;

	// Use this for initialization
	void Start () {

		levelCheck = int.Parse (gameObject.name);

	}
	
	// Update is called once per frame
	void Update () {
	
		if (MasterGameManager.Levels[levelCheck - 1].unlocked){
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
		}

	}
}
