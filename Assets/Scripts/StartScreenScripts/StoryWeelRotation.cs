using UnityEngine;
using System.Collections;

public class StoryWeelRotation : MonoBehaviour 
{
	
	public float _sensitivity = 2;
	public float angVelThresholdFinalPosition = 30;
//	public float ambientRotationSpeed = 0.005;
	private Vector3 _mouseReference;
	private Vector3 _mouseOffset;
	private Vector3 _rotation;
	private bool _isRotating;
	private Vector3 _clickDrag;


	
	private bool clockwise = true;

	Rigidbody2D rigBody;

	void Start ()
	{
		rigBody = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	void Update()
	{
		//Click and drag on (hidden) cylinder to ring and fish.
		_clickDrag = Camera.main.ScreenToViewportPoint (Input.mousePosition);

		if(_isRotating)
		{
			// offset
			_mouseOffset = (Input.mousePosition - _mouseReference);
			
			// apply Torque
			if (_clickDrag.y > 0.5) //screenpoint is top half of the screen
			{
				if (_clickDrag.x > 0.5) //screenpoint it in top right quarter of the screen
				{
					rigBody.AddTorque((_mouseOffset.y + -_mouseOffset.x) * _sensitivity);
				}
				else // screenpoint is in top left of the screen
				{
					rigBody.AddTorque(- (_mouseOffset.y + _mouseOffset.x) * _sensitivity);
				}
			} else if (_clickDrag.x > 0.5) //screenpoint is in the bottom right
			{
				rigBody.AddTorque((_mouseOffset.y - _mouseOffset.x) * _sensitivity);
			}
			else //screenpoint is in the bottom left
			{
				rigBody.AddTorque((-_mouseOffset.y - _mouseOffset.x) * _sensitivity);
			}
			// store mouse
			_mouseReference = Input.mousePosition;
		}
		else if(rigBody.angularVelocity < angVelThresholdFinalPosition)
		{
			//if velocity is smaller than threshold than rotate to the closes level
			int closestLevel = gameObject.GetComponent<LevelSelecter>().levelSelected;

			float rotationGoal = closestLevel * 36f - 18f;
			float currentRotation = transform.rotation.z;

//			if(currentRotation <)


		}






		Debug.Log ("Angular Velocity" + rigBody.angularVelocity);

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