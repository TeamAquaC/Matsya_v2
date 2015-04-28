using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class speedChange : MonoBehaviour {

Text instruction;
	public float speedMod;
	private float timer;
	private float speedModAdd;

	// Starting playback speed, with GUI text.
	void Start () {
		instruction = GetComponent<Text>();
		instruction.text = "Normal";
		speedMod = 0.6f;
	}
	
	// Game speeds up over time.
	void Update () {
		//speedMod = speedModAdd + timer * .01f;
	}
}
