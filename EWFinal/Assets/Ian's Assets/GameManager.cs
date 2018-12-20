using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public bool IsDead = false;



    private void MakeSingleton()
    {
        if(instance == null)
        {
            instance = new GameManager();
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        if(IsDead == true)
        {
            //DeathMenuUI.SetActive(true);
            //Time.timeScale = 0f;
            //IsPaused = true;
        }
        //else if(EnemiesRemaining <= 0)
        //{
        //    VicMenu.SetActive(true);
        //    Time.timeScale = 0f;
        //    IsPaused = true;
        //}
    }







}
