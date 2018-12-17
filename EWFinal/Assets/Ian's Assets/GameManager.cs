using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public bool IsDead;



    private void MakeSingleton()
    {
        if(instance == null)
        {
            instance = new GameManager();
            DontDestroyOnLoad(gameObject);
        }
    }







}
