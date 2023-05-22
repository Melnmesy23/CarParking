//--------------------------------------------------------------
//
//                    Car Parking Template 3.0
//        
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

// This script used for switc between cameras

using UnityEngine;
using System.Collections;

public class CameraSwitch : MonoBehaviour {

	// MainCamera
	GameObject mainCamera;

	[Header("The first slot should be empty")]
	[Header("Because is used for Main camera")]
	[Space(3)]

	[Header("Camera List :")]
	// List of the camera's gameObjects
	public GameObject[] cameras;

	// Hold curent active camera id
	int currentCamera = 0;

	void Start () 
	{
		mainCamera = GameObject.Find("Main Camera");

		cameras [0] = mainCamera;

	}
	

	// Switch to next camera based total camera counts
	public void NextCamera () {
		if (currentCamera < cameras.Length-1)
			currentCamera++;
		else
			currentCamera = 0;

		SelectCamera (currentCamera);
	}

	// Diactivate all cameras and activate current selected
	void SelectCamera(int id)
	{

		for (int a = 0; a < cameras.Length; a++)
			cameras [a].SetActive (false);
	
		cameras [id].SetActive (true); 
	}
}
