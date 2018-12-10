using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public bool IsAttacking;
    public bool HitShield;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            IsAttacking = true;
            //Do damage
           // other.GetComponent<Enemy>().EnemyHealth--;
            IsAttacking = false;
        }
        if (other.CompareTag("Player"))
        {
            IsAttacking = true;
            //Do damage
           // other.GetComponent<Player>().PlayerHealth--;
            IsAttacking = false;
        }
    }


}
