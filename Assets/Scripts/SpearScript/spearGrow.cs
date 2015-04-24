using UnityEngine;
using System.Collections;

public class spearGrow : MonoBehaviour {
	public float scaleRate;
	private float timer;
	public GameObject guiTextBox;

	// Use this for initialization
	void Start () {transform.localScale = new Vector3 (1, 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
		speedChange speedScript = guiTextBox.GetComponent<speedChange>();
		float speedModSpearGrow = speedScript.speedMod;
		transform.localScale = Vector3.Lerp (transform.localScale, new Vector3 (5.0f, 5.0f, 5.0f), speedModSpearGrow * Time.deltaTime * scaleRate);
	}
}
