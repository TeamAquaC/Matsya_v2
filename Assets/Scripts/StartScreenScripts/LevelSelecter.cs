using UnityEngine;
using System.Collections;

public class LevelSelecter : MonoBehaviour {

	int levelSelected;

	void Update()
	{

		float rotZ = gameObject.transform.rotation.eulerAngles.z ;
		levelSelected = Mathf.RoundToInt(((rotZ)/36f)-0.5f);
		Debug.Log ("You selected Level__: " + levelSelected);

	}
	


}
