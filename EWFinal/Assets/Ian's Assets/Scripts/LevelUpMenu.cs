using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpMenu : MonoBehaviour {


    public static bool IsPaused = false;


    public GameObject LevelUpMenuUI;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //if (PlayerEXP => 10)
        //{
        //    if (IsPaused == false)
        //    {
        //        LevelUp();
        //    }
        //    else
        //    {
        //        Continue();
        //    }

        //}
    }


    void LevelUp()
    {
        LevelUpMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    void Continue()
    {
        LevelUpMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }
}
