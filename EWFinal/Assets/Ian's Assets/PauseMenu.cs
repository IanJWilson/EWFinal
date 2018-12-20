using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {




    public static bool IsPaused = false;


    public GameObject PauseMenuUI;
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(IsPaused == false)
            {
                Pause();
            }
            else
            {
                Continue();
            }
                
        }
		
	}

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    void Continue()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }
}
