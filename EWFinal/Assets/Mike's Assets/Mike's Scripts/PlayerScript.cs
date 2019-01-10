using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : WheelController {

    public Quaternion playerQuat;
    public WeaponScript equipment;

	// Use this for initialization
	void Start () {
        playerQuat = transform.rotation;
        equipment = GetComponentInChildren<WeaponScript>();
	}
	
	// Update is called once per frame
	void Update () {
        
        //attack
        if (Input.GetKeyDown("space")&&equipment.isAttacking==false)
        {
            equipment.isAttacking = true;
        }

        //set equipped weapon
        if (Input.GetKeyDown("1")|| Input.GetKeyDown("2")|| Input.GetKeyDown("3"))
        {
            if (Input.GetKey("1"))
            {
                equipment.PlayerWeaponChoice(1);
            }
            else if (Input.GetKey("2"))
            {
                equipment.PlayerWeaponChoice(2);
            }
            else if (Input.GetKey("3"))
            {
                equipment.PlayerWeaponChoice(3);
            }
        }


	}

    void FixedUpdate()
    {
        //calculate max speed in KM/H (optimized calc)
        currentSpeed = wheelBL.radius * wheelBL.rpm * Mathf.PI * 0.12f;
        if (currentSpeed < topSpeed && currentSpeed > maxReverseSpeed)
        {
            //rear wheel drive.
            wheelBL.motorTorque = Input.GetAxis("Vertical") * maxTorque;
            wheelBR.motorTorque = Input.GetAxis("Vertical") * maxTorque;
        }
        else
        {
            //can't go faster, already at top speed that engine produces.
            wheelBL.motorTorque = 0;
            wheelBR.motorTorque = 0;
        }

        //front wheel steering
        wheelFL.steerAngle = Input.GetAxis("Horizontal") * maxTurnAngle;
        wheelFR.steerAngle = Input.GetAxis("Horizontal") * maxTurnAngle;
    }
}
