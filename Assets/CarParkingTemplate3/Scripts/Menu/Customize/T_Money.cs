//--------------------------------------------------------------
//
//                    Car Parking Template 3.0
//        
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

// Atach this script to an empty game object. This is responsible for player money (Cois) management

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class T_Money : MonoBehaviour {


	// Money management
	public int totalMoney;
	public string totalMoneyKey;

	// Display management
	public Text totalMoneyText;

	public GameObject showOfferWindow;

	public AudioSource audioSource;
	public AudioClip buyClip,errorClip;

	void Start () 
	{
		
		audioSource = GetComponent<AudioSource> ();

		// Read total money
		totalMoney = PlayerPrefs.GetInt (totalMoneyKey);


		// Display total money   
		UpdateDisplay();
	
	}
	
	void Update () 
	{
	
		// Clear total money from player prefs
		if (Input.GetKeyDown (KeyCode.H))
			PlayerPrefs.DeleteAll ();

		// Add 1.000.000 money to player prefs    key
		if (Input.GetKeyDown (KeyCode.E))
			PlayerPrefs.SetInt (totalMoneyKey,PlayerPrefs.GetInt (totalMoneyKey)+1000000);
	}


	public void UpdateDisplay()
	{
		if (totalMoney > 50)
			totalMoneyText.text = totalMoney.ToString ("###,###,###,###") + " $";
		else
			totalMoneyText.text = totalMoney.ToString() + " $";
		


	}

	public int GetMoney()
	{
		return totalMoney;
	}

	public void SetMoney(int value)
	{
		totalMoney = totalMoney+value;
		UpdateDisplay ();
		PlayerPrefs.SetInt (totalMoneyKey,totalMoney);
	}

	public void ChangeMoney(int value)
	{
		totalMoney = totalMoney+value;
		UpdateDisplay ();
		PlayerPrefs.SetInt (totalMoneyKey,totalMoney);
	}

	public void PlayAudio(int id)
	{
		if (id == 0)
			audioSource.PlayOneShot (buyClip);
		else
			audioSource.PlayOneShot (errorClip);
		
	}
}

