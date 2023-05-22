//--------------------------------------------------------------
//
//                    Car Parking Template 3.0
//        
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {


	Transform target;
	public Vector3 dir;
	public float speed = 100f;

	void Start () {
		target = GetComponent<Transform> ();
	}
	

	void Update () {
		target.Rotate (dir * speed * Time.deltaTime);
	}
}
