using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{

    public Rigidbody body;
    public WheelCollider wheelBL;
    public WheelCollider wheelBR;
    public WheelCollider wheelFL;
    public WheelCollider wheelFR;
    public Transform wheelTransformBL;
    public Transform wheelTransformBR;
    public Transform wheelTransformFL;
    public Transform wheelTransformFR;

    public GameObject Floor;
    public Collider FloorCollider;

    public float currentSpeed = 0;
    public float topSpeed = 150;
    public float maxReverseSpeed = -50;
    public float maxTurnAngle = 10;
    public float maxTorque = 10;
    public Vector3 centerOfMassAdjustment = new Vector3(0f, -0.9f, 0f);

    // Use this for initialization
    void Start()
    {
        //lower center of mass for roll-over resistance
        body = GetComponent<Rigidbody>();
        body.centerOfMass += centerOfMassAdjustment;
        FloorCollider = Floor.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        float rotationThisFrame = 360 * Time.deltaTime;
        wheelTransformFR.Rotate(0, wheelBR.rpm / rotationThisFrame, 0);
        UpdateWheelPositions();

    }

    void UpdateWheelPositions()
    {
        //move wheels based on their suspension.
        WheelHit contact = new WheelHit();
        if (wheelFL.GetGroundHit(out contact))
        {
            Vector3 temp = wheelFL.transform.position;
            wheelTransformFL.position = temp;
        }
        if (wheelFR.GetGroundHit(out contact))
        {
            Vector3 temp = wheelFR.transform.position;
            wheelTransformFR.position = temp;
        }
        if (wheelBL.GetGroundHit(out contact))
        {
            Vector3 temp = wheelBL.transform.position;
            wheelTransformBL.position = temp;
        }
        if (wheelBR.GetGroundHit(out contact))
        {
            Vector3 temp = wheelBR.transform.position;
            wheelTransformBR.position = temp;
        }
    }
}