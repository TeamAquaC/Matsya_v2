using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MasterGameManager : MonoBehaviour 
{

	public static MasterGameManager instance = null;
	public static Level[] Levels = new Level[10];

	// Use this for initialization
	void Awake () 
	{
		//Check if instance already exists
		if (instance == null){
			//if not, set instance to this
			instance = this;
		//If instance already exists and it's not this:
		}else if (instance != this) {
			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy (gameObject);    
		}
		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);

		SetUpLevels();
	}

	//initialize all levels
	private void SetUpLevels()
	{
		for (int i = 0; i < 10; i++) 
		{
			if(i == 0)
				Levels[i] = new Level(i+1, true, false);
			else
				Levels[i] = new Level(i+1, false, false);
		}
	}

	//call this function to unlock the next higher level on the wheel
	public static void LevelCompleted(int _levelNumber)
	{
		//set finished level to completed
		Levels [_levelNumber - 1].completed = true;

		//set following level to unlocked as long as it is not the last level
		if(_levelNumber < 10)
			Levels [_levelNumber].unlocked = true;

		//if it is the last level set it only to completed
		else if (_levelNumber == 10)
			Levels [_levelNumber - 1].completed = true;
	}
}
