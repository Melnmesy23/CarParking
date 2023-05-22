//--------------------------------------------------------------
//
//                    Car Parking Template 3.0
//        
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class VehicleHorn : MonoBehaviour 
{

	AudioSource hornSource;
	public AudioClip horn;

	IEnumerator Start()
	{
		
		yield return new WaitForEndOfFrame ();

		hornSource = GameObject.Find ("HornSource").GetComponent<AudioSource> ();

	}

	public void HornOn()
	{
		if (!hornSource.isPlaying)
			hornSource.Play ();
	}

	public void HornOff()
	{
		if (hornSource.isPlaying)
			hornSource.Stop ();
	}
}
