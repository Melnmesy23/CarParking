//--------------------------------------------------------------
//
//                    Car Parking Template 3.0
//        
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

// This script used for night flare system
using UnityEngine;
using System.Collections;

public enum FlareType
{
	Negative,
	Positive
}

public class SimpleFlare : MonoBehaviour
{

	[Header("Simple Flare System")]
	[Space(3)]
	// Flare type
	public 	FlareType flareType = FlareType.Negative;

	// Flare size multiplier + fade start distance
	public float multiplier  = 3f, FadeDist = 100f;

	// Internal usage
	 bool canCompute, canFade;
	 float Dist;
	 Transform cam;
	GameObject target;
	 Vector3 temp;
	 bool positive;

	void Start ()
	{
		if (!target)
			target = gameObject;
		
		if(target)
			temp = target.transform.localScale;

		if(!cam)
			cam = Camera.main.transform;

		if (flareType == FlareType.Negative)
			positive = false;
		else
			positive = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!target)
			return;


		// thistance from target(mainly camera)
		Dist = Vector3.Distance (transform.position, cam.position);


		// Start fading based on user defined distance
		if (Dist <= FadeDist)
			canFade = true;
		else
			canFade = false;

		// Can compute for optimization
		if (canCompute)
			target.transform.LookAt (cam.position);

		// Fade flare based on distance from camera
		if (canFade) 
		{
			if (positive) 
				target.transform.localScale = new Vector3 (temp.x * Dist / 100 * multiplier, temp.y,temp.z);
			 else 
				target.transform.localScale = new Vector3 (temp.x + Dist / 100 * multiplier, temp.y,temp.z);

			Debug.Log (target.transform.localScale.ToString ());
		}
	}


	// For optimization
	void OnBecameVisible()
	{
		canCompute = true;

	}

	void OnBecameInvisible()
	{
		canCompute = false;
	}
}
