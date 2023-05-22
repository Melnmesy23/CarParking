//--------------------------------------------------------------
//
//                    Car Parking Template 3.0
//        
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

// Attach this script to any car and drage his Spoilers

using UnityEngine;
using System.Collections;

public class T_Spoiler : MonoBehaviour {

	public int carID;

	public GameObject[] Spoilers;

	void Start()
	{
		SetSpoiler (PlayerPrefs.GetInt (carID.ToString()+"SpoilerID"), true);
	}

	public void SetSpoiler(int id,bool state)
	{

		// We have 6 spoilers, and first de activate all spoilers
		for (int a = 0; a < Spoilers.Length; a++)
			Spoilers[a].SetActive (false);


		if (Spoilers[id])
			Spoilers[id].SetActive (state);




	}
}
