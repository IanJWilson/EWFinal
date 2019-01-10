﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour {



    public AudioClip SwordSwing;
    public AudioClip SpearThrust;
    public AudioClip ShuriThrow;
    public AudioClip PowerUp;
    public AudioClip Heal;
    public AudioClip Die;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        SoundManager.instance.PlaySingle(SwordSwing);
        SoundManager.instance.PlaySingle(SpearThrust);
        SoundManager.instance.PlaySingle(ShuriThrow);
        SoundManager.instance.PlaySingle(PowerUp);
        SoundManager.instance.PlaySingle(Heal);
        SoundManager.instance.PlaySingle(Die);
    }

        //      if(dead){

        //        SoundManager.instance.musicsource.Stop();
        //              }

    
}
