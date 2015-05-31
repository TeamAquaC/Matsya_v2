using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelTextScript : MonoBehaviour {

	public GameObject storyWheel;
	int currentLev;
	public Text guiText;

	// Use this for initialization
	void Start () {



		guiText = gameObject.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {

		LevelSelecter levelSelectScript = storyWheel.GetComponent<LevelSelecter> ();
		currentLev = levelSelectScript.levelSelected;
		
		if (currentLev == 1 && MasterGameManager.Levels [0].unlocked) {
			guiText.text = "The fisherman must learn to fish, help him catch three fish with his spear in order to progress";
			guiText.fontSize = 100;
		} else if (currentLev == 1) {
			guiText.text = "Level locked - Spin ring to an available level";
			guiText.fontSize = 100;
		}

		if (currentLev == 2 && MasterGameManager.Levels [1].unlocked) {
			guiText.text = "There are many small fish, but he will catch three large fish to progress";
			guiText.fontSize = 100;
		} else if (currentLev == 2){
			guiText.text = "Level locked - Spin ring to an available level";
			guiText.fontSize = 100;
		}

		
		if (currentLev == 3 && MasterGameManager.Levels [2].unlocked) {
			guiText.text = "He’s overfished and the sharks have come - Don't let any more fish be caught!";
			guiText.fontSize = 100;
		} else if (currentLev == 3){
			guiText.text = "Level locked - Spin ring to an available level";
			guiText.fontSize = 100;
		}

		if (currentLev == 4 && MasterGameManager.Levels [3].unlocked) {
			guiText.text = "If the fisherman catches all the fish in the innermost ring, it will dissappear -" +
				"Make it through three rings and help him catch one shark to proceed";
			guiText.fontSize = 80;
		} else if (currentLev == 4){
			guiText.text = "Level locked. Spin ring to an available level";
			guiText.fontSize = 100;
		}

		if (currentLev == 5 && MasterGameManager.Levels [4].unlocked) {
			guiText.text = "Now that he knows how to fish, help him progress through five rings";
			guiText.fontSize = 100;
		} else if (currentLev == 5){
			guiText.text = "Level locked - Spin ring to an available level";
			guiText.fontSize = 100;
		}

		if (currentLev == 6 && MasterGameManager.Levels [5].unlocked) {
			guiText.text = "Help him catch three sharks, but be careful that he doesn’t overfish in the process";
			guiText.fontSize = 100;
		} else if (currentLev == 6){
			guiText.text = "Level locked - Spin ring to an available level";
			guiText.fontSize = 100;
		}

		if (currentLev == 7 && MasterGameManager.Levels [6].unlocked) {
			guiText.text = "He needs small fish but they’re only in the outermost ring - " +
				"Careful he doesn’t hit the ones in the closer rings or the sharks will come back";
			guiText.fontSize = 80;
		} else if (currentLev == 7){
			guiText.text = "Level locked - Spin ring to an available level";
			guiText.fontSize = 100;
		}

		if (currentLev == 8 && MasterGameManager.Levels [7].unlocked) {
			guiText.text = "The waters have gotten faster, keep all of the fish alive until the small one comes";
			guiText.fontSize = 100;
		} else if (currentLev == 8){
			guiText.text = "Level locked - Spin ring to an available level";
			guiText.fontSize = 100;
		}

		if (currentLev == 9 && MasterGameManager.Levels [8].unlocked) {
			guiText.text = "Can you help him progress through five rings? Be careful, the waters will get faster with each one";
			guiText.fontSize = 90;
		} else if (currentLev == 9){
			guiText.text = "Level locked - Spin ring to an available level";
			guiText.fontSize = 100;
		}

		if (currentLev == 10 && MasterGameManager.Levels [9].unlocked) {
			guiText.text = "Now try to get through ten rings! Beware, the water will keep getting faster";
			guiText.fontSize = 100;
		} else if (currentLev == 10){
			guiText.text = "Level locked - Spin ring to an available level";
			guiText.fontSize = 100;
		}
		
//		Debug.Log ("Current level is " + currentLev);
	}
}
