using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class movecamera : MonoBehaviour
{

    public float movementSpeed = 5.0f;
    public Vector2 minPosition;
    public Vector2 maxPosition; 

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float verticle = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0, verticle).normalized;

        Vector3 desiredPosition = transform.position + moveDirection * movementSpeed * Time.deltaTime;

        float clampedX = Mathf.Clamp(desiredPosition.x , minPosition.x, maxPosition.x);
        float clampedZ = Mathf.Clamp(desiredPosition.z, minPosition.y, maxPosition.y);

        Vector3 clampedPosition = new Vector3(clampedX, desiredPosition.y, clampedZ);

        transform.position = clampedPosition;
    }
}

