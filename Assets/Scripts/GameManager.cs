using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null; 
	public GameObject ringManager;

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
		DontDestroyOnLoad(gameObject);

		GameObject instanc = Instantiate (ringManager, new Vector3(0f,0f,0f), Quaternion.identity) as GameObject;
		instanc.transform.SetParent(transform);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
