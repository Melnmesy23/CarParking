using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCameraMovement : MonoBehaviour
{
    public Transform target;
    public float sensitivity = 2f;
    public float distance = 5f;

    private float currentX = 0f;
    private float currentY = 0f;

    private Touch touch;

    private void Start()
    {
        // Cursor.lockState = CursorLockMode.Locked;
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // if (Input.touchCount > 0)
        // {
        //     touch = Input.GetTouch(0);
        //     float x = 0;

        //     if (touch.phase == TouchPhase.Moved)
        //     {
        //         x = touch.deltaPosition.x;
        //         Debug.Log(x);
        //     }
        // }

        currentX += Input.GetAxis("Mouse X") * sensitivity;
        currentY -= Input.GetAxis("Mouse Y") * sensitivity;
        currentY = Mathf.Clamp(currentY, 25f, 90f);
        Debug.Log(Input.GetAxis("Mouse X"));
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = target.position + rotation * dir;
        transform.LookAt(target.position);
    }

}