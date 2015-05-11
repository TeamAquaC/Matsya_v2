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
		rotationMax = 10f;

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
					_rotation.z = (_mouseOffset.y + -_mouseOffset.x) * _sensitivity;
				}
				else // screenpoint is in top left of the screen
				{
					_rotation.z = - (_mouseOffset.y + _mouseOffset.x) * _sensitivity;
				}
			} else if (_clickDrag.x > 0.5) //screenpoint is in the bottom right
			{
				_rotation.z = (_mouseOffset.y + _mouseOffset.x) * _sensitivity;
			}
			else //screenpoint is in the bottom left
			{
				_rotation.z = (-_mouseOffset.y + _mouseOffset.x) * _sensitivity;
			}

			//Set rotation equal to current input, or to maxRotation if player input too fast.

			if (_rotation.z > rotationMax){
				gameRotationZ = rotationMax;
			}else if(_rotation.z < -rotationMax){
				gameRotationZ = -rotationMax;
			}else{
				gameRotationZ =_rotation.z;
			}

			//Rotate fish in ring.
			
			foreach (Transform child in gameObject.transform )
			{
				if(child.gameObject.tag=="Ring")
				{
					gameRotationZ = Mathf.Lerp (rotationOld, gameRotationZ, 10*Time.deltaTime);
					child.transform.Rotate(new Vector3(0,0,gameRotationZ));
				}

				if(child.gameObject.tag=="fish")
				{
					gameRotationZ = Mathf.Lerp (rotationOld, gameRotationZ, 8*Time.deltaTime);
					//Rotate fish slightly more slowly than ring.
					child.transform.Rotate(new Vector3(0,0,gameRotationZ)*0.85f);
				}

				if(child.gameObject.tag=="sharkRing")
				{
					gameRotationZ = Mathf.Lerp (rotationOld, gameRotationZ, 4*Time.deltaTime);
					//Rotate sharks even more slowly.
					child.transform.Rotate(new Vector3(0,0,gameRotationZ)*0.5f);
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
		foreach (Transform child in gameObject.transform )
		{
			if(child.gameObject.tag=="Ring")
			{
				gameRotationZ = Mathf.Lerp (rotationOld, ringRotation.z, 1*Time.deltaTime);
				child.transform.Rotate(new Vector3(0, 0, gameRotationZ));
			}
			
			if(child.gameObject.tag=="fish")
			{
				gameRotationZ = Mathf.Lerp (rotationOld, ringRotation.z, 1*Time.deltaTime);
				child.transform.Rotate(new Vector3(0, 0, gameRotationZ));
			}

			if(child.gameObject.tag=="sharkRing")
			{
				gameRotationZ = Mathf.Lerp (rotationOld, ringRotation.z, 1*Time.deltaTime);
				child.transform.Rotate(new Vector3(0, 0, gameRotationZ));
			}
		}
		
		rotationOld = gameRotationZ ;


	}
	
}