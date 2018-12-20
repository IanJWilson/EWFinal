﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public float waitTime;

    public GameObject Shuriken;


    public bool IsAttacking;
    public bool HitShield;
    public bool testbool = true;
    Vector3 pointA;
    Vector3 pointB;


    void Start()
    {
        pointA = new Vector3(0.6f, 0, 0.5f);
        pointB = new Vector3(0.6f, 0, 1.5f);
    }

    void Update()
    {           // In future I will also be checking here what weapon is active to change the type of attack if necessary
        if (Input.GetKey("2"))
        {

            float time = Mathf.PingPong(Time.time * 1f, 1);
            transform.localPosition = Vector3.Lerp(pointA, pointB, time);
        }

        if (Input.GetKeyDown("1"))
        {
            if(waitTime <= 0)
            {
                Instantiate(Shuriken, transform.position, Quaternion.identity);
            }

        }
        if(waitTime > 0)
        {
            waitTime -= Time.deltaTime;
        }

  
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Enemy"))
        //{
        //    IsAttacking = true;
        //    //Do damage
        //  //  other.GetComponent<EnemyWheel>().EnemyHealth--;
        //    IsAttacking = false;
        //}
        if (other.CompareTag("Player"))
        {
            IsAttacking = true;
            //Do damage
           other.GetComponent<PLayer>().CurrentPlayerHealth--;
            
        }
    }






    /*public void Thrust(GameObject weapon)
    {

    }
    public void Bounce(Rigidbody Target)
    {
        Target.velocity = (Target.transform.forward * -3f);
    
    }*/




}
