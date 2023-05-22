//--------------------------------------------------------------
//
//                    Car Parking Template 3.0
//        
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

// This script used for face the flare to camera
using UnityEngine;
using System.Collections;    

public class FlareLookAt : MonoBehaviour
{

	// Use this for initialization

	bool canCompute;

	void OnBecameVisible ()
	{
		canCompute = true;
	}

	Transform cam;

	public float updateInterval = 0.3f;

	public bool Raycast = true;


	void Start ()
	{
		cam = Camera.main.transform;

		if(Raycast)
			StartCoroutine (RayCast ());
		
		renderM = GetComponent<MeshRenderer> ();



	}

	void Update ()
	{
		if (canCompute) {
			transform.LookAt (cam.position);
		}
	}

	void OnBecameInVisible ()
	{
		canCompute = false;
	}


	MeshRenderer renderM;
	IEnumerator RayCast()
	{
		while (true) {
			yield return new WaitForSeconds (updateInterval);


			if (Physics.Linecast (transform.position, cam.transform.position))
				renderM.enabled = false;
			else
				renderM.enabled = true;




		}
	}
}
