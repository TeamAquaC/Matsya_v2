using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MasterGameManager : MonoBehaviour 
{

	public static MasterGameManager instance = null;
	public static Level[] Levels = new Level[10];
	public static int currentLevel;

	// Use this for initialization
	void Awake () 
	{
		//Check if instance already exists
		if (instance == null) {
			//if not, set instance to this
			instance = this;
			//If instance already exists and it's not this:
		} else if (instance != this) {
			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy (gameObject);    
		}
		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad (gameObject);

//		currentLevel = 1;


		//set up the level array (which level can we play/access which not)
		SetUpLevels	();
	}

	//initialize all levels
	private static void SetUpLevels()
	{
		//Load player stats from device;
		LoadPlayerStats ();
		for (int i = 0; i < 10; i++) 
		{
			if(i + 1 < currentLevel)
				Levels[i] = new Level(i+1, true, true);
			if(i + 1 == currentLevel)
				Levels[i] = new Level(i+1, true, false);
			if(i + 1 > currentLevel)
				Levels[i] = new Level(i+1, false, false);
		}
	}

	private void Update()
	{
		if(Input.GetKey(KeyCode.R))
			ResetPlayerStats();
	}

	//call this function to unlock the next higher level on the wheel
	public static void LevelCompleted(int _levelNumber)
	{
		currentLevel = _levelNumber + 1 ;
		SavePlayerStats ();

		//set finished level to completed
		Levels [_levelNumber - 1].completed = true;

		//set following level to unlocked as long as it is not the last level
		if(_levelNumber < 10)
			Levels [_levelNumber].unlocked = true;

		//if it is the last level set it only to completed
		else if (_levelNumber == 10)
			Levels [_levelNumber - 1].completed = true;
	}

	private static void SavePlayerStats()
	{
		// try to save the current player level to the system it is running on
		try {
			PlayerPrefs.SetInt ("currentLevel", currentLevel);
			PlayerPrefs.Save ();
		}
		// handle the error
		catch(System.Exception err) {
			Debug.Log("Got: " + err);
		}
	}

	private static void LoadPlayerStats()
	{
		try{
			currentLevel = PlayerPrefs.GetInt ("currentLevel");
			Debug.Log("In try function: " + currentLevel);
		}
		catch(System.Exception err) {
			Debug.Log("Got: " + err);
			currentLevel = 1;
			Debug.Log("In catch function: "+currentLevel);
		}
		if (currentLevel == 0)
			currentLevel = 1; 
		Debug.Log("In LoadPlayerStats function: "+currentLevel);
	}

	public static void ResetPlayerStats()
	{
		try {
			PlayerPrefs.SetInt ("currentLevel", 1);
			PlayerPrefs.Save ();
		}catch(System.Exception err) {
			Debug.Log("Got: " + err);
		}
		SetUpLevels();
	}


}
