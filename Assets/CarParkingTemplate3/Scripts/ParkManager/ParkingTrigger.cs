//--------------------------------------------------------------
//
//                    Car Parking Template 3.0
//        
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

// This script used for use in parking triggers

using UnityEngine;
using System.Collections;

public class ParkingTrigger : MonoBehaviour
{

	// Trigger number
	public int tNum;

	// ParkingManager handler
	public ParkingManager tManager;


	void OnTriggerStay (Collider col)
	{
		
		
		if (col.tag == "Player"||col.tag == "Trailer") {

			if (tNum == 1) 
				tManager.t0 = true;
			else if (tNum == 2)
				tManager.t1 = true;
			else if (tNum == 3)
				tManager.t2 = true;
			else if (tNum == 4)
				tManager.t3 = true;


		}   
		
		
		
		
	}

	void OnTriggerExit (Collider col)
	{
		
		
		if (col.tag == "Player"||col.tag == "Trailer") {
			if (tNum == 1)
				tManager.t0 = false;
			else if (tNum == 2)
				tManager.t1 = false;
			else if (tNum == 3)
				tManager.t2 = false;
			else if (tNum == 4)
				tManager.t3 = false;
			
			
			
		}
	}
}