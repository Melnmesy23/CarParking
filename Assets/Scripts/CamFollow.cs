using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class CamFollow : MonoBehaviour
{


    public Transform target;
    public float sensitivity = 2f;
    public float distance = 5f;
    public float cameraSpeed = 5f;

    private float currentX = 0f;
    private float currentY = 0f;

    private Vector3 touchStart;



    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                touchStart = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                {
                    Vector2 touchDelta = touch.deltaPosition;
                    currentX += touchDelta.x * sensitivity;
                    currentY -= touchDelta.y * sensitivity;
                    currentY = Mathf.Clamp(currentY, -90f, 90f);
                }
            }
        }

        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = target.position + rotation * dir;
        transform.LookAt(target.position);

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= cameraSpeed * Time.deltaTime;
        transform.position += moveDirection;
    }

}