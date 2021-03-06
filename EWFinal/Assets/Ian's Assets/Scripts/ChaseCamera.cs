﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseCamera : MonoBehaviour {

    public Transform car;
    public float distance = 9f;
    public float height = 3f;
    public float rotationDamping = 3f;
    public float heightDamping = 2f;
    private float desiredAngle = 0;


    // LateUpdate is called once per frame after Update() has been called
    void LateUpdate()
    {
        float currentAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;
        //Determine where we want to be.
        desiredAngle = car.eulerAngles.y;
        float desiredHeight = car.position.y + height;
        //Now move towards our goals.
        currentAngle = Mathf.LerpAngle(currentAngle, desiredAngle, rotationDamping * Time.deltaTime);
        currentHeight = Mathf.Lerp(currentHeight, desiredHeight, heightDamping * Time.deltaTime);
        Quaternion currentRotation = Quaternion.Euler(0, currentAngle, 0);
        //Set our new positions.
        Vector3 finalPosition = car.position - (currentRotation * Vector3.forward * distance);
        finalPosition.y = currentHeight;
        transform.position = finalPosition;
        transform.LookAt(car);
    }

}
