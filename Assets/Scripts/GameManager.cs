using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null; 
	public GameObject ringManager;
	public int currentLevel;
	public int AnyDeadFishVal;
	public int TunaDeadFishVal;
	public int AngelDeadFishVal;
	public int SharkDeadFishVal;
	private bool gameOver = false;
	public float endLevelTime;
	public bool levelWon;
	public bool particleSpawned;
	public GameObject endParticle;

	ManInTheBoatScript man;
	RingManagerScript ring;
	// Use this for initialization
	void Awake ()
	{
		//Check if instance already exists
		if (instance == null)
			//if not, set instance to this
			instance = this;
		//If instance already exists and it's not this:
		else if (instance != this)
			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy (gameObject);    
		
		//Sets this to not be destroyed when reloading scene
//		DontDestroyOnLoad(gameObject);


		GameObject instanc = Instantiate (ringManager, new Vector3 (0f, 0f, 0f), Quaternion.identity) as GameObject;
		instanc.transform.SetParent (transform);
		


		man = GameObject.Find ("ManInTheBoatObject").GetComponent<ManInTheBoatScript> ();
		ring = instanc.GetComponent<RingManagerScript> ();
//		Debug.Log ("We are in level: " + (Application.loadedLevel - 1));
		currentLevel = Application.loadedLevel - 1;
		if (currentLevel == 1) 
		{
			man.health = 50.0f;
			Camera.main.orthographicSize = 6;
		}
	
		if (currentLevel == 2) 
		{
			man.health = 30.0f;
			Camera.main.orthographicSize = 6;
		}
		if (currentLevel == 3)
		{
			man.health = 90.0f;
			Camera.main.orthographicSize = 8.0f;
		}
		if (currentLevel == 4) 
		{
			man.health = 65.0f;
			Camera.main.orthographicSize = 8.0f;

		}
		if (currentLevel == 5) 
		{
			man.health = 50.0f;
			Camera.main.orthographicSize = 8.0f;

		}
		if (currentLevel == 6) 
		{
			man.health = 50.0f;
			Camera.main.orthographicSize = 8.0f;

		}
		if (currentLevel == 7) 
		{
			man.health = 60.0f;
			Camera.main.orthographicSize = 8.0f;
			
		}
		if (currentLevel == 8) 
		{
			man.health = 50.0f;
			Camera.main.orthographicSize = 8.0f;
			Time.timeScale = 1.5f;
			
		}
		if (currentLevel == 9) 
		{
			man.health = 50.0f;
			Camera.main.orthographicSize = 8.0f;
			Time.timeScale = 1.5f;
			
		}
		if (currentLevel == 10) 
		{
			man.health = 50.0f;
			Camera.main.orthographicSize = 8.0f;
			Time.timeScale = 1.75f;
			
		}
	}

	void Start()
	{
		endLevelTime = 0.0f;
		levelWon = false;
		particleSpawned = false;

		AnyDeadFishVal = 0;
		TunaDeadFishVal = 0;
		AngelDeadFishVal = 0;
		SharkDeadFishVal = 0;
	}
	// Update is called once per frame
	void Update () 
	{
		if (AnyDeadFishVal >= 3 && currentLevel == 1) 
		{
			if (particleSpawned == false)
			{
				GameObject particleInstance = endParticle;
				GameObject partInst = Instantiate (particleInstance, new Vector3 (0 , 0, -10), particleInstance.transform.rotation) as GameObject;

				particleSpawned = true;
			}

			if (endLevelTime > 3.0 & levelWon == false)
			{
			StartCoroutine (StoryWheelSuccess ());

			AnyDeadFishVal=0;
			TunaDeadFishVal = 0;
			AngelDeadFishVal = 0;
			SharkDeadFishVal = 0;

			levelWon = true;
			}
			MasterGameManager.LevelCompleted(1);
			endLevelTime += Time.deltaTime;
		}
		if (currentLevel==2 && AngelDeadFishVal  == 3)
		{
			if (particleSpawned = false)
			{
				GameObject particleInstance = endParticle;
				GameObject partInst = Instantiate (particleInstance, new Vector3 (0 , -0, -10), particleInstance.transform.rotation) as GameObject;
				
				particleSpawned = true;
			}
			
			if (endLevelTime > 3.0 & levelWon == false)
			{
				StartCoroutine (StoryWheelSuccess ());
				
				AnyDeadFishVal=0;
				TunaDeadFishVal = 0;
				AngelDeadFishVal = 0;
				SharkDeadFishVal = 0;
				
				levelWon = true;
			}
			MasterGameManager.LevelCompleted(2);
			endLevelTime += Time.deltaTime;

		}
		if (currentLevel == 3 && man.health <= 50.0f) 
		{
			if (particleSpawned = false)
			{
				GameObject particleInstance = endParticle;
				GameObject partInst = Instantiate (particleInstance, new Vector3 (0 , -0, -10), particleInstance.transform.rotation) as GameObject;
				
				particleSpawned = true;
			}
			
			if (endLevelTime > 3.0 & levelWon == false)
			{
				StartCoroutine (StoryWheelSuccess ());
				
				AnyDeadFishVal=0;
				TunaDeadFishVal = 0;
				AngelDeadFishVal = 0;
				SharkDeadFishVal = 0;
				
				levelWon = true;
			}
			MasterGameManager.LevelCompleted(3);
			endLevelTime += Time.deltaTime;
	    }
		if (currentLevel == 4 && SharkDeadFishVal >= 1 && ring.destroyedRings >= 3)
		{
			if (particleSpawned = false)
			{
				GameObject particleInstance = endParticle;
				GameObject partInst = Instantiate (particleInstance, new Vector3 (0 , -0, -10), particleInstance.transform.rotation) as GameObject;
				
				particleSpawned = true;
			}
			
			if (endLevelTime > 3.0 & levelWon == false)
			{
				StartCoroutine (StoryWheelSuccess ());
				
				AnyDeadFishVal=0;
				TunaDeadFishVal = 0;
				AngelDeadFishVal = 0;
				SharkDeadFishVal = 0;
				
				levelWon = true;
			}
			MasterGameManager.LevelCompleted(4);
			endLevelTime += Time.deltaTime;
		}
		if (currentLevel == 5 && ring.destroyedRings >= 5)
		{
			if (particleSpawned = false)
			{
				GameObject particleInstance = endParticle;
				GameObject partInst = Instantiate (particleInstance, new Vector3 (0 , -0, -10), particleInstance.transform.rotation) as GameObject;
				
				particleSpawned = true;
			}
			
			if (endLevelTime > 3.0 & levelWon == false)
			{
				StartCoroutine (StoryWheelSuccess ());
				
				AnyDeadFishVal=0;
				TunaDeadFishVal = 0;
				AngelDeadFishVal = 0;
				SharkDeadFishVal = 0;
				
				levelWon = true;
			}
			MasterGameManager.LevelCompleted(5);
			endLevelTime += Time.deltaTime;
		}
		if (currentLevel == 6 && SharkDeadFishVal>=3)
		{
			if (particleSpawned = false)
			{
				GameObject particleInstance = endParticle;
				GameObject partInst = Instantiate (particleInstance, new Vector3 (0 , -0, -10), particleInstance.transform.rotation) as GameObject;
				
				particleSpawned = true;
			}
			
			if (endLevelTime > 3.0 & levelWon == false)
			{
				StartCoroutine (StoryWheelSuccess ());
				
				AnyDeadFishVal=0;
				TunaDeadFishVal = 0;
				AngelDeadFishVal = 0;
				SharkDeadFishVal = 0;
				
				levelWon = true;
			}
			MasterGameManager.LevelCompleted(6);
			endLevelTime += Time.deltaTime;
		}
		if (currentLevel == 7 && TunaDeadFishVal>=3)
		{
			if (particleSpawned = false)
			{
				GameObject particleInstance = endParticle;
				GameObject partInst = Instantiate (particleInstance, new Vector3 (0 , -0, -10), particleInstance.transform.rotation) as GameObject;
				
				particleSpawned = true;
			}
			
			if (endLevelTime > 3.0 & levelWon == false)
			{
				StartCoroutine (StoryWheelSuccess ());
				
				AnyDeadFishVal=0;
				TunaDeadFishVal = 0;
				AngelDeadFishVal = 0;
				SharkDeadFishVal = 0;
				
				levelWon = true;
			}
			MasterGameManager.LevelCompleted(7);
			endLevelTime += Time.deltaTime;
		}
		if (currentLevel == 8 && TunaDeadFishVal>=3)
		{
			if (particleSpawned = false)
			{
				GameObject particleInstance = endParticle;
				GameObject partInst = Instantiate (particleInstance, new Vector3 (0 , -0, -10), particleInstance.transform.rotation) as GameObject;
				
				particleSpawned = true;
			}
			
			if (endLevelTime > 3.0 & levelWon == false)
			{
				StartCoroutine (StoryWheelSuccess ());
				
				AnyDeadFishVal=0;
				TunaDeadFishVal = 0;
				AngelDeadFishVal = 0;
				SharkDeadFishVal = 0;
				
				levelWon = true;
			}
			MasterGameManager.LevelCompleted(8);
			endLevelTime += Time.deltaTime;
		}
		if (currentLevel == 9 && ring.destroyedRings>=5)
		{
			if (particleSpawned = false)
			{
				GameObject particleInstance = endParticle;
				GameObject partInst = Instantiate (particleInstance, new Vector3 (0 , -0, -10), particleInstance.transform.rotation) as GameObject;
				
				particleSpawned = true;
			}
			
			if (endLevelTime > 3.0 & levelWon == false)
			{
				StartCoroutine (StoryWheelSuccess ());
				
				AnyDeadFishVal=0;
				TunaDeadFishVal = 0;
				AngelDeadFishVal = 0;
				SharkDeadFishVal = 0;
				
				levelWon = true;
			}
			MasterGameManager.LevelCompleted(9);
			endLevelTime += Time.deltaTime;
		}
		if (currentLevel == 10 && ring.destroyedRings>=10)
		{
			if (particleSpawned = false)
			{
				GameObject particleInstance = endParticle;
				GameObject partInst = Instantiate (particleInstance, new Vector3 (0 , 0, -10), particleInstance.transform.rotation) as GameObject;
				
				particleSpawned = true;
			}
			
			if (endLevelTime > 3.0 & levelWon == false)
			{
				StartCoroutine (StoryWheelSuccess ());
				
				AnyDeadFishVal=0;
				TunaDeadFishVal = 0;
				AngelDeadFishVal = 0;
				SharkDeadFishVal = 0;
				
				levelWon = true;
			}
			MasterGameManager.LevelCompleted(10);
			endLevelTime += Time.deltaTime;
		}
		//Cheat function to end level successfully.
		if(Input.GetKey(KeyCode.C)){
			MasterGameManager.LevelCompleted(currentLevel);
			StartCoroutine (StoryWheelSuccess ());
		}


}
	void AnyFishKilled(){
		AnyDeadFishVal ++;
	}
	void TunaFishKilled(){
		TunaDeadFishVal ++;
	}
	void AngelFishKilled(){
		AngelDeadFishVal ++;
	}
	void SharkFishKilled(){
		SharkDeadFishVal ++;
	}
	
	
	public IEnumerator StoryWheelSuccess()
	{
		float fadeTime = GameObject.Find ("Main Camera").GetComponent<SceneFading> ().BeginFade (1);
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel ("StoryWeelScene");
	}
}