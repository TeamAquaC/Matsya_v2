using UnityEngine;
using System.Collections;

public class EventSystemScript : MonoBehaviour {

	public int gameLevelToLoad;
	private bool gamePaused = false;

	public void LoadGameLevel()
	{
		StartCoroutine (LoadLevel());
	}

	IEnumerator LoadLevel()
	{
		//unpause the game so the fade can take place
		if (gamePaused)
			gamePaused = false;

		//Start fading out sequence bevor loading new level and wait until it is finished
		float fadeTime = GameObject.Find ("Main Camera").GetComponent<SceneFading> ().BeginFade (1);
		Debug.Log ("FadingTime: " + fadeTime);
		yield return new WaitForSeconds(fadeTime);

		//Load StoryWeel level
		Application.LoadLevel (1);
	}

	public void PauseGame()
	{
		gamePaused = !gamePaused;
		Debug.Log ("Pause" + gamePaused);

		if (gamePaused) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}
}
