using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : ASingleton<GameManager>
{
    public static event System.Action OnGameOver;
    public static event System.Action OnWin;

    void Awake()
    {
        SetupSingleton(this);    
    }
    public void GameOver() 
    {
        Debug.Log("Oyun bitti");
        OnGameOver?.Invoke();
    }
    public void Win()
    {
        OnWin?.Invoke();
    }

}
