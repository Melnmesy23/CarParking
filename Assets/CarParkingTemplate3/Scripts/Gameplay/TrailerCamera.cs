//--------------------------------------------------------------
//
//                    Car Parking Template 3.0
//        
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class TrailerCamera : MonoBehaviour {

	// Accessing to the camera manager that is attached to Canvas gameObject
	CameraManager manager;

	// Which camera must activated for trailer ( Top view camera)
	public int cameraIndex;

	// We want to destroy help arrow and activate checkpoints game object
	public GameObject helpArrow,checkPoints;

	void Start () 
	{
		
		checkPoints.SetActive (false);

		// Find the camera manager component
		manager = GameObject.FindObjectOfType<CameraManager> ();

	}

	void OnTriggerEnter(Collider col)
	{

		if (col.CompareTag ("Player")) {

			manager.ActivateCam (cameraIndex);
			manager.canChangeCamera = false;

			checkPoints.SetActive (true);

			// man.NextCheckpoint ();

			Destroy (helpArrow);

		}
	}

	void OnTriggerExit(Collider col)
	{

		if (col.CompareTag ("Player")) {
			manager.ActivateCam (0);
			manager.canChangeCamera = true;

		}
		
	}
}
