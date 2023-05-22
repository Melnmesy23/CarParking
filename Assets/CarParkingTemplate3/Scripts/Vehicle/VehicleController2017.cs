//--------------------------------------------------------------
//
//                    Car Parking Template 3.0
//        
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

using UnityEngine;
using System.Collections;

public enum InputType
{
	Keyboard,
	Mobile
}

public class VehicleController2017 : MonoBehaviour {

	public bool canControll;

	[Header("Wheels")]
	public WheelCollider[] Wheel_Colliders;

	public Transform[] Wheel_Transforms;


	public Transform steeringWheel;

	// public Transform centerOfMass;


	float currentSpeed;
	[Header("Vehicle Setup")]
	public float enginePower = 1400f ;
	public float brakePower = 1400f;
	public float[] gearsPower;
	public Vector3 COM;
	public float maxSteer = 43f;
	public float maxSpeed = 74f;

	// Input values
	float throttleInput;
	float steerInput;
	// Also used in SmoothFollow component
	[HideInInspector]public bool handBrake;

	// Used for detecting reverse mode (if localVel.z <0 => reversing, if localVel.z>0 => is not reversing)    
	Vector3 velocity;
	Vector3 localVel;
	[HideInInspector]public bool reversing;

	// Catch rigidbody
	Rigidbody rigid;

	// Gear values to control engine sound based on gears    
	public int numberOfGears = 10;
	int currentGear ;
	float GearFactor;
	[HideInInspector]public float Revs;

	public float GearShiftDelay = 0.3f;
	VehicleAudio2017 audioCar;

	[Header("Lights")]
	// Vehicle lights
	public Light[] brakeLights;
	public Light[] reverseLights;
	public Material lightMaterial;



	void Start()
	{

		StartCoroutine (GearChanging ());

		// I see this in unity car sample script, i don't khow what is do this
		Wheel_Colliders [0].attachedRigidbody.centerOfMass = new Vector3(0,0,0);

		rigid = GetComponent<Rigidbody> ();

		// used to smoothing smooth follow camera movement behind vehicle
		rigid.interpolation = RigidbodyInterpolation.Interpolate;

		// Set center of mass to center of mass transform localposition
		rigid.centerOfMass =  COM;

		audioCar = GetComponent<VehicleAudio2017> ();

	}

	void Update () 
	{
		VehicleEngine ();

		// Update current speed and multiply to 3 for better understand
		currentSpeed = rigid.velocity.magnitude * 2.23693629f;

		// Find vehicle reversing state
		velocity = rigid.velocity;
		localVel = transform.InverseTransformDirection(velocity);

		if (localVel.z < 0)
			reversing = true;
		else
			reversing = false;

		// Align wheel mesh across wheel collider rotation and position
		for (int i = 0; i < Wheel_Colliders.Length; i++) 
		{
			Quaternion quat;
			Vector3 position;
			Wheel_Colliders [i].GetWorldPose (out position, out quat);
			Wheel_Transforms [i].transform.position = position;
			Wheel_Transforms [i].transform.rotation = quat;
		}

		if (steeringWheel)
			steeringWheel.rotation = 
				transform.rotation * Quaternion.Euler (34f,   0,(Wheel_Colliders[0].steerAngle ) *-1f );

	}

	public void VehicleEngine()
	{
		CalculateRevs ();

		if (canControll) 
		{
			if (currentSpeed >= maxSpeed)
				rigid.drag = 0.3f;
			else
				rigid.drag = 0.1f;
			
			Wheel_Colliders [2].motorTorque = enginePower*throttleInput*gearsPower[currentGear];
			Wheel_Colliders [3].motorTorque = enginePower*throttleInput*gearsPower[currentGear];

			Wheel_Colliders [2].motorTorque = Mathf.Clamp (Wheel_Colliders [2].motorTorque, -enginePower/2, enginePower);
			Wheel_Colliders [3].motorTorque = Mathf.Clamp (Wheel_Colliders [3].motorTorque, -enginePower/2, enginePower);

			Wheel_Colliders [0].steerAngle = maxSteer * steerInput;
			Wheel_Colliders [1].steerAngle = maxSteer * steerInput;

			Wheel_Colliders [1].steerAngle = Mathf.Clamp (Wheel_Colliders [1].steerAngle, - (maxSteer/(currentSpeed/10)), (maxSteer/(currentSpeed/10)));
			Wheel_Colliders [0].steerAngle = Mathf.Clamp (Wheel_Colliders [0].steerAngle, - (maxSteer/(currentSpeed/10)), (maxSteer/(currentSpeed/10)));

			if (handBrake)
			{ // Hand brake state

				Wheel_Colliders [2].brakeTorque = brakePower;
				Wheel_Colliders [3].brakeTorque = brakePower;

				LightIntensity (0, 1f);
				lightMaterial.SetFloat ("_Intensity", 0.1f);
				LightIntensity (1, 0);

				//Debug.Log ("1");
			} 
			else 
			{
				// Speed decreasing when motor input value is  0
				if (throttleInput <= 0.07  && throttleInput >= -0.07f) 
				{//Debug.Log ("2");
					Wheel_Colliders [2].brakeTorque = brakePower / 5;
					Wheel_Colliders [3].brakeTorque = brakePower / 5;
					Wheel_Colliders [0].brakeTorque = brakePower / 5;
					Wheel_Colliders [1].brakeTorque = brakePower / 5;
					LightIntensity (0, 0);
					lightMaterial.SetFloat ("_Intensity", 0);
					LightIntensity (1, 0);
				} 
				// Brake in forward moving
				else if (throttleInput < 0 && !reversing) 
				{//Debug.Log ("3");
					Wheel_Colliders [0].brakeTorque = brakePower * Mathf.Abs (throttleInput);
					Wheel_Colliders [1].brakeTorque = brakePower * Mathf.Abs (throttleInput);
					Wheel_Colliders [2].brakeTorque = brakePower * Mathf.Abs (throttleInput / 2);
					Wheel_Colliders [3].brakeTorque = brakePower * Mathf.Abs (throttleInput / 2);
					LightIntensity (0, 1f);
					lightMaterial.SetFloat ("_Intensity", 0.1f);
					LightIntensity (1, 0);
				} 
				// Brake in backward moving
				else if (throttleInput > 0 && reversing) 
				{//Debug.Log ("4");
					Wheel_Colliders [0].brakeTorque = brakePower * Mathf.Abs (throttleInput);
					Wheel_Colliders [1].brakeTorque = brakePower * Mathf.Abs (throttleInput);
					Wheel_Colliders [2].brakeTorque = brakePower * Mathf.Abs (throttleInput / 2);
					Wheel_Colliders [3].brakeTorque = brakePower * Mathf.Abs (throttleInput / 2);
					LightIntensity (0, 1f);
					lightMaterial.SetFloat ("_Intensity", 0.1f);
					LightIntensity (1, 0);
				} 
				//  Release brake ( is now driving)    
				else {//Debug.Log ("5");
					Wheel_Colliders [2].brakeTorque = 0;
					Wheel_Colliders [3].brakeTorque = 0;
					Wheel_Colliders [0].brakeTorque = 0;
					Wheel_Colliders [1].brakeTorque = 0;
					LightIntensity (0, 0);
					lightMaterial.SetFloat ("_Intensity", 0);
					LightIntensity (1, 0);
				}

			}
			if (reversing && throttleInput < 0) {

				LightIntensity (0, 0);
				lightMaterial.SetFloat ("_Intensity", 0);
				LightIntensity (1, 1f);
			}
		}
	}

