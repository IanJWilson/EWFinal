using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour {

    WeaponScript equipment;
	// Use this for initialization
	void Start () {

        equipment = GetComponentInParent<WeaponScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon")&&other.GetComponent<WeaponScript>().isAttacking==true) {
            equipment.ShieldBounce(other.GetComponent<Rigidbody>());
        }
    }
}
