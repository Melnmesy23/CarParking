//--------------------------------------------------------------
//
//                    Car Parking Template 3.0
//        
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

// Atach this script to Spoiler selection menu and call SelectSpoiler(int id) function on each Spoiler button

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class T_SpoilerSelection : MonoBehaviour {

	// To acces current car spoilers class
	[HideInInspector]public T_Spoiler spoilers;

	 T_Shop tShop;

	void Start()
	{

		tShop = GameObject.FindObjectOfType<T_Shop> ();

		for (int a = 0; a < tShop.spoilerPriceTexts.Length; a++)
			tShop.spoilerPriceTexts [a].text = tShop.spoilerPrice [a].ToString ();
		
		// update locks on start
		UpdateLocks();

	}


	// public function to use in Spoiler button OnClick() in his inspector         
	public void SelectSpoiler(int id)
	{
		if (PlayerPrefs.GetInt (spoilers.carID.ToString() + "Spoiler" + id.ToString ()) == 3) {  // 3=>true , 0=>false

			// Find current car T_Spoilers component
			spoilers = GameObject.FindObjectOfType<T_Spoiler> ();

			// And then activate current selected Spoiler:
			spoilers.SetSpoiler (id, true);

			PlayerPrefs.SetInt (spoilers.carID.ToString() + "SpoilerID",id);

			tShop.ShowWindow (false);


		} else {// The current selected Spoiler is not unlocked, We unlock it with reducing money from player total moneys and unlock Spoiler


			// Find current car T_Spoilers component
			spoilers = GameObject.FindObjectOfType<T_Spoiler> ();

			// And then activate current selected Spoiler:
			spoilers.SetSpoiler (id, true);

			tShop.carID = spoilers.carID;
			tShop.itemID = id;
		//	tShop.currentItemPrice.text = tShop.exhaustPrice [id].ToString();
			tShop.itemType = ItemType.Spoiler;
			tShop.ShowWindow (true);
		}
	}



	// public function to use in car selection ui manu
	public void UpdateLocks()
	{
		spoilers = GameObject.FindObjectOfType<T_Spoiler> ();

		for (int a = 0; a < tShop.spoilerPrice .Length; a++) 
		{

			tShop.spoilerLocks  [a].SetActive (true);

			if (PlayerPrefs.GetInt (spoilers.carID.ToString() + "Spoiler" + a.ToString ()) == 3) {

				// Deactivate pre unlocked exhausts icon
				tShop.spoilerLocks  [a].SetActive (false);
			}
		}
	}
}
