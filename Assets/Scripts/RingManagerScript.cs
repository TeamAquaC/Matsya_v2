using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class RingManagerScript : MonoBehaviour {

	public GameObject[] rings;
	public GameObject visRing01;
	public GameObject visRing02;
	public GameObject visRing03;
	public GameObject visRing04;
	public GameObject hiddenRing01;
	public GameObject hiddenRing02;
	public GameObject hiddenRing03;
	public GameObject hiddenRing04;
	public float ringScaleSpeed = 0;
	public float removeRingThreshold = 0.2f;
	public float spawnNewRingThreshold = 2f;
	private float fadeInThreshold = 1f;
	public GameObject sharkSpawnRing;
	Vector3 vec;
	public int DestroyedRings = 0;
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
	private List<Transform> taggedChildren;
	private Transform boardHolder;
	private int totalRingCount;
	private int visRingCount;
	float timer;
	
	// Use this for initialization
	void Start ()
	{
		timer = 0.0f;
		totalRingCount = 0;
		visRingCount = 0;

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
				 
			if(Time.deltaTime != 0)
			{
				foreach (GameObject go in ringList) {									//Scale all the rings by a given factor
					float s = go.transform.localScale.x; 
					s -= s / ringScaleSpeed; 
					Vector3 xyzS = new Vector3 (s, s, s);
					go.transform.localScale = xyzS;
				}
			}

				if (ringList [0].transform.localScale.x < .33f) 
			    {						                                    //If ring is too small destroy it
					Destroy (ringList[0].gameObject);
					ringList.RemoveAt (0);
				    DestroyedRings ++;
				}
				if (ringList [ringList.Count - 1].transform.localScale.x < 1.4f) 		//If the lagest ring is at a specific scale add a new big ring
				{
					newRing ();
				}
			}

		if(totalRingCount >=5 && ringList != null){
			
			if (ringList[0].gameObject.GetComponentInChildren<fishInstancer>().fishCount < 1){
				ringScaleSpeed = 1000f;
			}else{
				ringScaleSpeed = 10000f;
			}
		}

		//Used to tell healthFading script where to spawn sharks. To avoid error, waits until at least 3 rings are on screen.
		if (totalRingCount >= 3) {
			sharkSpawnRing = ringList [2];
		}
	}

	Vector3 getRingZPosition()
	{
		vec = new Vector3 (0f,0f,1+(0.001f * totalRingCount));
		totalRingCount += 1;
		visRingCount += 1;
		visRingCount = visRingCount % 4;
		return vec;
	}

	void newRing()
	{
		GameObject toInstanciate = rings [0];
		toInstanciate.transform.localScale = new Vector3(2f,2f,2f);
		GameObject instance = Instantiate (toInstanciate, getRingZPosition(), Quaternion.identity) as GameObject;
		instance.gameObject.tag="RingHome";
		instance.transform.SetParent (boardHolder);

		//Choose which visible ring to spawn based on number of rings in play.
		GameObject visInstantiate;

		//commented out to test ring color change with only one ring sprite

		if (visRingCount == 1) {
			visInstantiate = visRing01;
		} else if (visRingCount == 2) {
			visInstantiate = visRing02;
		} else if (visRingCount == 3) {
			visInstantiate = visRing03;
		} else {
			visInstantiate = visRing04;
		}

		//added to test ring color change with one ring sprite
//		visInstantiate= visRing01;
		GameObject visibleRing = Instantiate (visInstantiate, vec, Quaternion.identity) as GameObject;
		visibleRing.transform.SetParent (instance.transform);

		//Do the same for the background shader ring.

		if (visRingCount == 1) {
			visInstantiate = hiddenRing01;
		} else if (visRingCount == 2) {
			visInstantiate = hiddenRing02;
		} else if (visRingCount == 3) {
			visInstantiate = hiddenRing03;
		} else {
			visInstantiate = hiddenRing04;
		}

		GameObject shaderRing = Instantiate (visInstantiate, vec, Quaternion.identity) as GameObject;
		shaderRing.transform.SetParent (instance.transform);

		ringList.Add (instance);
	}
}
