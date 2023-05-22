//--------------------------------------------------------------
//
//                    Car Parking Template 3.0
//        
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class TrailerConnection : MonoBehaviour
{

    public GameObject cJoint;
    public string connectionName = "Connect_Trigger";
    public AudioSource connectionSound;
    Rigidbody player;
    public Light[] brakeLights, reverseLights, flashLights;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();

        if (!connectionSound)
            connectionSound = GetComponent<AudioSource>();

    }
    void OnTriggerEnter(Collider col)
    {

        if (col.name == "Connect_Trigger")
        {
            cJoint.GetComponent<ConfigurableJoint>().connectedBody = player;

            cJoint.transform.parent = player.transform;

            if (connectionSound)
                connectionSound.Play();

            cJoint.GetComponent<Trailer>().isActive = true;

            GameObject.FindObjectOfType<CameraManager>().canChangeCamera = true;

            GameObject.FindObjectOfType<CameraManager>().ActivateCam(0);

            GetComponentInParent<VehicleController2017>().brakeLights[0] = brakeLights[0];

            GetComponentInParent<VehicleController2017>().brakeLights[1] = brakeLights[1];

            GetComponentInParent<VehicleController2017>().reverseLights[0] = reverseLights[0];

            GetComponentInParent<VehicleController2017>().reverseLights[1] = reverseLights[1];

            col.GetComponentInParent<FlashLight>().flashLights[0] = flashLights[0];

            col.GetComponentInParent<FlashLight>().flashLights[1] = flashLights[1];

            Destroy(gameObject);

        }

    }

}
