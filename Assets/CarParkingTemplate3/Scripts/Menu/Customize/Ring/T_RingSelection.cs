//--------------------------------------------------------------
//
//                    Car Parking kit 2.0
//        
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

// Atach this script to ring selection menu and call SelectRing(int id) function on each ring button

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class T_RingSelection : MonoBehaviour {

	// To acces current car rings class
	[HideInInspector]public T_Rings rings;

	 T_Shop tShop;

	void Start()
	{

		tShop = GameObject.FindObjectOfType<T_Shop> ();

		for (int a = 0; a < tShop.ringPriceTexts .Length; a++)
			tShop.ringPriceTexts [a].text = tShop.ringPrice [a].ToString ();
		
		// update locks on start
		UpdateLocks();

	}


	// public function to use in ring button OnClick() in his inspector         
	public void SelectRing(int id)
	{
		if (PlayerPrefs.GetInt (rings.carID.ToString() + "Ring" + id.ToString ()) == 3) {  // 3=>true , 0=>false

			// Find current car T_Rings component
			rings = GameObject.FindObjectOfType<T_Rings> ();

			// We have 6 rings, and first de activate all rings
			rings.SetRing (0, false);
			rings.SetRing (1, false);
			rings.SetRing (2, false);
			rings.SetRing (3, false);
			rings.SetRing (4, false);
			rings.SetRing (5, false);

			// And then activate current selected ring:
			rings.SetRing (id, true);
			PlayerPrefs.SetInt (rings.carID.ToString() + "RingID", id);

			tShop.ShowWindow (false);

		} else {// The current selected ring is not unlocked, We unlock it with reducing money from player total moneys and unlock ring

			// Find current car T_Rings component
			rings = GameObject.FindObjectOfType<T_Rings> ();

			// We have 6 rings, and first de activate all rings
			rings.SetRing (0, false);
			rings.SetRing (1, false);
			rings.SetRing (2, false);
			rings.SetRing (3, false);
			rings.SetRing (4, false);
			rings.SetRing (5, false);

			// And then activate current selected ring:
			rings.SetRing (id, true);


			tShop.carID = rings.carID;
			tShop.itemID = id;
//			tShop.currentItemPrice.text = tShop.ringPrice[id].ToString();
			tShop.itemType = ItemType.Ring;
			tShop.ShowWindow (true);
		}
	}



	// public function to use in car selection ui manu
	public void UpdateLocks()
	{
		rings = GameObject.FindObjectOfType<T_Rings> ();

		for (int a = 0; a < tShop.ringPrice.Length; a++) 
		{

			tShop.ringLocks [a].SetActive (true);

			if (PlayerPrefs.GetInt (rings.carID.ToString() + "Ring" + a.ToString ()) == 3) {

				// Deactivate pre unlocked rings icon
				tShop.ringLocks [a].SetActive (false);
			}
		}
	}
}
