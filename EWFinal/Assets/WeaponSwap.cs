using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwap : MonoBehaviour {

    public bool spearSwap;
    public bool swordSwap;
    public bool shurikenSwap;
    private bool active;
    private int weaponNum;
    private int actCount;
    private float timeCount;

    public GameObject particleHolder;
    // Use this for initialization
    void Start () {
        if (spearSwap) { weaponNum = 1; } else if (swordSwap) { weaponNum = 2; } else if (shurikenSwap) { weaponNum = 3; }
        timeCount = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (active == false&&timeCount+1<=Time.time&&actCount<=14)
        {
            timeCount = timeCount + 1;
            actCount++;
        } else if (actCount >= 15){
            active = true;
            actCount = 0;
            particleHolder.SetActive(true);
        }
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<WeaponScript>().SwapWeapon(weaponNum);
        }
    }
}