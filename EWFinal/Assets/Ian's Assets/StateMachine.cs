using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour {

    private IEnumerable state;


    public static bool IsPaused = false;


    public GameObject PauseMenuUI;

   


    private void Start()
    {
        state = NotInMenuState();

        StartCoroutine(RunStateMachine());
    }
    
    public IEnumerator RunStateMachine()
    {
        while (state != null)
        {
            foreach (var cur in state)
            {
                yield return cur;
            }
        }
    }

    //private IEnumerable MainMenuState()
    //{
    //    while (true)
    //    {
    //      
    //    }
    //}





    private IEnumerable PauseMenuState()
    {
        while (true)
        {
            PauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            IsPaused = true;

            if (Input.GetKeyDown(KeyCode.P))
            {
                state = NotInMenuState();
            }
        }
    }



    private IEnumerable LevelMenuState()
    {
        while (true)
        {

        }
    }

    private IEnumerable NotInMenuState()
    {
        while (true)
        {
            PauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            IsPaused = false;

            if (Input.GetKeyDown(KeyCode.P))
            {
                state = PauseMenuState();
            }

        }
    }

}
