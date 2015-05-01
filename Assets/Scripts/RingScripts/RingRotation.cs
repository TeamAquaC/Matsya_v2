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

	private bool clockwise;
	private bool lerpToAmbientRotation = false;
	//private GameObject parentObject;
	
	void Start ()
	{
		_sensitivity = 0.4f;
		_rotation = Vector3.zero;

		//pick random rotation direction
		float randomNumber = Random.Range (0, 100);
		if (randomNumber < 50)
			clockwise = false;
		else
			clockwise = true;

		//pick random ambientRotationSpeed
		ambientRotationSpeed = Random.Range (0.01f, 0.09f);

		//parentObject = transform.parent.gameObject;
	}

	void Update()
	{

		if (lerpToAmbientRotation)
			LerpToAmbientRotation ();

		//Click and drag on (hidden) cylinder to ring and fish.
		_clickDrag = Camera.main.ScreenToViewportPoint (Input.mousePosition);
		
		if(_isRotating)
		{
			rotationOld = _rotation.z;

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



			//Rotate fish in ring.
			
			foreach (Transform child in gameObject.transform )
			{
				if(child.gameObject.tag=="Ring")
				{
					_rotation.z = Mathf.Lerp (rotationOld, _rotation.z, 10*Time.deltaTime);
					child.transform.Rotate(_rotation);
				}

				if(child.gameObject.tag=="fish")
				{
					_rotation.z = Mathf.Lerp (rotationOld, _rotation.z, 10*Time.deltaTime);
					child.transform.Rotate(_rotation);
				}
			}

			//ringRotation.z = _rotation.z;

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
				_rotation.z = Mathf.Lerp (rotationOld, ringRotation.z, 1*Time.deltaTime);
				child.transform.Rotate(_rotation);
			}
			
			if(child.gameObject.tag=="fish")
			{
				_rotation.z = Mathf.Lerp (rotationOld, ringRotation.z, 1*Time.deltaTime);
				child.transform.Rotate(_rotation);
			}
		}
		
		rotationOld = _rotation.z ;


	}
	
}