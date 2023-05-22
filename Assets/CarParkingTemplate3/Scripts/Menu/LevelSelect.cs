//--------------------------------------------------------------
//
//                    Car Parking Template 3.0
//        
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

// This script used for level selection and lock system in game menu

using UnityEngine;
using System.Collections;   
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{

	// Array of locks
	public GameObject[] Locks;
	    
	// Temp
	int temp;

	// Next menu for activat it
	public GameObject currentMenu, nextMenu;

	public GameObject[] star1Level,star2Level,star3Level;

	public Text[] bestTime;

	public GameObject selectDialog;

	public GameObject loading;

	public bool inGarage;
	public string levelName = "Day_Car";

	void Start ()
	{

			//Level  num   is  :   3
			temp = PlayerPrefs.GetInt ("LevelNum");
			for (int a = 0; a <= temp; a++) {
				if (temp > a)
					Locks [a].SetActive (false);
			}

			for (int aa = 0; aa < bestTime.Length; aa++) {

				float min = PlayerPrefs.GetFloat ("Minutes" + aa.ToString ());
				float secn = PlayerPrefs.GetFloat ("Seconds" + aa.ToString ());

				string minS, secS;

				minS = min.ToString ();
				secS = Mathf.Floor (secn).ToString ();

				if (min < 10)
					minS = "0" + min.ToString ();

				if (secn < 10)
					secS = "0" + Mathf.Floor (secn).ToString ();


				bestTime [aa].text = (minS + ":" + secS)
					.ToString ();

			if (PlayerPrefs.GetInt ("Star" + aa.ToString ()) == 3) 
			{
				star1Level [aa].SetActive (true);
				star2Level [aa].SetActive (true);
				star3Level [aa].SetActive (true);
			}
			if (PlayerPrefs.GetInt ("Star" + aa.ToString ()) == 2) 
			{
				star1Level [aa].SetActive (true);
				star2Level [aa].SetActive (true);
				star3Level [aa].SetActive (false);
			}
			if (PlayerPrefs.GetInt ("Star" + aa.ToString ()) == 1) 
			{
				star1Level [aa].SetActive (true);
				star2Level [aa].SetActive (false);
				star3Level [aa].SetActive (false);
			}
			if (PlayerPrefs.GetInt ("Star" + aa.ToString ()) == 0) 
			{
				star1Level [aa].SetActive (false);
				star2Level [aa].SetActive (false);
				star3Level [aa].SetActive (false);
			}





			}
	}

	public void SelectLevel (int id)
	{

		if (id < temp) 
		{
			tempID = id;


			selectDialog.SetActive (true);
		}

	}

	int tempID;

	public void SelectLevelNow()
	{
		if(loading)
			loading.SetActive (true);

		if(!inGarage)
			GetComponentInParent<PauseMen> ().Resume ();

		PlayerPrefs.SetInt ("LevelID", tempID);

		if(inGarage)
			SceneManager.LoadScene (levelName);
		else
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

}
