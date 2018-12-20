using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour {

    public float ShurikenSpeed;

    public Transform AimTarget;
    public Vector3 target;




	void Start () {
        AimTarget = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector3(AimTarget.position.x, AimTarget.position.y, AimTarget.position.z);
    }

	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, target, ShurikenSpeed * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y && transform.position.z == target.z)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PLayer>().CurrentPlayerHealth--;
            Destroy(gameObject);
        }
        //else
        //{
        //    Destroy(gameObject);
        //}
    }
}
