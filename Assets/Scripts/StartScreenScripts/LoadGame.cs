using UnityEngine;
using System.Collections;

public class LoadGame : MonoBehaviour {


	public void ButtonPressed()
	{
		StartCoroutine (LoadStoryWeelScene());
	}
	
	IEnumerator LoadStoryWeelScene()
	{
		int level = GameObject.Find("StoryWheel").GetComponent<LevelSelecter>().levelSelected -1;
		if (IsLevelUnlocked ()) {
			float fadeTime = GameObject.Find ("Main Camera").GetComponent<SceneFading> ().BeginFade (1);
			yield return new WaitForSeconds (fadeTime);
			Application.LoadLevel (level + 2);
		}
	}

	//check if the selected level is unlocked or not
	public bool IsLevelUnlocked()
	{
		int level = GameObject.Find("StoryWheel").GetComponent<LevelSelecter>().levelSelected -1;
		bool returnBool = MasterGameManager.Levels[level].unlocked;
		//Debug.Log ("Am I free to enter Level " + (level+1) + " ? " + returnBool);
		return returnBool;
	}
}
