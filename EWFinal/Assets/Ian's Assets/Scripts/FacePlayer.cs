using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour {

    public Transform Player;
	
	void Start () {

        Player = GameObject.FindGameObjectWithTag("Player").transform;

    }
	
	
	void Update () {

        transform.LookAt(Player);
		
	}
}
