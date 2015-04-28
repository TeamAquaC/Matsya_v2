using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class RingManager : MonoBehaviour {

	public GameObject[] rings;
	public float ringScaleSpeed = 0;
	public float removeRingThreshold = 0.2f;
	public float spawnNewRingThreshold = 2f;
	private float fadeInThreshold = 1f;
	public GameObject ringHome;
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
			if (GameObject.FindGameObjectsWithTag("angelFish").Length>5){
			ringScaleSpeed = 1000f;
			}else{
				ringScaleSpeed = 10000f;
			}
		}

			GameObject[] gos = GameObject.FindGameObjectsWithTag ("RingHome");				//find all rings in game an add them to the list ringList
			if(gos != null)
			{
				foreach (GameObject go in gos) {
					ringList.Add (go);
				}
			}
	

			if(ringList != null)
			{
				ringList = ringList.OrderBy (x => x.transform.localScale.x).ToList (); //Sort all rings small to large.
				 
				foreach (GameObject go in ringList) {									//Scale all the rings by a given factor
					float s = go.transform.localScale.x; 
					s -= s / ringScaleSpeed; 
					Vector3 xyzS = new Vector3 (s, s, s);
					go.transform.localScale = xyzS;
				}

				if (ringList [0].transform.localScale.x < 0.33f) {						//If ring is to small destroy it
					Destroy (ringList[0].gameObject);
					ringList.RemoveAt (0);
				}
				if (ringList [ringList.Count - 1].transform.localScale.x < 1.4f) 		//If the lagest ring is at a specific scale add a new big ring
				{
					newRing ();
				}
			}

		Debug.Log ("Ring Count: " + ringList.Count);
	}

	Vector3 getRingZPosition()
	{
		Vector3 vec = new Vector3 (0f,0f,1+(0.001f * totalRingCount));
		totalRingCount += 1;
		return vec;
	}

	void newRing()
	{
		GameObject toInstanciate = rings [0];
		toInstanciate.transform.localScale = new Vector3(2f,2f,2f);
		GameObject instance = Instantiate (toInstanciate, getRingZPosition(), Quaternion.identity) as GameObject;
		instance.gameObject.tag="RingHome";
		//ringHome.gameObject.AddComponent (Collider2D);
		instance.transform.SetParent (boardHolder);
		ringList.Add (instance);


	}
}
