 using UnityEngine;
using System.Collections;

public class LevelSelecter : MonoBehaviour {

	public int levelSelected;

	void Update()
	{

		float rotZ = gameObject.transform.rotation.eulerAngles.z ;
		levelSelected = 1 + Mathf.RoundToInt(((rotZ)/36f)-0.5f);

	}
	


}
