using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class unlockZenMode : MonoBehaviour {

	// Use this for initialization
	void Start () {

		if (MasterGameManager.currentLevel == 10) {

			GameObject.Find("Zen").GetComponent<Image>().enabled = true;
			gameObject.GetComponent<Button>().enabled = true;

		} else {

			GameObject.Find("Zen").GetComponent<Image>().enabled = false;
			gameObject.GetComponent<Button>().enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
