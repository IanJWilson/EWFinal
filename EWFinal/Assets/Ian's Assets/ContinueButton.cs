using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButton : PauseMenu {


    public void ContinueGame()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }


}
