//--------------------------------------------------------------
//
//                    Car Parking Template 3.0
//        
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class DragCamera : MonoBehaviour {


	public CameraMove cm;

	IEnumerator Start () {

		yield return new WaitForEndOfFrame ();

		if(!cm)
			cm = GameObject.Find("Camera-4-Orbit").GetComponent<CameraMove> ();

		if(!cm)
			this.enabled = false;
		
	}

	public void EnableDrag(bool state)
	{
		if (state)
			cm.canDrag = true;
		else
			cm.canDrag = false ;

	}
}

