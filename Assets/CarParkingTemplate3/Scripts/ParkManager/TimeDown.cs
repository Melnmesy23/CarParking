//--------------------------------------------------------------
//
//                    Car Parking Template 3.0
//        
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------


using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TimeDown : MonoBehaviour {
	// Use this for initialization




	public Text _text;

	public float seconds = 59; // Amount of seconds 
	public float minutes = 0; //Amount of minutes Text _text;

	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (seconds <= 0) {
			seconds = 59;

			if (minutes >= 1) {
				minutes --;
			} else {
				minutes = 0;
				seconds = 0;
				_text.text  = minutes.ToString ("f0") + ":0" + seconds.ToString ("f0");
			}
		} else 
		{
			seconds -= Time.deltaTime;
			_text.text = +minutes + ":"+ Mathf.FloorToInt(seconds);
		}


		if (minutes <= 0 && seconds <= 0)
			GetComponent<ParkingManager> ().TimeFailed ();	

	}
}