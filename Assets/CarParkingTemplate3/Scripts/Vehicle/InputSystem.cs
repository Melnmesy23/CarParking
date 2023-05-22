//--------------------------------------------------------------
//
//                    Car Parking Template 3.0
//        
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class InputSystem : MonoBehaviour
{


	// Select control type => Touch or keyboard
	public InputType controllType;

	VehicleController2017 controller;

	// Automatically detect target platform input type (mobile keyboard)
	public bool autoSwitch;

	float motorInput,steerInput;
	bool handBrake;

	bool reversing;

	[Header("Visuals")]
	public UnityEngine.UI.Image reverseImage;
	public Sprite reverseOffSprite,reverseOnSprite;

	[Header("Components")]
	public SteeringWheel steeringWheel;
	bool sWheelControl;

	public GameObject sWheel;
	public GameObject arrowKeys;

	// Accelerometer controlling
	[Header("Accelerometer")]
	public float accelSensibility  = 10f;
	public float accelSmooth = 0.5f;
	Vector3 curAc;
	float GetAxisH = 0f;
	bool accelInput;



	VehicleHorn hornComponent;
	CameraManager camManager;

	IEnumerator Start ()    
	{
 
		if (autoSwitch) {

			#if UNITY_EDITOR || UNITY_WEBGL
			controllType = InputType.Keyboard;
			GetComponent<PauseMen>().mobileControlls.SetActive (false);
			#else
			controllType = InputType.Mobile;
			#endif
		}

		hornComponent = GetComponent < VehicleHorn > ();

		camManager = GetComponent<CameraManager> ();

		if (PlayerPrefs.GetInt ("ControlType") == 0) {
			sWheel.SetActive (true);
			arrowKeys.SetActive (false);
			sWheelControl = true;
		}
		if (PlayerPrefs.GetInt ("ControlType") == 1) {
			sWheel.SetActive (false);
			arrowKeys.SetActive (true);
		}
		if (PlayerPrefs.GetInt ("ControlType") == 3) {
			sWheel.SetActive (false);
			arrowKeys.SetActive (false);
			accelInput = true;
		}

		yield return new WaitForEndOfFrame ();

		controller = GameObject.FindObjectOfType<VehicleController2017> ();

	}

	void Update () 
	{

		if (!controller)
			return;
		
		if (accelInput) 
		{
			if(Input.acceleration.x > 0.2f || Input.acceleration.x <-0.2f)
				steerInput = Input.acceleration.x;
		}

		if (sWheelControl)
			steerInput = steeringWheel.GetClampedValue ();
		

		if (controllType == InputType.Keyboard) 
		{

			if (Input.GetAxis ("Vertical") > 0) {
				if (reversing)
					motorInput = -1f;
				else 
					motorInput = 1f;
			}
			else 
				motorInput = 0;

			if(controllType == InputType.Keyboard)
				steerInput = Input.GetAxis ("Horizontal");

			if (Input.GetKey (KeyCode.Space) || Input.GetAxis("Vertical") < 0)
				handBrake = true;
			else
				handBrake = false;
			


			if (Input.GetKeyDown (KeyCode.R)) {

				reversing = !reversing;

				if (reverseImage) 
				{
					if (reversing)
						reverseImage.sprite = reverseOnSprite;
					else
						reverseImage.sprite = reverseOffSprite;
				}

			}

			if (Input.GetKey (KeyCode.H))
				hornComponent.HornOn ();

			if (Input.GetKeyUp (KeyCode.H)  || Input.GetKeyUp(KeyCode.Space))
				hornComponent.HornOff ();

			if (Input.GetKeyDown (KeyCode.C))
				camManager.NextCam ();



		}
		controller.Move (motorInput, steerInput, handBrake);

	}

	public void Throttle()
	{

		if (!reversing)
			motorInput = 1f;
		else
			motorInput = -1f;
		
	}

	public void ThrottleRelease()
	{
		if (controllType == InputType.Mobile) 
			motorInput = 0;

	}

	public void Steer(bool state)
	{

		if (state)
			steerInput = 1f;
		else
			steerInput = -1f;
		
	}

	public void SteerRelease()
	{
		if (controllType == InputType.Mobile) 
			steerInput = 0;

	}

	public void Brake(bool state)
	{

		if (state)
			handBrake = true;
		else
			handBrake = false;
		
	}

	public void ToggleReversing()
	{
		
		reversing = !reversing;

		if (reversing)
			reverseImage.sprite = reverseOnSprite;
		else
			reverseImage.sprite = reverseOffSprite;
		
	}

}
