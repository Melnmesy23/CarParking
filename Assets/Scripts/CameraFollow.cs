using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public float sensitivity = 2f;
    public float distance = 5f;
    public float movementSpeed = 5f;

    private float currentX = 0f;
    private float currentY = 0f;

    private SmoothFollow2 smoothFollowScript;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        // Cursor.lockState = CursorLockMode.Locked;
        smoothFollowScript = GetComponent<SmoothFollow2>();
    }

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X") * sensitivity;
        currentY -= Input.GetAxis("Mouse Y") * sensitivity;
        currentY = Mathf.Clamp(currentY, -90f, 90f);

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Translate the camera's position based on keyboard input
        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= movementSpeed * Time.deltaTime;
        transform.position += moveDirection;

        // Toggle between following behind or in front of the object
        if (Input.GetKeyDown(KeyCode.F))
            smoothFollowScript.followBehind = !smoothFollowScript.followBehind;
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = target.position + rotation * dir;
        transform.LookAt(target.position);
    }

}
