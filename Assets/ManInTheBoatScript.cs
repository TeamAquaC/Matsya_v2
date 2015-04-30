using UnityEngine;
using System.Collections;

public class ManInTheBoatScript : MonoBehaviour 
{


	public float health;
	private float timer = 0f;

	void Start()
	{
		health = 50.0f;
	}

	void Update()
	{
		timer += Time.deltaTime;

		if (health <= 0.0f) 
		{
			health = 0f;
			ManInTheBoatIsDead();
		}


		if (timer >= 2.0f) 
		{
			health -= 0.5f;
			timer = 0.0f;
			UpdateLifeBar ();
		}

	

	}

	public void FishKilled(float valueOfFish)
	{
		health += valueOfFish;
		UpdateLifeBar();
	}

	public void UpdateLifeBar()
	{

		Debug.Log (health);
	}

	public void ManInTheBoatIsDead()
	{
		Debug.Log ("You suck");
	}




}
