//--------------------------------------------------------------
//
//                    Car Parking Template 3.0
//        
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class PhoneTime : MonoBehaviour {


	public Text timeTXT,dateTXT;

	void Update () {
		timeTXT.text = DateTime.Now.Hour.ToString () + " : " + DateTime.Now.Minute.ToString();
		dateTXT.text = DateTime.Now.Date.ToString();
	}
}
