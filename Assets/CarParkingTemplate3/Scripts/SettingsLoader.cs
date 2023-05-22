//--------------------------------------------------------------
//
//                    Car Parking Template 3.0
//        
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

// This script used for load game settings
using UnityEngine;
using System.Collections;

public class SettingsLoader : MonoBehaviour {


	public AudioSource AmbiantSound;

	[Header("You need to edit script for Amplify Color support")]
	[Space(3)]
	public Camera mainCamera;

	void Start () {
		if (PlayerPrefs.GetInt ("AmbientSound") == 3)
			AmbiantSound.Play ();
		else
			AmbiantSound.Stop ();

		// Amplify color integeration

		if (!mainCamera)
			mainCamera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera>();
		
		/*if (PlayerPrefs.GetInt ("amplifyColor") != 3)
			mainCamera.GetComponent<AmplifyColorEffect> ().enabled = false;
		else
			mainCamera.GetComponent<AmplifyColorEffect> ().enabled = true;*/
	
		if (PlayerPrefs.GetInt ("Shaft") != 3)
			mainCamera.GetComponent<LightingBox.ImageEffects.SunShafts> ().enabled = false;
		else
			mainCamera.GetComponent<LightingBox.ImageEffects.SunShafts> ().enabled = true;

		if (PlayerPrefs.GetInt ("amplifyColor") != 3)
			mainCamera.GetComponent<LightingBox.ImageEffects.BloomOptimized> ().enabled = false;
		else
			mainCamera.GetComponent<LightingBox.ImageEffects.BloomOptimized> ().enabled = true;
	}
}
