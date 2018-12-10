using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public bool IsAttacking;
    public bool HitShield;
    public bool testbool = true;

    void Update()
    {
        if (testbool == true)
        {
            Vector3 WeaponSize = GetComponent<MeshRenderer>().bounds.size;
            Debug.Log(WeaponSize.z);
            transform.position = Vector3.Lerp(gameObject.transform.position, gameObject.transform.position + gameObject.transform.position, 1.5f);
            testbool = false;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            IsAttacking = true;
            //Do damage
            other.GetComponent<EnemyWheel>().EnemyHealth--;
            IsAttacking = false;
        }
        else if (other.CompareTag("Player"))
        {
            IsAttacking = true;
            //Do damage
            other.GetComponent<PlayerWheel>().PlayerHealth--;
            IsAttacking = false;
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
