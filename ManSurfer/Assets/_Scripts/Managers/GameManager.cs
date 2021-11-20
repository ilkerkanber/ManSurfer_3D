using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : ASingleton<GameManager>
{
    public static event System.Action OnGameOver;
    public static event System.Action OnWin;
    public static event System.Action OnNextLevel;
    public static event System.Action OnRestartLevel;

    public bool IsStarted;
    public bool IsFinished;
    public int currentLevel;

    void Awake()
    {
        SetupSingleton(this);    
    }
    public void GameOver() 
    {
        IsFinished = true;
        OnGameOver?.Invoke();
    }
    public void Win()
    {
        IsFinished = true;
        OnWin?.Invoke();
    }
    public void RestartLevel()
    {
        ResetStates();
        OnRestartLevel?.Invoke();
    }
    public void NextLevel()
    {
        if (currentLevel == 5)
        {
            Debug.Log("Leveller bitti");
            return;
        }
        ResetStates();
        currentLevel++;
        OnNextLevel?.Invoke();
    }
    void ResetStates()
    {
        IsFinished = false;
        IsStarted = false;
    }

}
