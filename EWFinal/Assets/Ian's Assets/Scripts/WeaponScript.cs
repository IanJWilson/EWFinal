using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public float waitTime;

    public GameObject Shuriken;

    public bool spearEQ = false;
    public bool swordEQ = false;
    public bool shurikenEQ = false;
    public bool HitShield;
    public bool testbool = true;
    public Vector3 pointA;
    private Vector3 pointB;
    public GameObject spearSpawn;
    public GameObject Spearset;
    public GameObject spearGO;
    public GameObject shieldGO;
    public GameObject Swordset;
    public GameObject Shurikenset;
    public GameObject Shuriken1;
    public GameObject Shuriken2;
    public bool isAttacking;
    public float lerpReverse;
    public int shurikenWait;
    public float count = 0f;
    public float countBy = .08f;
    public int countDown = 0;

    void Start()
    {
        lerpReverse = 0;
        spearEQ = false;
        swordEQ = false;
        shurikenEQ = true;
        Spearset.SetActive(false);
        Swordset.SetActive(false);
        Shurikenset.SetActive(true);
    }

    void Update()
    {
        pointA = spearSpawn.transform.localPosition;
        pointB = new Vector3(pointA.x, pointA.y, pointA.z + 1f);

        if (isAttacking == true) { Attack(); }
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
            isAttacking = true;
            //Do damage
           other.GetComponent<PLayer>().CurrentPlayerHealth--;
            
        }
    }
    
    public void PlayerWeaponChoice(int wepChoice)
    {
        if (wepChoice == 1)
        {
            spearEQ = true;
            swordEQ = false;
            shurikenEQ = false;
            Spearset.SetActive(true);
            Swordset.SetActive(false);
            Shurikenset.SetActive(false);
        } else if ( wepChoice == 2)
        {
            spearEQ = false;
            swordEQ = true;
            shurikenEQ = false;
            Spearset.SetActive(false);
            Swordset.SetActive(true);
            Shurikenset.SetActive(false);
        } else if (wepChoice == 3) {
            spearEQ = false;
            swordEQ = false;
            shurikenEQ = true;
            Spearset.SetActive(false);
            Swordset.SetActive(false);
            Shurikenset.SetActive(true);
        }
    }

    public void Attack()
    {
        if (spearEQ == true)
        {
            SpearAttack();
        }
        if (swordEQ == true)
        {
            SwordAttack();
        }
        if (shurikenEQ == true)
        {
            ThrowShuriken();
        }
    }

    public void SpearAttack()
    {
            if (countDown <= 13 && countDown >= 0)
            {
                countBy = 0.08f;
                countDown++;
                count = count + countBy;
            }
            else if (countDown >= 14 && countDown <= 29)
            {
                countBy = -0.08f;
                countDown++;
                count = count + countBy;
            }
            else if (countDown >= 30)
            {
                countBy = 0.08f;
                countDown = 0;
                count = 0;
                isAttacking = false;
            }
            spearGO.transform.localPosition = Vector3.Lerp(pointA, pointB, count);
    }

    public void ShieldBounce(Rigidbody Target)
    {
        Target.velocity = Target.transform.forward * -3f;
    }

    public void SwordAttack()
    {
        transform.Rotate(0, 20, 0);
        count++;
        if (count >= 36)
        {
            isAttacking = false;
            count = 0;
        }
    }

    public void ThrowShuriken()
    {
        if (Shuriken1.activeInHierarchy==false)
        {
            Shuriken1.SetActive(true);
        } else if (Shuriken2.activeInHierarchy==false)
        {
            Shuriken2.SetActive(true);
        }
        isAttacking = false;
    }

    public void SwapWeapon(int weaponNum)
    {
        PlayerWeaponChoice(weaponNum);
    }
}