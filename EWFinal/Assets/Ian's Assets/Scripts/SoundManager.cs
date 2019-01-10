using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioSource SFXSource;
    public AudioSource AmbienceSource;

    public static SoundManager instance = null;

    public float LowPitchRange = 0.90f;
    public float HighPitchRange = 1f;


	void Awake () {

        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
		
	}
	

    public void PlaySingle(AudioClip clip)
    {
        SFXSource.clip = clip;
        SFXSource.Play();
    }

	void Update () {
		
	}
}
