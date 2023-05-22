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

public enum ItemType
{

	Ring,Roof,Spoiler

}

public class T_Shop : MonoBehaviour {

	public GameObject shopWindow;

	[HideInInspector]public int carID,itemID;

	[HideInInspector]public ItemType itemType;

	public AudioSource boxSound;

	[Header("Rings")]
	public int[] ringPrice;
	public GameObject[] ringLocks;
	public Text[] ringPriceTexts;

	[Header("Roof")]
	public int[] roofPrice;
	public GameObject[] roofLocks;
	public Text[] roofPriceTexts;

	[Header("Spoiler")]
	public int[] spoilerPrice;
	public GameObject[] spoilerLocks;
	public Text[] spoilerPriceTexts;


	T_Money tMoney;

	void Awake()
	{
		
		tMoney = GameObject.FindObjectOfType<T_Money> ();

	}

	public void ShowWindow(bool state)
	{
		shopWindow.SetActive (state);

	}

	public void BuyItem()
	{

		if (itemType == ItemType.Ring) {
			// Check player money is more than ring price
			if (tMoney.GetMoney () >= ringPrice [itemID]) {

				// Reduce current ring price from player total money
				tMoney.ChangeMoney (- ringPrice [itemID]);

				// Open current ring
				PlayerPrefs.SetInt (carID.ToString () + "Ring" + itemID.ToString (), 3);// 3=>true , 0=>false

				PlayerPrefs.SetInt (carID.ToString () + "RingID", itemID);

				//Deactivate current lock icon
				ringLocks [itemID].SetActive (false);

				// play item buy sound clip
				tMoney.PlayAudio (0);

				boxSound.Play ();

			} else {
				// play item buy error sound clip (becouse money is not enough
				tMoney.PlayAudio (1);

				// Display shop offer window
				tMoney.showOfferWindow.SetActive (true);
			}

		}


		if (itemType == ItemType.Roof) {
			// Check player money is more than Roof price
			if (tMoney.GetMoney () >= roofPrice [itemID]) {

				// Reduce current Roof price from player total money
				tMoney.ChangeMoney (- roofPrice [itemID]);

				// Open current Roof
				PlayerPrefs.SetInt (carID.ToString () + "Roof" + itemID.ToString (), 3);// 3=>true , 0=>false

				PlayerPrefs.SetInt (carID.ToString () + "RoofID", itemID);

				//Deactivate current lock icon
				roofLocks [itemID].SetActive (false);

				// play item buy sound clip
				tMoney.PlayAudio (0);

				boxSound.Play ();

			} else {
				// play item buy error sound clip (becouse money is not enough
				tMoney.PlayAudio (1);

				// Display shop offer window
				tMoney.showOfferWindow.SetActive (true);
			}

		}

		if (itemType == ItemType.Spoiler) {
			// Check player money is more than spoiler price
			if (tMoney.GetMoney () >= spoilerPrice [itemID]) {

				// Reduce current spoiler price from player total money
				tMoney.ChangeMoney (- spoilerPrice [itemID]);

				// Open current spoiler
				PlayerPrefs.SetInt (carID.ToString () + "Spoiler" + itemID.ToString (), 3);// 3=>true , 0=>false

				PlayerPrefs.SetInt (carID.ToString () + "SpoilerID", itemID);

				//Deactivate current lock icon
				spoilerLocks [itemID].SetActive (false);

				// play item buy sound clip
				tMoney.PlayAudio (0);

				boxSound.Play ();

			} else {
				// play item buy error sound clip (becouse money is not enough
				tMoney.PlayAudio (1);

				// Display shop offer window
				tMoney.showOfferWindow.SetActive (true);
			}

		}

		shopWindow.SetActive (false);

	}

}
