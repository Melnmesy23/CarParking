//                    Car Parking Template 3.0

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageCamera : MonoBehaviour {

	public Transform target;
	Transform currentTarget;

	public float smoothTime = 0.3F;
	private Vector3 velocity = Vector3.zero;

	public Transform[] points;


	void Start () 
	{
		currentTarget = points [0];
	}

	void Update() 
	{
		transform.position = Vector3.Lerp(transform.position, currentTarget.position,smoothTime * Time.deltaTime);

		transform.LookAt (target.position);
	}

	public void SwitchTarget(int id)
	{
		currentTarget = points [id];
	}
}
