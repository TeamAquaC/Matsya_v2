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
	public bool particleSpawned;
	public GameObject endParticle;
	public AudioClip winMusic;
	private AudioSource audioSource;
	bool level3switch;

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
		
		level3switch = false;

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
			Camera.main.orthographicSize = 7;
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
			man.health = 60.0f;
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
		audioSource = gameObject.GetComponent<AudioSource> ();

		AnyDeadFishVal = 0;
		TunaDeadFishVal = 0;
		AngelDeadFishVal = 0;
		SharkDeadFishVal = 0;

		endLevelTime = 0.0f;
		particleSpawned = false;
	}
	// Update is called once per frame
	void Update () 
	{
		//Level 1 WIn Con
		if (AnyDeadFishVal >= 3 && currentLevel == 1) 
		{
			if (particleSpawned == false)
			{
				GameObject particleInstance1 = endParticle;
				GameObject partInst1 = Instantiate (particleInstance1, new Vector3 (0 , 0, -10), particleInstance1.transform.rotation) as GameObject;

				audioSource.PlayOneShot(winMusic);

				particleSpawned = true;
			}

			if (endLevelTime > 3.0)
			{	
			StartCoroutine (StoryWheelSuccess ());

			AnyDeadFishVal=0;
			TunaDeadFishVal = 0;
			AngelDeadFishVal = 0;
			SharkDeadFishVal = 0;

			endLevelTime = 0.0f;
			particleSpawned = false;

			}

			MasterGameManager.LevelCompleted(1);
			endLevelTime += Time.deltaTime;
		}

		//Level 2 Win Con
		if (currentLevel==2 && AngelDeadFishVal  >= 3)
		{
			if (particleSpawned == false)
			{
				GameObject particleInstance2 = endParticle;
				GameObject partInst2 = Instantiate (particleInstance2, new Vector3 (0 , -0, -10), particleInstance2.transform.rotation) as GameObject;

				audioSource.PlayOneShot(winMusic);
				
				particleSpawned = true;
			}
			
			if (endLevelTime > 3.0)
			{
				
				StartCoroutine (StoryWheelSuccess ());

				AnyDeadFishVal=0;
				TunaDeadFishVal = 0;
				AngelDeadFishVal = 0;
				SharkDeadFishVal = 0;

				endLevelTime = 0.0f;
				particleSpawned = false;
			}
			MasterGameManager.LevelCompleted(2);
			endLevelTime += Time.deltaTime;

		}

		//Level 3 Win Con
		if (currentLevel == 3 && man.health <= 50.0f) {
			if (level3switch == false)
			{
				level3switch = true;
			}
		}

		if (level3switch == true)
		{
			if (particleSpawned == false)
			{
				GameObject particleInstance3 = endParticle;
				GameObject partInst3 = Instantiate (particleInstance3, new Vector3 (0 , -0, -10), particleInstance3.transform.rotation) as GameObject;

				audioSource.PlayOneShot(winMusic);

				particleSpawned = true;
			}
			
			if (endLevelTime > 3.0)
			{		
				StartCoroutine (StoryWheelSuccess ());

				AnyDeadFishVal=0;
				TunaDeadFishVal = 0;
				AngelDeadFishVal = 0;
				SharkDeadFishVal = 0;

				level3switch = false;
				endLevelTime = 0.0f;
				particleSpawned = false;
			}
			MasterGameManager.LevelCompleted(3);
			endLevelTime += Time.deltaTime;
	    }

		//Level 4 Win Con
		if (currentLevel == 4 && SharkDeadFishVal >= 1 && ring.destroyedRings >= 2)
		{
			if (particleSpawned == false)
			{
				GameObject particleInstance4 = endParticle;
				GameObject partInst4 = Instantiate (particleInstance4, new Vector3 (0 , -0, -10), particleInstance4.transform.rotation) as GameObject;

				audioSource.PlayOneShot(winMusic);

				particleSpawned = true;
			}
			
			if (endLevelTime > 3.0)
			{		
				
				StartCoroutine (StoryWheelSuccess ());

				AnyDeadFishVal=0;
				TunaDeadFishVal = 0;
				AngelDeadFishVal = 0;
				SharkDeadFishVal = 0;

				endLevelTime = 0.0f;
				particleSpawned = false;
			}
			MasterGameManager.LevelCompleted(4);
			endLevelTime += Time.deltaTime;
		}

		//Level 5 Win Con
		if (currentLevel == 5 && ring.destroyedRings >= 4)
		{
			if (particleSpawned == false)
			{
				GameObject particleInstance5 = endParticle;
				GameObject partInst5 = Instantiate (particleInstance5, new Vector3 (0 , -0, -10), particleInstance5.transform.rotation) as GameObject;

				audioSource.PlayOneShot(winMusic);

				particleSpawned = true;
			}
			
			if (endLevelTime > 3.0)
			{
				
				StartCoroutine (StoryWheelSuccess ());

				AnyDeadFishVal=0;
				TunaDeadFishVal = 0;
				AngelDeadFishVal = 0;
				SharkDeadFishVal = 0;

				endLevelTime = 0.0f;
				particleSpawned = false;
			}
			MasterGameManager.LevelCompleted(5);
			endLevelTime += Time.deltaTime;
		}

		//Level 6 Win Con
		if (currentLevel == 6 && SharkDeadFishVal>=3)
		{
			if (particleSpawned == false)
			{
				GameObject particleInstance6 = endParticle;
				GameObject partInst6 = Instantiate (particleInstance6, new Vector3 (0 , -0, -10), particleInstance6.transform.rotation) as GameObject;

				audioSource.PlayOneShot(winMusic);

				particleSpawned = true;
			}
			
			if (endLevelTime > 3.0)
			{
				StartCoroutine (StoryWheelSuccess ());

				AnyDeadFishVal=0;
				TunaDeadFishVal = 0;
				AngelDeadFishVal = 0;
				SharkDeadFishVal = 0;

				endLevelTime = 0.0f;
				particleSpawned = false;
			}
			MasterGameManager.LevelCompleted(6);
			endLevelTime += Time.deltaTime;
		}

		//Level 7 Win Con
		if (currentLevel == 7 && TunaDeadFishVal>=3)
		{
			if (particleSpawned == false)
			{
				GameObject particleInstance7 = endParticle;
				GameObject partInst7 = Instantiate (particleInstance7, new Vector3 (0 , -0, -10), particleInstance7.transform.rotation) as GameObject;

				audioSource.PlayOneShot(winMusic);

				particleSpawned = true;
			}
			
			if (endLevelTime > 3.0)
			{
				
				StartCoroutine (StoryWheelSuccess ());

				AnyDeadFishVal=0;
				TunaDeadFishVal = 0;
				AngelDeadFishVal = 0;
				SharkDeadFishVal = 0;

				endLevelTime = 0.0f;
				particleSpawned = false;
			}
			MasterGameManager.LevelCompleted(7);
			endLevelTime += Time.deltaTime;
		}

		//Level 8 Win Con
		if (currentLevel == 8 && TunaDeadFishVal>=5)
		{
			if (particleSpawned == false)
			{
				GameObject particleInstance8 = endParticle;
				GameObject partInst8 = Instantiate (particleInstance8, new Vector3 (0 , -0, -10), particleInstance8.transform.rotation) as GameObject;

				audioSource.PlayOneShot(winMusic);

				particleSpawned = true;
			}
			
			if (endLevelTime > 3.0 )
			{
				StartCoroutine (StoryWheelSuccess ());

				AnyDeadFishVal=0;
				TunaDeadFishVal = 0;
				AngelDeadFishVal = 0;
				SharkDeadFishVal = 0;

				endLevelTime = 0.0f;
				particleSpawned = false;
			}
			MasterGameManager.LevelCompleted(8);
			endLevelTime += Time.deltaTime;
		}

		//Level 9 Win Con
		if (currentLevel == 9 && ring.destroyedRings>=4)
		{
			if (particleSpawned == false)
			{
				GameObject particleInstance9 = endParticle;
				GameObject partInst9 = Instantiate (particleInstance9, new Vector3 (0 , -0, -10), particleInstance9.transform.rotation) as GameObject;

				audioSource.PlayOneShot(winMusic);

				particleSpawned = true;
			}
			
			if (endLevelTime > 3.0)
			{
				StartCoroutine (StoryWheelSuccess ());
				
				AnyDeadFishVal=0;
				TunaDeadFishVal = 0;
				AngelDeadFishVal = 0;
				SharkDeadFishVal = 0;

				endLevelTime = 0.0f;
				particleSpawned = false;
			}
			MasterGameManager.LevelCompleted(9);
			endLevelTime += Time.deltaTime;
		}

		//Level 10 Win Con
		if (currentLevel == 10 && ring.destroyedRings>=8)
		{
			if (particleSpawned == false)
			{
				GameObject particleInstance10 = endParticle;
				GameObject partInst10 = Instantiate (particleInstance10, new Vector3 (0 , 0, -10), particleInstance10.transform.rotation) as GameObject;

				audioSource.PlayOneShot(winMusic);

				particleSpawned = true;
			}
			
			if (endLevelTime > 3.0)
			{
				StartCoroutine (StoryWheelSuccess ());
				
				AnyDeadFishVal=0;
				TunaDeadFishVal = 0;
				AngelDeadFishVal = 0;
				SharkDeadFishVal = 0;

				endLevelTime = 0.0f;
				particleSpawned = false;
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