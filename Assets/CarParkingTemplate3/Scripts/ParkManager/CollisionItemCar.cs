//--------------------------------------------------------------
//
//                    Car Parking Template 3.0
//        
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

// This script used for detect player collided with parked cars and activate alarm sound in parked car

using UnityEngine;
using System.Collections;

public class CollisionItemCar : MonoBehaviour
{
	//Accessing to TriggerManager.cs
	[HideInInspector]public ParkingManager triggerManager;

	//This is for internal usage
	bool CanCollid;

	//Car alarm lights;
	public Light[] AlarmLights;

	// Wait beform each alarm
	public float AlarmDelay  = 1f ;


	void Start ()
	{
		//Find TriggerManager by tag
		triggerManager = GameObject.FindGameObjectWithTag ("Manager").GetComponent<ParkingManager> ();

	}
	//When car is colide with parking items
	void OnCollisionEnter (Collision col)
	{
		if (!CanCollid) {
			if (col.gameObject.tag == "Player") {
				
				//Increase TriggerManager Collision Counts
				triggerManager.CollisionCount++;

				PlayerPrefs.SetInt ("TotalCollisions", PlayerPrefs.GetInt ("TotalCollisions") + 1);

				//Play collision Alarm sound
				triggerManager.AlarmSound.Play();

				// Start car alarming
				StartCoroutine (CarAlarm ());

				// Play car alarm sound
				GetComponent<AudioSource> ().Play ();

				//Internal usage--------------------
				CanCollid = true;
				StartCoroutine (CanCollids ());
				//---------------------

				//Update collision count text
				triggerManager.CollistionCountText.text = triggerManager.CollisionCount.ToString ();

				//If collision counts is more than 3,Stop game and show Failed menu Object
				if (triggerManager.CollisionCount > 3) {
					triggerManager.FailedMenu.SetActive (true);
					triggerManager.Controller.SetActive (false);
					GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody> ().isKinematic = true;

					PlayerPrefs.SetInt ("TotalFailed", PlayerPrefs.GetInt ("TotalFailed") + 1);

					//Destroy TriggerManager
					Destroy (triggerManager);
				}
			}
		}
	}

	//Internal Usage....
	IEnumerator CanCollids ()
	{


		yield return new WaitForSeconds (3f);
		CanCollid = false;
	}

	// Car alarm system
	IEnumerator CarAlarm()
	{

		while (true) {
			
			for (int a = 0; a < AlarmLights.Length; a++)
				AlarmLights [a].enabled = !AlarmLights [a].enabled;

			yield return new WaitForSeconds (AlarmDelay);
		}


	}
}
