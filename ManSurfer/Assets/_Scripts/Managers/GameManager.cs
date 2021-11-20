using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : ASingleton<GameManager>
{
    public static event System.Action OnGameOver;
    public static event System.Action OnWin;
    public static event System.Action OnNextLevel;

    public bool IsStarted;
    public int currentLevel;

    void Awake()
    {
        SetupSingleton(this);    
    }
    public void GameOver() 
    {
        OnGameOver?.Invoke();
    }
    public void Win()
    {
        OnWin?.Invoke();
    }
    public void NextLevel()
    {
        OnNextLevel?.Invoke();
    }

}
