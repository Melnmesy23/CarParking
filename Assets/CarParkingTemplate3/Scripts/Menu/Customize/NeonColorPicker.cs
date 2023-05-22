//                    Car Parking Template 3.0
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NeonColorPicker : MonoBehaviour {

	// List of the colors
	public Color[] Colors;

	// Public function for changing color buttons
	public void SetColor (int id)
	{

			PlayerPrefs.SetInt ("NeonColor" + PlayerPrefs.GetInt ("CarID").ToString (), id);

 			GameObject.FindGameObjectWithTag ("Neon").GetComponent<NeonColorLoader>().mat.color = Colors [id];

	}
}
