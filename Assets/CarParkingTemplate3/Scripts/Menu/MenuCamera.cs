//--------------------------------------------------------------
//
//                    Car Parking Template 3.0
//        
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// Deactivate vehicle cameras in garage scene
public class MenuCamera : MonoBehaviour {


	void Start () {
		if (SceneManager.GetActiveScene ().name.Contains ("Garage"))
			gameObject.SetActive (false);
	}

}
