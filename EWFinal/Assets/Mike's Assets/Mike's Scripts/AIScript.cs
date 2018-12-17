using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : WheelController
{
    public Transform waypointContainer;
    public int numberOfGears;
    
    public float breakingDistance = 1f;
    public float forwardOffset;
    public float spoilerRatio = 0.1f;
    
    public float inputSteer;
    public float inputTorque;

    public Vector3 targetPoint;
    public Vector3 previousPoint;
    public Vector3 RelativeTargetPosition;

    public float floorMinX;
    public float floorMaxX;
    public float floorMinZ;
    public float floorMaxZ;
    public float ranTest = 0f;




    public GameObject testCube;


    void Start()
    {
        body = GetComponent<Rigidbody>();
        GetFloorBounds();
        SetTargets();
        previousPoint = transform.position;
        body.centerOfMass += centerOfMassAdjustment;
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        //calculate turn angle
        RelativeTargetPosition = transform.InverseTransformPoint(new Vector3(targetPoint.x, 1f, targetPoint.z));
        inputSteer = RelativeTargetPosition.x / RelativeTargetPosition.magnitude;
        testCube.transform.position = RelativeTargetPosition;
        ranTest = RelativeTargetPosition.magnitude;
        //Spoilers add down pressure based on the car�s speed. (Upside-down lift)
        Vector3 localVelocity = transform.InverseTransformDirection(body.velocity);
        body.AddForce(-transform.up * (localVelocity.z * spoilerRatio), ForceMode.Impulse);

        //calculate torque.		
        if (Mathf.Abs(inputSteer) < 0.5f)
        {
            //when making minot turning adjustments speed is based on how far to the next point.
            inputTorque = (RelativeTargetPosition.z / RelativeTargetPosition.magnitude);
        }
        else
        {
            if (localVelocity.z < 0)
            {
                inputTorque = -1;
                inputSteer *= -1;
            }
            //let off the gas while making a hard turn.
            else
            {
                inputTorque = 0;
            }
        }

        //if close enough, change waypoints.
        if (RelativeTargetPosition.magnitude < 1)
        {
            SetTargets();
        }

        //front wheel steering
        wheelFL.steerAngle = inputSteer * maxTurnAngle;
        wheelFR.steerAngle = inputSteer * maxTurnAngle;

        //calculate max speed in KM/H (optimized calc)
        currentSpeed = wheelBL.radius * wheelBL.rpm * Mathf.PI * 0.12f;
        if (currentSpeed < topSpeed && currentSpeed > maxReverseSpeed)
        {
            float adjustment = 1f;
            //float adjustment1 = Mathf.Abs(ForwardRayCast());
            //float adjustment2 = Mathf.Abs(RightRayCasts());
            //float adjustment3 = Mathf.Abs(LeftRayCasts());

            //if (adjustment1 < adjustment2 || adjustment1 < adjustment3) { adjustment = adjustment1; }
            //else if (adjustment2 < adjustment1 || adjustment2 < adjustment3) { adjustment = adjustment2; }
            //else if (adjustment3 < adjustment1 || adjustment3 < adjustment2) { adjustment = adjustment3; }

            //rear wheel drive.
            wheelBL.motorTorque = adjustment * inputTorque * maxTorque;
            wheelBR.motorTorque = adjustment * inputTorque * maxTorque;
        }
        else
        {
            //can't go faster, already at top speed that engine produces.
            wheelBL.motorTorque = 0;
            wheelBR.motorTorque = 0;
        }
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

    void Update()
    {
        //rotate the wheels based on RPM
        float rotationThisFrame = 360 * Time.deltaTime;
        wheelTransformFL.Rotate(-wheelFL.rpm / rotationThisFrame, 0, 0);
        wheelTransformFR.Rotate(-wheelFR.rpm / rotationThisFrame, 0, 0);
        wheelTransformBL.Rotate(-wheelBL.rpm / rotationThisFrame, 0, 0);
        wheelTransformBR.Rotate(-wheelBR.rpm / rotationThisFrame, 0, 0);
    }

    void GetFloorBounds()
    {
        floorMinX = FloorCollider.bounds.min.x;
        floorMaxX = FloorCollider.bounds.max.x;
        floorMinZ = FloorCollider.bounds.min.z;
        floorMaxZ = FloorCollider.bounds.max.z;
    }

    void SetTargets()
    {
        previousPoint = targetPoint;
        targetPoint = new Vector3(Random.Range(floorMinX+5,floorMaxX-5), 0.1f,Random.Range(floorMinZ+5,floorMaxZ-5));
    }


    //----------------------------------------------------RAYCASTS
    public float ForwardRayCast()

    {
        RaycastHit hit;
        Vector3 carFront = transform.position + (transform.forward * forwardOffset);
        Debug.DrawRay(carFront, transform.forward * breakingDistance);
        //if we detect a car infront of us, slow down or even reverse based on distance.
        if (Physics.Raycast(carFront, transform.forward, out hit, breakingDistance))
        {
            return (((carFront - hit.point).magnitude / breakingDistance) * 2) - 1;
        }
        //otherwise no change
        return 1f;
    }

    public float RightRayCasts()
    {
        RaycastHit hit;
        Vector3 carFront = transform.position + ((transform.forward * 1f) * .5f);
        Debug.DrawRay(carFront, ((transform.forward * (breakingDistance * .5f)) + (transform.right * (breakingDistance * .5f))));
        Debug.DrawRay((transform.position + (transform.forward * -.05f)), transform.right * (breakingDistance * .5f));
        //if we detect a car infront of us, slow down or even reverse based on distance.
        if (Physics.Raycast(carFront, ((transform.forward * (breakingDistance * .5f)) + (transform.right * (breakingDistance * .5f))), out hit, breakingDistance))
        {
            return (((carFront - hit.point).magnitude / breakingDistance) * 2) - 1;
        }
        if (Physics.Raycast((transform.position + (transform.forward * -.05f)), transform.right * (breakingDistance * .5f), out hit, breakingDistance))
        {
            return (((carFront - hit.point).magnitude / breakingDistance) * 2) - 1;
        }
        //otherwise no change
        return 1f;
    }

    public float LeftRayCasts()
    {
        RaycastHit hit;
        Vector3 carFront = transform.position + ((transform.forward * 1f) * .5f);
        Debug.DrawRay(carFront, ((transform.forward * (breakingDistance * .5f)) + (transform.right * (breakingDistance * -.5f))));
        Debug.DrawRay((transform.position + (transform.forward * -.05f)), transform.right * (breakingDistance * -.5f));
        //if we detect a car infront of us, slow down or even reverse based on distance.
        if (Physics.Raycast(carFront, ((transform.forward * (breakingDistance * .5f)) + (transform.right * (breakingDistance * -.5f))), out hit, breakingDistance))
        {
            return (((carFront - hit.point).magnitude / breakingDistance) * 2) - 1;
        }
        if (Physics.Raycast((transform.position + (transform.forward * -.05f)), transform.right * (breakingDistance * -.5f), out hit, breakingDistance))
        {
            return (((carFront - hit.point).magnitude / breakingDistance) * 2) - 2;
        }
        //otherwise no change
        return 1f;
    }
}
