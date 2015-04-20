using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class RingManager : MonoBehaviour {

	public GameObject[] rings;
	public float ringScaleSpeed = 500;
	public float removeRingThreshold = 0.2f;
	public float spawnNewRingThreshold = 2f;
	private float fadeInThreshold = 1f;
	public float FadeInThreshold
	{
		get
		{
			return fadeInThreshold;
		}
	}
	private float fadeOutThreshold = 0.4f;
	public float FadeOutThreshold
	{
		get
		{
			return fadeOutThreshold;
		}
	}

	private List<GameObject> ringList;
	private Transform boardHolder;
	private int totalRingCount;
	float timer;
	
	// Use this for initialization
	void Start ()
	{
		timer = 0.0f;
		totalRingCount = 0;

		ringList = new List<GameObject> ();
		boardHolder = new GameObject ("Board").transform;
	}

	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;
		ringList.Clear ();

		if (totalRingCount < 1) {
			ringScaleSpeed = 100f;
			newRing ();
		}
		if(totalRingCount >=5 ){
			ringScaleSpeed = 1500;
		}

			GameObject[] gos = GameObject.FindGameObjectsWithTag ("Ring");				//find all rings in game an add them to the list ringList
			if(gos != null)
			{
				foreach (GameObject go in gos) {
					ringList.Add (go);
				}
			}
	

			if(ringList != null)
			{
				ringList = ringList.OrderBy (x => x.transform.localScale.x).ToList (); //Sort all rings small to lage.
				 
				foreach (GameObject go in ringList) {									//Scale all the rings by a given factor
					float s = go.transform.localScale.x; 
					s -= s / ringScaleSpeed; 
					Vector3 xyS = new Vector3 (s, s);
					go.transform.localScale = xyS;
				}

				if (ringList [0].transform.localScale.x < 0.33f) {						//If ring is to smale destroy it
					Destroy (ringList [0]);
					ringList.RemoveAt (0);
				}
				if (ringList [ringList.Count - 1].transform.localScale.x < 1.3f) 		//If the lagest ring is at a specivic scale add a new big ring
				{
					newRing ();
				}
			}

		Debug.Log ("Ring Count: " + ringList.Count);
	}

	Vector3 getRingZPosition()
	{
		Vector3 vec = new Vector3 (0f,0f,-0.001f * -totalRingCount);
		totalRingCount += 1;
		return vec;
	}

	void newRing()
	{
		GameObject toInstanciate = rings [0];
		toInstanciate.transform.localScale = new Vector3(2f,2f,1f);
		GameObject instance = Instantiate (toInstanciate, getRingZPosition(), Quaternion.identity) as GameObject;
		instance.transform.SetParent (boardHolder);
		ringList.Add (instance);


	}
}
