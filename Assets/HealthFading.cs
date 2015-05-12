using UnityEngine;
using System.Collections;

public class HealthFading : MonoBehaviour {

	public Texture2D fadeTexture;
	public Texture2D redFadeTexture;
	private int drawDepth = -1000;
	private float alpha = 0.0f;
	private float alphaOld = 0;
	public float sharkTimer;
	private ManInTheBoatScript manInTheBoatScript;
	float health;
	public float sharkSpawnTime;
	public GameObject shark;
	public GameObject gameManager;

	void Start()
	{
		manInTheBoatScript = GameObject.Find ("ManInTheBoatObject").GetComponent<ManInTheBoatScript> ();
		sharkTimer = 0.0f;
		sharkSpawnTime = 5.0f;
	}

	void Update()
	{
		health = manInTheBoatScript.health;
		
		if (health < 30) {
			alpha = Remap (health, 0f, 30f, 1f, 0f);
		} else if (health > 70) {
			alpha = Remap (health, 100f, 70f, 1f, 0f);
		}else
		{
			alpha = 0;
		}

		
		//If health is too high and not enough sharks, add to shark timer
		if (GameObject.FindGameObjectsWithTag ("shark").Length == 0 && health > 55.0f) {
			sharkTimer += Time.deltaTime;
		} else if (GameObject.FindGameObjectsWithTag ("shark").Length == 1 && health > 70.0f) {
			sharkTimer += Time.deltaTime;
		} else if (GameObject.FindGameObjectsWithTag ("shark").Length == 2 && health > 85.0f) {
			sharkTimer += Time.deltaTime;
		} else {
			sharkTimer = 0.0f;
		}

		//Spawn a shark if sharkTimer limit is reached.
			if (sharkTimer > sharkSpawnTime)
				{
					sharkSpawn();
				}



		alpha = Mathf.Lerp(alphaOld,alpha,Time.deltaTime);
		alphaOld = alpha;
	}
	
	void OnGUI()
	{
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		if (health < 50f) {
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeTexture);
		} else {
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), redFadeTexture);
		}
		
	}

	private float Remap (this float value, float from1, float to1, float from2, float to2) 
	{
		return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
	}

	void sharkSpawn() 
	{
		RingManagerScript ringTracker = gameManager.GetComponentInChildren<RingManagerScript> ();
		GameObject outerRing = ringTracker.sharkSpawnRing;

		//Get ringhomes current scale.
		float currentScale = outerRing.transform.localScale.x;
		
		GameObject sharkInstance = shark;
		
		//Script used to instantiate shar, as a child of sharkRing in the third ring.
		float spawnOffset = outerRing.transform.localScale.x;
		GameObject newFish = Instantiate (sharkInstance, new Vector3 (0 , -8f*spawnOffset, -1), sharkInstance.transform.rotation) as GameObject;
		newFish.transform.parent = outerRing.transform.FindChild("sharkRing");
		newFish.transform.localScale *= 1.75f*currentScale;
		sharkTimer = 0.0f;
	}

}
