//--------------------------------------------------------------
//
//                    Car Parking Template 3.0
//        
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class Trailer : MonoBehaviour {

	public WheelCollider[] Wheel_Colliders;
	public Transform[] Wheel_Transforms;

	Rigidbody rigid;

	public Vector3 centerOfMass;

	public bool isActive;


	void Start()
	{

		Wheel_Colliders [0].attachedRigidbody.centerOfMass = centerOfMass;

		rigid = GetComponent<Rigidbody> ();

		rigid.interpolation = RigidbodyInterpolation.Interpolate;
	}

	void Update () 
	{

		for (int i = 0; i < Wheel_Colliders.Length; i++) {
			Quaternion quat;
			Vector3 position;
			Wheel_Colliders [i].GetWorldPose (out position, out quat);
			Wheel_Transforms [i].transform.position = position;
			Wheel_Transforms [i].transform.rotation = quat;

		}

		if (isActive) {

			for (int b = 0; b < Wheel_Colliders.Length; b++) {

				if (Wheel_Colliders [b].isGrounded)
					Wheel_Colliders [b].motorTorque = 0.5f;
				else
					Wheel_Colliders [b].motorTorque = 0;
			}
		}
	}

	public void SetActive(bool state)
	{

		isActive = state;

		GetComponent<FlashLight> ().isActive = state;

		GetComponent<ConfigurableJoint> ().enableCollision = state;

	}
}
