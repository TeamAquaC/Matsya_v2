using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class speedChange : MonoBehaviour {

Text instruction;
public float speedMod;

	// Starting playback speed, with GUI text.
	void Start () {
		instruction = GetComponent<Text>();
		instruction.text = "Normal";
		speedMod = .6f;
	}
	
	// Playback speeds 1,2,3,4,5 for testing of appropriate game pace.
	void Update () {

	if(Input.GetKeyDown ("1")){
		instruction.text = "Fastest";
		speedMod = 1.0f;
	}

	if(Input.GetKeyDown ("2")){
		instruction.text = "Faster";
		speedMod = .75f;
	}

	if(Input.GetKeyDown ("3")){
		instruction.text = "Normal";
		speedMod = .55f;
	}

	if(Input.GetKeyDown ("4")){
		instruction.text = "Slower";
		speedMod = .3f;
	}

	if(Input.GetKeyDown ("5")){
		instruction.text = "Slowest";
		speedMod = .1f;
	}
	}
}
