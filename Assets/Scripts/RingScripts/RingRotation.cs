using UnityEngine;
using System.Collections;

public class RingRotation : MonoBehaviour 
{
	
	public float _sensitivity;
	public float ambientRotationSpeed;
	private Vector3 _mouseReference;
	private Vector3 _mouseOffset;
	private Vector3 _rotation;
	private bool _isRotating;
	private Vector3 _clickDrag;
	private float rotationOld;
	private Vector3 ringRotation;
	private float gameRotationZ;
	public float rotationMax;
	private bool clockwise;
	private bool lerpToAmbientRotation = false;

	//private GameObject parentObject;
	
	void Start ()
	{
		_sensitivity = 0.5f;
		_rotation = Vector3.zero;
		rotationMax = 30f;

		//pick random rotation direction
		float randomNumber = Random.Range (0, 100);
		if (randomNumber < 50)
			clockwise = false;
		else
			clockwise = true;

		//pick random ambientRotationSpeed
		ambientRotationSpeed = Random.Range (0.01f, 0.09f);
	}

	void Update()
	{

		if (lerpToAmbientRotation)
			LerpToAmbientRotation ();

		//Click and drag on (hidden) cylinder to ring and fish.
		_clickDrag = Camera.main.ScreenToViewportPoint (Input.mousePosition);
		
		if(_isRotating)
		{
			rotationOld = gameRotationZ;

			// offset
			_mouseOffset = (Input.mousePosition - _mouseReference);
			
			// apply rotation
			if (_clickDrag.y > 0.5) //screenpoint is top half of the screen
			{
				if (_clickDrag.x > 0.5) //screenpoint it in top right quarter of the screen
				{
					foreach (Transform child in gameObject.transform )
					{
						if(child.gameObject.tag=="visRing")
						{
							child.transform.GetComponent<Rigidbody2D> ().AddTorque((_mouseOffset.y + -_mouseOffset.x) * _sensitivity);		
					
						}
						if(child.gameObject.tag=="fish")
						{
							child.transform.GetComponent<Rigidbody2D> ().AddTorque((_mouseOffset.y + -_mouseOffset.x) * _sensitivity);
						}
							
						if(child.gameObject.tag=="sharkRing")
						{
							child.transform.GetComponent<Rigidbody2D> ().AddTorque((_mouseOffset.y + -_mouseOffset.x) * _sensitivity);
						}
							
						if(child.gameObject.tag=="tunaRing")
						{
							child.transform.GetComponent<Rigidbody2D> ().AddTorque((_mouseOffset.y + -_mouseOffset.x) * _sensitivity);
						}
					}
				}
				else // screenpoint is in top left of the screen
				{
					foreach (Transform child in gameObject.transform )
					{
						if(child.gameObject.tag=="visRing")
						{
							child.transform.GetComponent<Rigidbody2D> ().AddTorque(- (_mouseOffset.y + _mouseOffset.x) * _sensitivity);		
							
						}
						if(child.gameObject.tag=="fish")
						{
							child.transform.GetComponent<Rigidbody2D> ().AddTorque(- (_mouseOffset.y + _mouseOffset.x) * _sensitivity);
						}
						
						if(child.gameObject.tag=="sharkRing")
						{
							child.transform.GetComponent<Rigidbody2D> ().AddTorque(- (_mouseOffset.y + _mouseOffset.x) * _sensitivity);
						}
						
						if(child.gameObject.tag=="tunaRing")
						{
							child.transform.GetComponent<Rigidbody2D> ().AddTorque(- (_mouseOffset.y + _mouseOffset.x) * _sensitivity);
						}
					}
				}
			} else if (_clickDrag.x > 0.5) //screenpoint is in the bottom right
			{
				foreach (Transform child in gameObject.transform )
				{
					if(child.gameObject.tag=="visRing")
					{
							child.transform.GetComponent<Rigidbody2D> ().AddTorque((_mouseOffset.y + _mouseOffset.x) * _sensitivity);		
							
					}

					if(child.gameObject.tag=="fish")	
					{
							child.transform.GetComponent<Rigidbody2D> ().AddTorque((_mouseOffset.y + _mouseOffset.x) * _sensitivity);
					}
						
					if(child.gameObject.tag=="sharkRing")
					{
							child.transform.GetComponent<Rigidbody2D> ().AddTorque((_mouseOffset.y + _mouseOffset.x) * _sensitivity);
					}
						
					if(child.gameObject.tag=="tunaRing")
					{
							child.transform.GetComponent<Rigidbody2D> ().AddTorque((_mouseOffset.y + _mouseOffset.x) * _sensitivity);
					}
				}

			}
			else //screenpoint is in the bottom left
			{
				foreach (Transform child in gameObject.transform )
				{
					if(child.gameObject.tag=="visRing")
					{
					child.transform.GetComponent<Rigidbody2D> ().AddTorque((-_mouseOffset.y + _mouseOffset.x) * _sensitivity);				
					}
						
					if(child.gameObject.tag=="fish")	
					{
						child.transform.GetComponent<Rigidbody2D> ().AddTorque((-_mouseOffset.y + _mouseOffset.x) * _sensitivity);
					}
						
					if(child.gameObject.tag=="sharkRing")
					{
						child.transform.GetComponent<Rigidbody2D> ().AddTorque((-_mouseOffset.y + _mouseOffset.x) * _sensitivity);
					}
						
					if(child.gameObject.tag=="tunaRing")
					{
						child.transform.GetComponent<Rigidbody2D> ().AddTorque((-_mouseOffset.y + _mouseOffset.x) * _sensitivity);
					}
				}
			}

			// store mouse
			_mouseReference = Input.mousePosition;
		}
		
		if (clockwise) 
		{
			ringRotation = new Vector3(0f,0f,ambientRotationSpeed);
		} else 
		{
			ringRotation = new Vector3(0f,0f,-ambientRotationSpeed);
		}


		if(Time.deltaTime != 0f)
			transform.Rotate(ringRotation);
	}
	
	void OnMouseDown()
	{
		// rotating flag
		_isRotating = true;

		lerpToAmbientRotation = false;
		
		// store mouse
		_mouseReference = Input.mousePosition;
	}
	
	void OnMouseUp()
	{
		// rotating flag
		_isRotating = false;
		lerpToAmbientRotation = true;
	}

	void LerpToAmbientRotation()
	{	
		if (Time.deltaTime != 0)
		{
			foreach (Transform child in gameObject.transform) {
				if (child.gameObject.tag == "visRing") {
					gameRotationZ = Mathf.Lerp (rotationOld, ringRotation.z, 1 * Time.deltaTime);
					child.transform.Rotate (new Vector3 (0, 0, gameRotationZ));
				}
			
				if (child.gameObject.tag == "fish") {
					gameRotationZ = Mathf.Lerp (rotationOld, ringRotation.z, 1 * Time.deltaTime);
					child.transform.Rotate (new Vector3 (0, 0, gameRotationZ));
				}

				if (child.gameObject.tag == "sharkRing") {
					gameRotationZ = Mathf.Lerp (rotationOld, ringRotation.z, 1 * Time.deltaTime);
					child.transform.Rotate (new Vector3 (0, 0, gameRotationZ));
				}

				if (child.gameObject.tag == "tunaRing") {
					gameRotationZ = Mathf.Lerp (rotationOld, gameRotationZ, 1 * Time.deltaTime);
					//Rotate tuna slightly faster than fish.
					child.transform.Rotate (new Vector3 (0, 0, gameRotationZ));
				}
			}
			rotationOld = gameRotationZ ;
		}

	}
	
}