//--------------------------------------------------------------
//
//                    Car Parking Template 3.0
//        
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

// This script used for load and activate level that selected in main menu     

using UnityEngine;
using System.Collections;
public class LevelLoader : MonoBehaviour
{
	// Use this for initialization
	public GameObject[] Levels;

	void Start ()
	{

		// First we want to disable all levels
		for (int a = 0; a < Levels.Length; a++)
			Levels [a].SetActive (false);


		// activate level based on selected on main menu
		if (PlayerPrefs.GetInt ("LevelID") <= Levels.Length)
			Levels [PlayerPrefs.GetInt ("LevelID")].SetActive (true);
		else
			Levels [Levels.Length].SetActive (true);
	
	}
}
