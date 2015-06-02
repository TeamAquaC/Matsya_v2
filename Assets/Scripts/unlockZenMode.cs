using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class unlockZenMode : MonoBehaviour {

MasterGameManager MGM;
	// Use this for initialization
	void Start () 
	{
		GameObject.Find("Zen").GetComponent<Image>().enabled = false;
		GameObject.Find("Zen").GetComponent<Image>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Debug.Log("currentLevel: "+MasterGameManager.currentLevel);
		if (MasterGameManager.currentLevel >= 10) 
		{
			GameObject.Find("Zen").GetComponent<Image>().enabled = true;
			gameObject.GetComponent<Button>().enabled = true;
		} 
		else 
		{
			GameObject.Find("Zen").GetComponent<Image>().enabled = false;
			gameObject.GetComponent<Button>().enabled = false;
		}
	}
}
