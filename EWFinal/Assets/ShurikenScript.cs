using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenScript : MonoBehaviour {

    public float throwSpeed = 15f;
    public float duration = 2f;

    private Quaternion startRot;
    private Vector3 startLocation;
    private Rigidbody shurikenRB;
    public GameObject MeshAndCollider;
    public GameObject Parent;
    public GameObject self;

    private float startTime;
	// Use this for initialization
    void Awake()
    {
        startTime = Time.time;
        startLocation = transform.localPosition;
        startRot = transform.rotation;
        shurikenRB = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update () {
        MeshAndCollider.transform.Rotate(0, 0, 10);
        shurikenRB.velocity = transform.forward * throwSpeed;
        if (Time.time >= startTime + duration)
        {
            startRot = Parent.transform.rotation;
            transform.rotation = startRot;
            transform.localPosition = startLocation;
            self.SetActive(false);
            startTime = Time.time;
        }
	}
}
