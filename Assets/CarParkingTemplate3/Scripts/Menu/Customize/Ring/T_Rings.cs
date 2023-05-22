//--------------------------------------------------------------
//
//                    Car Parking Template 3.0
//        
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

// Attach this script to any car and drage his rings

using UnityEngine;
using System.Collections;

public class T_Rings : MonoBehaviour {

	public int carID;

	public GameObject[] Ring_0,Ring_1,Ring_2,Ring_3,Ring_4,Ring_5,Ring_6,Ring_7,Ring_8,Ring_9,Ring_10;


	void Start()
	{

		// We have 6 rings, and first de activate all rings
		SetRing (0, false);
		SetRing (1, false);
		SetRing (2, false);
		SetRing (3, false);
		SetRing (4, false);
		SetRing (5, false);

		SetRing (PlayerPrefs.GetInt(carID.ToString()+"RingID"), true);


	}

	public void SetRing(int id,bool state)
	{

		if (id == 0) 
		{
			if (Ring_0.Length > 0) {
				for (int a = 0; a < Ring_0.Length; a++)
					Ring_0 [a].SetActive (state);
			}
		}

		if (id == 1) 
		{
			if (Ring_1.Length > 0) {
				for (int a = 0; a < Ring_1.Length; a++)
					Ring_1 [a].SetActive (state);
			}
		}

		if (id == 2) 
		{
			if (Ring_2.Length > 0) {
				for (int a = 0; a < Ring_2.Length; a++)
					Ring_2 [a].SetActive (state);
			}
		}

		if (id == 3) 
		{
			if (Ring_3.Length > 0) {
				for (int a = 0; a < Ring_3.Length; a++)
					Ring_3 [a].SetActive (state);
			}
		}

		if (id == 4) 
		{
			if (Ring_4.Length > 0) {
				for (int a = 0; a < Ring_4.Length; a++)
					Ring_4 [a].SetActive (state);
			}
		}

		if (id == 5) 
		{
			if (Ring_5.Length > 0) {
				for (int a = 0; a < Ring_5.Length; a++)
					Ring_5 [a].SetActive (state);
			}
		}

		if (id == 6) 
		{
			if (Ring_6.Length > 0) {
				for (int a = 0; a < Ring_6.Length; a++)
					Ring_6 [a].SetActive (state);
			}
		}

		if (id == 7) 
		{
			if (Ring_7.Length > 0) {
				for (int a = 0; a < Ring_7.Length; a++)
					Ring_7 [a].SetActive (state);
			}
		}

		if (id == 8) 
		{
			if (Ring_8.Length > 0) {
				for (int a = 0; a < Ring_8.Length; a++)
					Ring_8 [a].SetActive (state);
			}
		}

		if (id == 9) 
		{
			if (Ring_9.Length > 0) {
				for (int a = 0; a < Ring_9.Length; a++)
					Ring_9 [a].SetActive (state);
			}
		}

		if (id == 10) 
		{
			if (Ring_10.Length > 0) {
				for (int a = 0; a < Ring_10.Length; a++)
					Ring_10 [a].SetActive (state);
			}
		}
			
	}
}
