using UnityEngine;
using System.Collections;

public class StoryWeelRotation : MonoBehaviour 
{
	
	public float _sensitivity = 2;
	public float angVelThresholdFinalPosition = 20;
//	public float ambientRotationSpeed = 0.005;
	private Vector3 _mouseReference;
	private Vector3 _mouseOffset;
	private Vector3 _rotation;
	private bool _isRotating;
	private Vector3 _clickDrag;

	bool startLerp = false;
	
	private bool clockwise = true;

	Rigidbody2D rigBody;

	int closestLevel;
	float rotationGoal;
	float currentRotation;

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
		else if(rigBody.angularVelocity < angVelThresholdFinalPosition && rigBody.angularVelocity > -angVelThresholdFinalPosition  )
		{
			if(startLerp){
				startLerp = false;
				StartLerp();
			}

			float applyRotation = Mathf.LerpAngle(transform.eulerAngles.z, rotationGoal, Time.deltaTime * 2f);
			transform.eulerAngles = new Vector3(0f,0f, applyRotation);


		}
		Debug.Log("RotationGoal" + rotationGoal+ "current rot: "+ transform.eulerAngles.z * Mathf.Rad2Deg);
	}

	void StartLerp()
	{
		rigBody.angularVelocity = 0f;
		closestLevel = gameObject.GetComponent<LevelSelecter>().levelSelected;
		rotationGoal = closestLevel * 36f - 18f;
		Debug.Log("RotationGoal" + rotationGoal+ "current rot: "+ transform.rotation.z * Mathf.Rad2Deg);

	}
	
	void OnMouseDown()
	{
		// rotating flag
		_isRotating = true;

		startLerp = true;

		// store mouse
		_mouseReference = Input.mousePosition;
	}
	
	void OnMouseUp()
	{
		// rotating flag
		_isRotating = false;
	}
	
}