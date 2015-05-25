using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null; 
	public GameObject ringManager;
	public int currentLevel;
	int AnyDeadFishVal;
	int TunaDeadFishVal;
	int AngelDeadFishVal;
	int SharkDeadFishVal;
	private bool gameOver = false;
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
			Destroy(gameObject);    
		
		//Sets this to not be destroyed when reloading scene
//		DontDestroyOnLoad(gameObject);


		GameObject instanc = Instantiate (ringManager, new Vector3(0f,0f,0f), Quaternion.identity) as GameObject;
		instanc.transform.SetParent(transform);
		


		man = GameObject.Find("ManInTheBoatObject").GetComponent<ManInTheBoatScript>();
		ring = instanc.GetComponent<RingManagerScript> ();
		Debug.Log ("We are in level: " + (Application.loadedLevel - 1));
		currentLevel = Application.loadedLevel - 1;
		if (currentLevel == 1)
			man.health = 50.0f;
		if (currentLevel == 2)
			man.health = 20.0f;
		if (currentLevel == 3)
			man.health = 90.0f;
		if (currentLevel == 4)
			man.health = 65.0f;
		if (currentLevel == 5)
			man.health = 50.0f;
		if (currentLevel == 6)
			man.health = 50.0f;
		
	}

	void Start()
	{

		Camera.main.orthographicSize = 6;
		AnyDeadFishVal = 0;
		TunaDeadFishVal = 0;
		AngelDeadFishVal = 0;
		SharkDeadFishVal = 0;
	}
	// Update is called once per frame
	void Update () 
	{
		if (AnyDeadFishVal == 3 && currentLevel == 1) 
		{
			StartCoroutine (StoryWheelSuccess ());
			AnyDeadFishVal=0;
			TunaDeadFishVal = 0;
			AngelDeadFishVal = 0;
			SharkDeadFishVal = 0;
			MasterGameManager.LevelCompleted(1);
		}
		if (currentLevel==2 && AngelDeadFishVal == 3)
		{
			StartCoroutine (StoryWheelSuccess ());
			AnyDeadFishVal = 0;
			TunaDeadFishVal = 0;
			AngelDeadFishVal = 0;
			SharkDeadFishVal = 0;
			MasterGameManager.LevelCompleted(2);

		}
		if (currentLevel == 3 && man.health <= 50.0f) 
		{
			StartCoroutine (StoryWheelSuccess ());
			AnyDeadFishVal = 0;
			TunaDeadFishVal = 0;
			AngelDeadFishVal = 0;
			SharkDeadFishVal = 0;
			MasterGameManager.LevelCompleted(3);
	    }
		if (currentLevel == 4 && SharkDeadFishVal >= 1 && ring.destroyedRings >= 3)
		{
			StartCoroutine (StoryWheelSuccess ());
			AnyDeadFishVal = 0;
			TunaDeadFishVal = 0;
			AngelDeadFishVal = 0;
			SharkDeadFishVal = 0;
			MasterGameManager.LevelCompleted(4);
		}
		if (currentLevel == 5 && ring.destroyedRings >= 5)
		{
			StartCoroutine (StoryWheelSuccess ());
			AnyDeadFishVal = 0;
			TunaDeadFishVal = 0;
			AngelDeadFishVal = 0;
			SharkDeadFishVal = 0;
			MasterGameManager.LevelCompleted(5);
		}
		if (currentLevel == 6 && SharkDeadFishVal>=3)
		{
			StartCoroutine (StoryWheelSuccess ());
			AnyDeadFishVal = 0;
			TunaDeadFishVal = 0;
			AngelDeadFishVal = 0;
			SharkDeadFishVal = 0;
			MasterGameManager.LevelCompleted(6);
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
		Debug.Log ("Shark Killed: "+ SharkDeadFishVal);
	}
	
	
	public IEnumerator StoryWheelSuccess()
	{
		float fadeTime = GameObject.Find ("Main Camera").GetComponent<SceneFading> ().BeginFade (1);
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel ("StoryWeelScene");
	}
}