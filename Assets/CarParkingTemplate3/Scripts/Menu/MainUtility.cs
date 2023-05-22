//--------------------------------------------------------------
//
//                    Car Parking Template 3.0
//        
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

// This script used for main utilities used in game menus

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainUtility : MonoBehaviour
{
	
	public GameObject Loading,exitMenu;

	public int startingScore = 1400;

	// Main Menu screen resolution
	public int xx = 1280,yy = 720;

	void Awake ()
	{
		Screen.SetResolution (xx, yy, true);

		Camera.main.aspect = 16f / 9f;


		// Is game first run?   3 => true    0 => false
		if (PlayerPrefs.GetInt ("FirstRun") != 3) 
		{
			PlayerPrefs.SetInt ("FirstRun", 3);

			// Open first level
			PlayerPrefs.SetInt ("LevelNum", 1);

			// Set ambiant sound in settings true
			PlayerPrefs.SetInt ("AmbientSound", 3);

			// Set Sea active in settings true
			PlayerPrefs.SetInt ("Sea", 3);

			// Open first car
			PlayerPrefs.SetInt ("Car0", 3);
			PlayerPrefs.SetInt ("CarColor0", 0);
			PlayerPrefs.SetInt ("CarColor1", 3);
			// Player starting first time coins
			PlayerPrefs.SetInt ("Coins", startingScore);

			PlayerPrefs.SetInt ("LevelXP", 1);

			// Unlock first customize items
			for (int a = 0; a < 10; a++) {
				PlayerPrefs.SetInt (a.ToString () + "Ring0", 3);
				PlayerPrefs.SetInt (a.ToString () + "Spoiler0", 3);
				PlayerPrefs.SetInt (a.ToString () + "Mirror0", 3);
			}
		}
	}

	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
			exitMenu.SetActive (!exitMenu.activeSelf);


		if (Input.GetKeyDown (KeyCode.H)) {
			PlayerPrefs.DeleteAll ();
			Debug.Log ("PlayerPrefs.DeleteAll ();");
		}
		if (Input.GetKeyDown (KeyCode.E))
			PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") + 14000);
	}

	public void Exit ()
	{
		Application.Quit ();
	}

	public void SetTrue (GameObject target)
	{
		target.SetActive (true);
	}

	public void SetFalse (GameObject target)
	{
		target.SetActive (false);
	}

	public void ToggleObject (GameObject target)
	{
		target.SetActive (!target.activeSelf);
	}

	public void LoadLevel (string name)
	{

		Loading.SetActive (true);
		SceneManager.LoadSceneAsync (name);
	}

	public void OpenURL (string val)
	{
		Application.OpenURL (val);
	}
}