	bool isMobile;

	public void Move(float motor,float steer,bool hand)
	{
			throttleInput = motor;
			steerInput = steer;
			handBrake = hand;
	}

	void LightIntensity(int type,float value)
	{
		if (type == 0) {
			for (int a = 0; a < brakeLights.Length; a++)
				brakeLights [a].intensity = value;
		} else {
			for (int a = 0; a < reverseLights.Length; a++)
				reverseLights [a].intensity = value;
		}
	}


	// Engine sound system calculation
	// Gear changing only used for sound system      

	IEnumerator GearChanging ()
	{
		while (true) 
		{
			yield return new WaitForSeconds (0.01f);
			if (!reversing) {
				float f = Mathf.Abs (currentSpeed / nextGearSpeed);
				float upgearlimit = (1 / (float)numberOfGears) * (currentGear + 1);
				float downgearlimit = (1 / (float)numberOfGears) * currentGear;

				// Changinbg gear down
				if (currentGear > 0 && f < downgearlimit) {
					// Reduce engine audio volume when changing gear
					audioCar.audioSource.volume = 0.7f;
					//audioCar.ChangeGear ();
					// Delay time for changing gear down
					yield return new WaitForSeconds (0);
					audioCar.audioSource.volume = 1f;


					currentGear--;
				}

				// Changing gear Up
				if (f > upgearlimit && (currentGear < (numberOfGears - 1))) {
					// Reduce engine audio volume when changing gear
					audioCar.audioSource.volume = 0.3f;
					//audioCar.ChangeGear ();
					// Delay before changing gear up
					yield return new WaitForSeconds (GearShiftDelay);
					audioCar.audioSource.volume = 1f;
					currentGear++;
				}
			} else {

				if (reversing)
					currentGear = 0;
			}
		}
	}

	// simple function to add a curved bias towards 1 for a value in the 0-1 range
	private static float CurveFactor (float factor)
	{
		return 1 - (1 - factor) * (1 - factor);
	}

	// unclamped version of Lerp, to allow value to exceed the from-to range
	private static float ULerp (float from, float to, float value)
	{
		return (1.0f - value) * from + value * to;
	}
	public float nextGearSpeed = 300f;
	// Used for engine sound system    
	private void CalculateGearFactor ()
	{
		float f = (1 / (float)numberOfGears);
		// gear factor is a normalised representation of the current speed within the current gear's range of speeds.
		// We smooth towards the 'target' gear factor, so that revs don't instantly snap up or down when changing gear.
		var targetGearFactor = Mathf.InverseLerp (f * currentGear, f * (currentGear + 1), Mathf.Abs (currentSpeed / nextGearSpeed));
		GearFactor = Mathf.Lerp (GearFactor, targetGearFactor, Time.deltaTime * 5f);
	}   

	// Used for engine sound system
	private void CalculateRevs ()
	{
		// calculate engine revs (for display / sound)
		// (this is done in retrospect - revs are not used in force/power calculations)
		CalculateGearFactor ();
		var gearNumFactor = currentGear / (float)numberOfGears;
		var revsRangeMin = ULerp (0f, 1f, CurveFactor (gearNumFactor));
		var revsRangeMax = ULerp (1f, 1f, gearNumFactor);
		Revs = ULerp (revsRangeMin, revsRangeMax, GearFactor);
	}

}




