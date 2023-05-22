//--------------------------------------------------------------
//
//                    Car Parking Template 3.0
//        
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class PhoneMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetTrue(GameObject target)
	{
		target.SetActive (true);
	}

	public void SetFalse(GameObject target)
	{
		target.SetActive (false);
	}

	public void ToggleObject(GameObject target)
	{
		target.SetActive (!target.activeSelf);
	}

	public void LoadLevel(string name)
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene (name);
	}
}

