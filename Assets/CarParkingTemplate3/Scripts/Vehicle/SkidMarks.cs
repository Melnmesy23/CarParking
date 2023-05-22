//--------------------------------------------------------------
//--------------------------------------------------------------
//
//                    Car Parking Template 3.0
//        
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class SkidMarks : MonoBehaviour {

	// For detect ehen wheel collid with ground
		public WheelCollider CorrespondingCollider ;

	// Skidmark prefab fro instantiating
		public GameObject skidMarkPrefab ;

	// Min and max slip value for instantiating skidmark
		public float onSlip = 0.07f,offSlip = 0.01f;

	public AudioSource skidSound;

	// Use this for Log wheel slip valuew
	public bool debug;

		void Update () 
		{
		try
		{
				// now cast a ray out from the wheel collider's center the distance of the suspension, if it hit something, then use the "hit"
				// variable's data to find where the wheel hit, if it didn't, then se tthe wheel to be fully extended along the suspension.
			/*	if ( Physics.Raycast( ColliderCenterPoint, -CorrespondingCollider.transform.up,out hit, CorrespondingCollider.suspensionDistance + CorrespondingCollider.radius ) ) {
						transform.position = hit.point + (CorrespondingCollider.transform.up * CorrespondingCollider.radius);
				}else{
						transform.position = ColliderCenterPoint - (CorrespondingCollider.transform.up * CorrespondingCollider.suspensionDistance);
				}*/

				// define a wheelhit object, this stores all of the data from the wheel collider and will allow us to determine
				// the slip of the tire.
				WheelHit CorrespondingGroundHit;
				CorrespondingCollider.GetGroundHit(out CorrespondingGroundHit );

				// if the slip of the tire is greater than 2.0, and the slip prefab exists, create an instance of it on the ground at
				// a zero rotation.
		if(debug)
		Debug.Log(CorrespondingGroundHit.sidewaysSlip .ToString());
		
		if (Mathf.Abs (CorrespondingGroundHit.sidewaysSlip) > onSlip) {
			
			if (!skiding)
				{
					if(!skidSound.isPlaying)
						skidSound.Play();
					
					skid = (GameObject)Instantiate (skidMarkPrefab, transform.position, transform.rotation);
					skid.name = "skid";
					skid.transform.parent = gameObject.transform;

				if (CorrespondingGroundHit.collider.tag == "Road") {
					if (roadFX) {
						road = (GameObject)Instantiate (roadFX, transform.position, transform.rotation);
						road.transform.parent = gameObject.transform;
					}
				}

				skiding = true;    
			} else {
				
					skid.transform.parent = null;
					skid.transform.position = transform.position;


				if (road) {
					road.transform.parent = null;
					road.transform.position = transform.position;

				}
			}
		} else if (Mathf.Abs (CorrespondingGroundHit.sidewaysSlip) <= offSlip) {
			if (skiding) {
				skiding = false;

			}
				if(skidSound.isPlaying)
					skidSound.Stop();		
		}
		}
		catch{}
	}
	// Internal usage
	bool skiding;
	GameObject skid,road;

	public GameObject roadFX;
}
