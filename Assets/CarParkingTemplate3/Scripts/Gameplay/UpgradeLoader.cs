//--------------------------------------------------------------
//
//                    Car Parking Template 3.0
//        
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

// This script used for load vehicle upgrades

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UpgradeLoader : MonoBehaviour {

	// Upgrade level list
	public float[] enginePower,maxSpeed,brakeUpgrade;


	VehicleController2017 car;

	void Start () {
	
		if (SceneManager.GetActiveScene ().name.Contains ("Garage") ||
		   SceneManager.GetActiveScene ().name.Contains ("Menu"))
			return;
		
		car = GetComponent<VehicleController2017> ();

		// Set car motor power based on upgrade value on upgrade menu
		car.enginePower = enginePower[PlayerPrefs.GetInt("Engine"+PlayerPrefs.GetInt("CarID").ToString())];
		car.maxSpeed = maxSpeed[PlayerPrefs.GetInt("Speed"+PlayerPrefs.GetInt("CarID").ToString())];
		car.brakePower = brakeUpgrade[PlayerPrefs.GetInt("Brake"+PlayerPrefs.GetInt("CarID").ToString())];
	}

}
