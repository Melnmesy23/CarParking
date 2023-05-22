//                    Car Parking Template 3.0

using UnityEngine;
using System.Collections;
      
public class NeonColorLoader : MonoBehaviour {

	// List of the Neon colors
	public Color[] Colors;

	// Neon material for changing color
	public Material mat;

	public string CarID   ;

	void Start () {

			// Load last selected color by ID
		if (PlayerPrefs.GetInt ("NeonColor" + CarID) == 0)
				mat.color = Colors [0];
		if (PlayerPrefs.GetInt ("NeonColor" + CarID) == 1)
				mat.color = Colors [1];
		if (PlayerPrefs.GetInt ("NeonColor" + CarID) == 2)
				mat.color = Colors [2];
		if (PlayerPrefs.GetInt ("NeonColor" + CarID) == 3)
				mat.color = Colors [3];
		if (PlayerPrefs.GetInt ("NeonColor" + CarID) == 4)
				mat.color = Colors [4];
		if (PlayerPrefs.GetInt ("NeonColor" + CarID) == 5)
				mat.color = Colors [5];
		if (PlayerPrefs.GetInt ("NeonColor" + CarID) == 6)
				mat.color = Colors [6];
		if (PlayerPrefs.GetInt ("NeonColor" + CarID) == 7)
				mat.color = Colors [7];

	}
}
