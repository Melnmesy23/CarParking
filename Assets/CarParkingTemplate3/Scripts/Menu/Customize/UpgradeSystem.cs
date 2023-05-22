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

public class UpgradeSystem : MonoBehaviour {


	// Temp for upgrades
	int tEngine,tSpeed,tBrake;
	[Header("Vehicle Upgrade System")]
	[Space(3)]
	public int maxUpgradeLevel = 10;
	[Space(3)]
	public Text EngineTXT,SpeedTXT,BrakeTXT;

	public int[] enginePrice,speedPrice,brakePrice;

	public Text enginePriceText, speedPriceText, brakePriceText;

	public AudioSource boxSound;

	[Space(3)]
	public GameObject Shop;

	T_Money tMoney;

	void Start () {

		tMoney = GameObject.FindObjectOfType<T_Money> ();

		// Load upgrades on start 
		LoadUpgrade ();
	}

	// Load upgrades
	public  void LoadUpgrade()
	{
		tEngine = PlayerPrefs.GetInt ("Engine" + PlayerPrefs.GetInt ("CarID"));
		EngineTXT.text = tEngine.ToString ()+" /"+maxUpgradeLevel.ToString();
		tSpeed = PlayerPrefs.GetInt ("Speed" + PlayerPrefs.GetInt ("CarID"));
		SpeedTXT.text = tSpeed.ToString ()+" /"+maxUpgradeLevel.ToString();
		tBrake = PlayerPrefs.GetInt ("Brake" + PlayerPrefs.GetInt ("CarID"));
		BrakeTXT.text = tBrake.ToString ()+" /"+maxUpgradeLevel.ToString();

		tMoney.UpdateDisplay ();

		if(tEngine<10)
			enginePriceText .text = enginePrice [tEngine].ToString () + " $";
		else
			enginePriceText .text = "Completed";
		
		if(tSpeed<10)
			speedPriceText .text = speedPrice [tSpeed].ToString () + " $";
		else
			speedPriceText .text = "Completed";

		if(tBrake<10)
			brakePriceText .text = brakePrice [tBrake].ToString () + " $";
		else
			brakePriceText .text = "Completed";
	}

	// Upgrade Engine
	public void EngineUpgrade()
	{
		if(tEngine<maxUpgradeLevel)
		{
			if(PlayerPrefs.GetInt ("Coins")>enginePrice[tEngine])
			{
				tMoney.SetMoney(-enginePrice[tEngine]);
				tEngine++;
				PlayerPrefs.SetInt ("Engine"+PlayerPrefs.GetInt ("CarID").ToString(),tEngine);
				tMoney.UpdateDisplay ();
				EngineTXT.text = tEngine.ToString ()+" /10";

				if(tEngine<10)
					enginePriceText .text = enginePrice [tEngine].ToString () + " $";
				else
					enginePriceText .text = "Completed";

				boxSound.Play ();

			}
			else
				Shop.SetActive(true);
		}
	}

	// Upgrade Speed
	public void SpeedUpgrade()
	{
		if(tSpeed<maxUpgradeLevel)
		{
			if(PlayerPrefs.GetInt ("Coins")>speedPrice[tSpeed])
			{
				tMoney.SetMoney(-speedPrice[tSpeed]);
				tSpeed++;
				PlayerPrefs.SetInt ("Speed"+PlayerPrefs.GetInt ("CarID").ToString(),tSpeed);
				tMoney.UpdateDisplay ();
				SpeedTXT.text = tSpeed.ToString ()+" /10";

				if(tSpeed<10)
					speedPriceText .text = speedPrice [tSpeed].ToString () + " $";
				else
					speedPriceText .text = "Completed";

				boxSound.Play ();

			}
			else
				Shop.SetActive(true);
		}
	}

	// Upgrade Brake 
	public void BrakeUpgrade()
	{
		if(tBrake<maxUpgradeLevel)
		{
			if(PlayerPrefs.GetInt ("Coins")>brakePrice[tBrake])
			{
				tMoney.SetMoney(-brakePrice[tBrake]);
				tBrake++;
				PlayerPrefs.SetInt ("Brake"+PlayerPrefs.GetInt ("CarID").ToString(),tBrake);
				tMoney.UpdateDisplay ();
				BrakeTXT.text = tBrake.ToString ()+" /10";	

				if(tBrake<10)
					brakePriceText .text = brakePrice [tBrake].ToString () + " $";
				else
					brakePriceText .text = "Completed";

				boxSound.Play ();

			}
			else
				Shop.SetActive(true);
		}
	}


	public void ToggleUpgradeMenu(GameObject target)
	{

		if (PlayerPrefs.GetInt ("Car" + PlayerPrefs.GetInt ("CarID").ToString ()) == 3) 
			target.SetActive (!target.activeSelf);
		
	}


	public GameObject upgradeMenu, controlls;


	public void OpenUpgrade()
	{
		if (PlayerPrefs.GetInt ("Car" + GameObject.FindObjectOfType<VehicleSelect> ().ID.ToString ()) == 3) {
			upgradeMenu.SetActive (!upgradeMenu.activeSelf);
			controlls.SetActive (!controlls.activeSelf);
			LoadUpgrade ();
		}
	}
}
