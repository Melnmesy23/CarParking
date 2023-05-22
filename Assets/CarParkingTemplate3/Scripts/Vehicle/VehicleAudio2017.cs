//--------------------------------------------------------------
//
//                    Car Parking Template 3.0
//        
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

// This script used for car audio system

using System;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections;

[RequireComponent (typeof(VehicleController2017))]
public class VehicleAudio2017 : MonoBehaviour
{
	public AudioClip EngineSound;

	[HideInInspector]public AudioSource gearSource;
	public AudioClip gearShiftClip; 
	public float gearVolume = 1f;

	public float pitchMultiplier = 1f;

	public float PitchMin = 0.4343f;

	public float PitchMax = 1.7f;

	[HideInInspector]public AudioSource audioSource;


	private VehicleController2017 m_CarController;   

	public float crashVelocity = 10f;

	[Header("Need to disable audio in garage scene")]
	public string garageSceneName = "Garage";

	private void Start ()
	{
		m_CarController = GetComponent<VehicleController2017> ();

		gearSource = gameObject.AddComponent<AudioSource> ();

		gearSource.loop = false;
		gearSource.playOnAwake = false;
		gearSource.spatialBlend = 0;
		gearSource.volume = gearVolume;   


		audioSource = GetComponent<AudioSource>();

		audioSource.clip = EngineSound;
		   
		audioSource.loop = true;

		audioSource.Play ();

		if (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().name.Contains ("Garage")
			||UnityEngine.SceneManagement.SceneManager.GetActiveScene ().name == garageSceneName)
			{

				audioSource.Stop();
				this.enabled = false;
			}
		
	}

	private void Update ()
	{
		
			// The pitch is interpolated between the min and max values, according to the car's revs.
			float pitch = ULerp (PitchMin, PitchMax, m_CarController.Revs);

			// clamp to minimum pitch (note, not clamped to max for high revs while burning out)
			pitch = Mathf.Min (PitchMax, pitch);

			audioSource.pitch = pitch * pitchMultiplier;

			//audioSource.volume = 1f;

	}
	

	private static float ULerp (float from, float to, float value)
	{
		return (1.0f - value) * from + value * to;   
	}

	public AudioSource crashSound;



	void OnCollisionEnter(Collision collision)
	{

		if (collision.relativeVelocity.magnitude > crashVelocity) {

			if (!crashSound.isPlaying) {
				
					crashSound.Play ();

			}

		}
	}
	public void ChangeGear()
	{
		gearSource.clip = gearShiftClip;;
		gearSource.Play ();

	}
}

