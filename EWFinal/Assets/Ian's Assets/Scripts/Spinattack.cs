using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinattack : MonoBehaviour {

    public float speed, rotSpeed;



    void Update()
    {
        if (Input.GetKey("1"))
        {
            transform.Rotate(0, rotSpeed, 0);
        }
  
    }
}
