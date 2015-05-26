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
			guiText.text = "The fisherman must learn to fish, help him catch three fish with his spear in order to progress.";
		} else if (currentLev == 1) {
			guiText.text = "Level locked. Spin ring to an available level.";
		}

		if (currentLev == 2 && MasterGameManager.Levels [1].unlocked) {
			guiText.text = "Careful that he does not starve, when he’s hungry, a lot of small fish will " +
				"appear but he can only feed himself if you help him catch three larger fish.";
		} else if (currentLev == 2){
			guiText.text = "Level locked. Spin ring to an available level.";
		}

		
		if (currentLev == 3 && MasterGameManager.Levels [2].unlocked) {
			guiText.text = "He’s overfished and the sharks have come. They will " +
				"leave on their own, but only if he stops fishing until they are gone.";
		} else if (currentLev == 3){
			guiText.text = "Level locked. Spin ring to an available level.";
		}

		if (currentLev == 4 && MasterGameManager.Levels [3].unlocked) {
			guiText.text = "He needs to catch a shark, but it will only come if " +
				"you help him progress through three rings.";
		} else if (currentLev == 4){
			guiText.text = "Level locked. Spin ring to an available level.";
		}

		if (currentLev == 5 && MasterGameManager.Levels [4].unlocked) {
			guiText.text = "Now that he knows how to fish, help him progress through five rings.";
		} else if (currentLev == 5){
			guiText.text = "Level locked. Spin ring to an available level.";
		}

		if (currentLev == 6 && MasterGameManager.Levels [5].unlocked) {
			guiText.text = "Help him catch three sharks, but be careful that he doesn’t overfish in the process.";
		} else if (currentLev == 6){
			guiText.text = "Level locked. Spin ring to an available level.";
		}

		if (currentLev == 7 && MasterGameManager.Levels [6].unlocked) {
			guiText.text = "He needs small fish but they’re only in the outermost ring. " +
				"Careful he doesn’t hit the ones in the closer rings or the sharks will come back.";
		} else if (currentLev == 7){
			guiText.text = "Level locked. Spin ring to an available level.";
		}

		if (currentLev == 8 && MasterGameManager.Levels [7].unlocked) {
			guiText.text = "The fisherman must learn to fish, help him catch three with his spear in order to progress.";
		} else if (currentLev == 8){
			guiText.text = "Level locked. Spin ring to an available level.";
		}

		if (currentLev == 9 && MasterGameManager.Levels [8].unlocked) {
			guiText.text = "Can you help him progress through five rings? Be careful, the waters will get faster with each one.";
		} else if (currentLev == 9){
			guiText.text = "Level locked. Spin ring to an available level.";
		}

		if (currentLev == 10 && MasterGameManager.Levels [9].unlocked) {
			guiText.text = "Now try to get through ten rings. Beware, the water will keep getting faster.";
		} else if (currentLev == 10){
			guiText.text = "Level locked. Spin ring to an available level.";
		}
		
		Debug.Log ("Current level is " + currentLev);
	}
}
