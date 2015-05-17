using UnityEngine;
using System.Collections;

public class LevelChanger : MonoBehaviour {

	public int currentLevel;
	int deadFishVal;
	private bool gameOver = false;

	//Keep LevelChanger around.
	void Awake () {
		DontDestroyOnLoad (transform.gameObject);
	}

	// Use this for initialization
	void Start () {
	
		currentLevel = 1;
		Camera.main.orthographicSize = 6;
		deadFishVal = 0;

	}
	
	// Update is called once per frame
	void Update () {

		if (deadFishVal > 2 && gameOver == false){
			Debug.Log ("TEST");
			StartCoroutine( StoryWheelSuccess ());
			currentLevel = 2;
			gameOver = true;



		//View 3 rings 
//		if (currentLevel >= 2) {
//			Camera.main.orthographicSize = 8;
//		}


	}

//	void currentLevelFunction(){
//
//			if (deadFishVal > 2 && gameOver == false){
//				Debug.Log ("TEST");
//				StoryWheelSuccess ();
//				currentLevel = 2;
//				gameOver = true;
//
//		
//		}
//
	}

	void level_2(){

	}

	void FishKilled(){
		deadFishVal ++;
	}

	public IEnumerator StoryWheelSuccess()
	{
		float fadeTime = GameObject.Find ("Main Camera").GetComponent<SceneFading> ().BeginFade (1);
		Debug.Log ("FadingTime: " + fadeTime);
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel ("StoryWeelScene");
		Debug.Log ("TEST");
	}
}
