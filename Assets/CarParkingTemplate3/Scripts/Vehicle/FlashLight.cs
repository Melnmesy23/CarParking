//--------------------------------------------------------------
//
//                    Car Parking Template 3.0
//        
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

// Flash light system (used as gps and target found helper)    
using UnityEngine;
using System.Collections;

public class FlashLight : MonoBehaviour {


	public Light [] flashLights;

	float distanceRight,distanceLeft;

	Transform tLeft,tRight,tTarget;

	public float flashTime = 0.47f;

	public bool isActive;

	IEnumerator Start ()
	{

		yield return new WaitForEndOfFrame ();

		tLeft = flashLights [0].transform;

		tRight = flashLights [1].transform;

	}
	
	public void SetTarget (Transform newTarget)
	{

		tTarget = newTarget;

	}

	void Update () 
	{
		
		if (!tTarget)
			return;

		if (isActive) {
			distanceLeft = Vector3.Distance (tLeft.position, tTarget.position);

			distanceRight = Vector3.Distance (tRight.position, tTarget.position);

			if (distanceLeft > distanceRight) {

				if (!fRight)
					StartCoroutine ("RightFlashing");

			} else if (distanceLeft < distanceRight) {

				if (!fLeft)
					StartCoroutine ("LeftFlashing");

			} else {

				StopCoroutine ("LeftFlashing");
				StopCoroutine ("RightFlashing");

				Debug.Log ("Cancel");

			}


		}
	}

	bool fRight,fLeft;

	IEnumerator RightFlashing()
	{
		StopCoroutine ("LeftFlashing");

		fLeft = false;

		fRight = true;

		flashLights [0].intensity = 0;

		while (true) {

			flashLights [1].intensity = 0;

			yield return new WaitForSeconds (flashTime);

			flashLights [1].intensity = 1f;

			yield return new WaitForSeconds (flashTime);

		}
	}

	IEnumerator LeftFlashing()
	{
		StopCoroutine ("RightFlashing");

		fLeft = true;

		fRight = false;


		flashLights [1].intensity = 0;

		while (true) {

			flashLights [0].intensity = 0;

			yield return new WaitForSeconds (flashTime);

			flashLights [0].intensity = 1f;

			yield return new WaitForSeconds (flashTime);

		}
	}
}
