﻿using UnityEngine;
using System.Collections;

public class ManInTheBoatScript : MonoBehaviour 
{


	public float health;
	private float timer = 0f;

	private float healthMiddle = 50f;
	private float greenHealthZone = 10f;
	private float orangeHealthZone = 20f;
	private float redHealthZone = 30;

	private TextMesh healthBarText;

	void Awake()
	{
		healthBarText = gameObject.GetComponent<TextMesh>();
	}

	void Start()
	{
		health = 50.0f;
	}

	void Update()
	{
		timer += Time.deltaTime;

		//if health is 0 let the man die
		if (health <= 0.0f) 
		{
			health = 0f;
			ManInTheBoatIsDead();
		}

		//reduce the health of the man in the boat at a fixed time interval
		if (timer >= 0.75f) 
		{
			health -= 1f;
			timer = 0.0f;
			UpdateLifeBar ();
		}

		//handels what happens when the health changes
		HealthIndicator ();
	

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

	public void HealthIndicator()
	{
		//health is in the red zone
		if (health > healthMiddle + redHealthZone || health < healthMiddle - redHealthZone ) 
		{
			healthBarText.color = new Color (255, 0, 0);
		}
		//health is in the orange zone
		else if(health > healthMiddle + orangeHealthZone || health < healthMiddle - orangeHealthZone ) 
		{
			healthBarText.color = new Color (127, 127, 0);
		}
		//health is in the gree zone
		else if(health > healthMiddle + greenHealthZone || health < healthMiddle - greenHealthZone ) 
		{
			healthBarText.color = new Color (0, 255, 0);
		}

		//change mesh text to the right falue
		healthBarText.text = Mathf.RoundToInt(health).ToString();
	}




}
