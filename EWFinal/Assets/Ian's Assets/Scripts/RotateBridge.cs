using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBridge : MonoBehaviour {

    public bool hasTriggered;



        public Vector3 targetRotation = new Vector3(0f, 0f, 0f);

        private Vector3 currentRotation;

        public void Start()
        {
            currentRotation = transform.eulerAngles;
        }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && hasTriggered == false)
        {
       
                currentRotation = new Vector3
           (Mathf.LerpAngle(currentRotation.x, targetRotation.x, Time.deltaTime),
            Mathf.LerpAngle(currentRotation.y, targetRotation.y, Time.deltaTime),
            Mathf.LerpAngle(currentRotation.z, targetRotation.z, Time.deltaTime));

            transform.eulerAngles = currentRotation;

            hasTriggered = true;
        }
    }


}
