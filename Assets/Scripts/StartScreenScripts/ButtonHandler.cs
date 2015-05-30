using UnityEngine;
using System.Collections;

public class ButtonHandler : MonoBehaviour 
{

	public void ButtonPressed()
	{
		StartCoroutine (LoadStoryWeelScene());
	}
	
	IEnumerator LoadStoryWeelScene()
	{
		float fadeTime = GameObject.Find ("Main Camera").GetComponent<SceneFading> ().BeginFade (1);
		Debug.Log ("FadingTime: " + fadeTime);
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel ("StoryWeelScene");
	}

	public void Button_RestePlayerStats()
	{
		MasterGameManager.ResetPlayerStats ();
	}
}
