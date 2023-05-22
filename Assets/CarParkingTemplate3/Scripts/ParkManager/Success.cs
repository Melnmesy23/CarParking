//--------------------------------------------------------------
//
//                    Car Parking Template 3.0
//        
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

// This script used for success menu buttons

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Success : MonoBehaviour
{
	[Header("Success Menu Manager")]

	// Loading text for "Loading..."
	public Text LoadingTXT;

	// Parking Manager handler
	[HideInInspector]public ParkingManager manager;

	public string garageName = "Garage" ;

	// Activate parking place helper
	public void  ActiveHelper ()
	{
		manager.Helper.SetActive (!manager.Helper.activeSelf);
	}


	public IEnumerator Start ()
	{

		// Delay and find manager
		yield return new WaitForEndOfFrame();

		manager = GameObject.FindGameObjectWithTag ("Manager").GetComponent<ParkingManager> ();
	}

	// SuccessMenu continue button
	public void Continue ()
	{
		LoadingTXT.text = "Loading...";

		PlayerPrefs.SetInt ("LevelID", PlayerPrefs.GetInt ("LevelID") + 1);

		SceneManager.LoadScene  (SceneManager.GetActiveScene().name);
	}


	// SuccessMenu retry button
	public void Retry ()
	{
		LoadingTXT.text = "Loading...";
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name   );
	}


	//SuccessMenu exit button    
	public void Exit ()
	{
		LoadingTXT.text = "Loading...";
		SceneManager.LoadScene (garageName);
	}
}
