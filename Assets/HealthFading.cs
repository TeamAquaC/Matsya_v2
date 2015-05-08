using UnityEngine;
using System.Collections;

public class HealthFading : MonoBehaviour {

	public Texture2D fadeTexture;

	private int drawDepth = -1000;
	private float alpha = 0.0f;
	private float alphaOld = 0;

	private ManInTheBoatScript manInTheBoatScript;

	void Start()
	{
		manInTheBoatScript = GameObject.Find ("ManInTheBoatObject").GetComponent<ManInTheBoatScript> ();
	}

	void Update()
	{
		float health = manInTheBoatScript.health;
		
		if (health < 20) {
			alpha = Remap (health, 0f, 20f, 1f, 0f);
		} 
		else 
		{
			alpha = 0;
		}
		
		alpha = Mathf.Lerp(alphaOld,alpha,Time.deltaTime);
		alphaOld = alpha;
	}
	
	void OnGUI()
	{

		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeTexture);
	}

	private float Remap (this float value, float from1, float to1, float from2, float to2) 
	{
		return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
	}
}
