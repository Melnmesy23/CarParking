//--------------------------------------------------------------
//
//                    Car Parking Template 3.0
//        
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

// Atach this script to Roof selection menu and call SelectRoof(int id) function on each Roof button

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class T_RoofSelection : MonoBehaviour {

	// To acces current car Roofs class
	[HideInInspector]public T_Roof roofs;

	 T_Shop tShop;

	void Start()
	{

		tShop = GameObject.FindObjectOfType<T_Shop> ();


		for (int a = 0; a < tShop.roofPriceTexts.Length; a++)
			tShop.roofPriceTexts [a].text = tShop.roofPrice [a].ToString ();
		
		// update locks on start
		UpdateLocks();

	}


	// public function to use in Roof button OnClick() in his inspector         
	public void SelectRoof(int id)
	{
		if (PlayerPrefs.GetInt (roofs.carID.ToString() + "Roof" + id.ToString ()) == 3) {  // 3=>true , 0=>false

			// Find current car T_Roof component
			roofs = GameObject.FindObjectOfType<T_Roof> ();

			// And then activate current selected Roof:
			roofs.SetRoof (id, true);

			PlayerPrefs.SetInt (roofs.carID.ToString() + "RoofID", id);

			tShop.ShowWindow (false);

		} else {// The current selected Roof is not unlocked, We unlock it with reducing money from player total moneys and unlock mirror


			// Find current car T_Roof component
			roofs = GameObject.FindObjectOfType<T_Roof> ();

			// And then activate current selected Roof:
			roofs.SetRoof (id, true);

			tShop.carID = roofs.carID;
			tShop.itemID = id;
			//			tShop.currentItemPrice.text = tShop.roofPrice[id].ToString();
			tShop.itemType = ItemType.Roof;
			tShop.ShowWindow (true);
		}
	}



	// public function to use in car selection ui manu
	public void UpdateLocks()
	{
		roofs = GameObject.FindObjectOfType<T_Roof> ();

		for (int a = 0; a < tShop.roofPrice.Length; a++) 
		{

			tShop.roofLocks [a].SetActive (true);

			if (PlayerPrefs.GetInt (roofs.carID.ToString() + "Roof" + a.ToString ()) == 3) {

				// Deactivate pre unlocked Roofs icon
				tShop.roofLocks [a].SetActive (false);
			}
		}
	}
}
