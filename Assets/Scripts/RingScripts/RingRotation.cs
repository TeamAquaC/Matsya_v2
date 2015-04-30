﻿using UnityEngine;
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

	private bool clockwise;
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
		//Click and drag on (hidden) cylinder to ring and fish.
		
		_clickDrag = Camera.main.ScreenToViewportPoint (Input.mousePosition);
		
		if(_isRotating)
		{
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
				
					child.transform.Rotate(_rotation);
				}

				if(child.gameObject.tag=="fish")
				{
					child.transform.Rotate(0.25f*_rotation);
				}
			}

			// rotate
			//gameObject.transform.Rotate(_rotation);
			
			// store mouse
			_mouseReference = Input.mousePosition;


		}

		Vector3 ringRotation;
		if (clockwise) 
		{
			ringRotation = new Vector3(0f,0f,ambientRotationSpeed);
		} else 
		{
			ringRotation = new Vector3(0f,0f,-ambientRotationSpeed);
		}

		transform.Rotate(ringRotation);

		/*//Rotate fish in ring.
		
		foreach (Transform child in parentObject.transform)
		{
			transform.Rotate(_rotation);
		}*/
	}
	
	void OnMouseDown()
	{
		// rotating flag
		_isRotating = true;
		
		// store mouse
		_mouseReference = Input.mousePosition;
	}
	
	void OnMouseUp()
	{
		// rotating flag
		_isRotating = false;
	}
	
}