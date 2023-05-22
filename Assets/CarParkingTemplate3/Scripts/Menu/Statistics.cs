//--------------------------------------------------------------
//
//                    Car Parking kit 2.0
//        
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Statistics : MonoBehaviour {


	public Text TotalPassed,TotalFailed,PassedLevels,TotalCollisions,TotalScores,levelXpTXT;

	public Slider levelXP;

	void Start ()
	{
		LoadState ();
	}

	public void LoadState()
	{

		TotalPassed.text = PlayerPrefs.GetInt ("TotalPassed").ToString();
		TotalFailed.text = PlayerPrefs.GetInt ("TotalFailed").ToString();
		PassedLevels.text = PlayerPrefs.GetInt ("PassedLevels").ToString();
		TotalCollisions.text = PlayerPrefs.GetInt ("TotalCollisions").ToString();
		TotalScores.text = PlayerPrefs.GetInt ("Coins").ToString()+" $";

		levelXP.value = (float)PlayerPrefs.GetInt ("LevelXP");

		levelXP.value = Mathf.Clamp (levelXP.value, 0, levelXP.maxValue);

		levelXpTXT.text = levelXP.value.ToString();

	}
}


