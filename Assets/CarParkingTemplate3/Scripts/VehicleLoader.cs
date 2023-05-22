//--------------------------------------------------------------
//
//                    Car Parking Template 3.0
//        
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

// This script used for load and instantiate car that selected in garage

using UnityEngine;
using System.Collections;


public class VehicleLoader : MonoBehaviour
{

	//List of the car prefabs
	public GameObject[] Vehicle;

	void Awake ()
	{
		// Instantiate car by loaded  Car ID from  selected in car garage   
		if(!GameObject.FindGameObjectWithTag("Player"))
			Instantiate (Vehicle [PlayerPrefs.GetInt ("CarID")], transform.position, transform.rotation);
	}
}
