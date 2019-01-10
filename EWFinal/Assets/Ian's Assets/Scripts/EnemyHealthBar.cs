using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour {

    public Slider EnemyHealth;
    public float EnemCurHealth;
    public float EnemStrtHealth;

    public Transform Player;

    // Use this for initialization
    void Start ()
    {
        EnemCurHealth = EnemStrtHealth;

        Player = GameObject.FindGameObjectWithTag("Player").transform;

    }
	
	// Update is called once per frame
	void Update ()
    {
        EnemyHealth.value = EnemCurHealth;
        EnemCurHealth--;
        //EnemyHealth.transform.LookAt(Player);
	}
}
