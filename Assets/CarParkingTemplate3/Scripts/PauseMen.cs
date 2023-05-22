//--------------------------------------------------------------
//
//                    Car Parking Template 3.0
//        
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

// This script used for level Pause menu system   

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMen : MonoBehaviour
{
	[Header("Pause Menu Manager")]


	public GameObject PauseMenu;
	public GameObject mobileControlls;
	public GameObject startFade;

	public Text LoadingText;

	public string garageName  = "Garage";

	public float fadeTime = 3f;

	void Awake()
	{

		if (GetComponent<InputSystem> ().controllType == InputType.Keyboard)
			mobileControlls.SetActive (false);

		startFade.SetActive (true);
	}

	bool started;

	IEnumerator  Start()
	{
		Time.timeScale = 1f;


		yield return new WaitForSeconds (fadeTime);
		startFade.SetActive (false);
		started = true;
	}
	public void Pause ()
	{
		if (started) {
			PauseMenu.SetActive (true);
			GameObject.FindObjectOfType<AudioListener>().enabled = false;
			Time.timeScale = 0f;

		}
	}

	public void Resume ()
	{
		if (GetComponent<InputSystem> ().controllType == InputType.Mobile)
			mobileControlls.SetActive (true);

		GameObject.FindObjectOfType<AudioListener>().enabled = true;

		PauseMenu.SetActive (false);
		Time.timeScale = 1f;
	}



	public void Retry ()
	{
		GameObject.FindObjectOfType<AudioListener>().enabled = true;
		LoadingText.text = "Please Wait...";
		PauseMenu.SetActive (false);
		Time.timeScale = 1f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);


	}

	public void Exit ()
	{
		LoadingText.gameObject.SetActive (true);
		Time.timeScale = 1f;
		LoadingText.text = "Please Wait...";
		SceneManager.LoadScene(garageName);
	}

	public void SetTrue(GameObject target)
	{
		target.SetActive (true);
	}

	public void SetFalse(GameObject target)
	{
		target.SetActive (false);
	}


	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape))
			Pause ();
	}


}
