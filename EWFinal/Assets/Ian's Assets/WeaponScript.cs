using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
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
        if (Input.GetKeyDown("2"))
        {

            float time = Mathf.PingPong(Time.time * 1f, 1);
            transform.localPosition = Vector3.Lerp(pointA, pointB, time);
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
           other.GetComponent<PLayer>().PlayerHealth--;
            
        }
    }





    //if (Input.GetKeyDown("1"))
    //{
    //    transform.position += Vector3.forward * Mathf.PingPong(Time.time * 0.1f, 10f);
    //}

    //if (testbool == true)
    //{
    //    Vector3 WeaponSize = GetComponent<MeshRenderer>().bounds.size;
    //    Debug.Log(WeaponSize.z);
    //    transform.position = Vector3.Lerp(gameObject.transform.position, gameObject.transform.position + gameObject.transform.position, 1.5f);
    //    testbool = false;

    //}





    /*public void Thrust(GameObject weapon)
    {

    }
    public void Bounce(Rigidbody Target)
    {
        Target.velocity = (Target.transform.forward * -3f);
    
    }*/




}
