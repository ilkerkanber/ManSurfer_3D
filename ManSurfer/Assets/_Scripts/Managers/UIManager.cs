using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : ASingleton<UIManager>
{
    [SerializeField] GameObject WinCanvas;
    [SerializeField] GameObject LoseCanvas;
    [SerializeField] GameObject StartCanvas;

    void OnEnable()
    {
        GameManager.OnNextLevel += EnableStartCanvas;
        GameManager.OnWin += EnableWinCanvas;
        GameManager.OnGameOver += EnableLoseCanvas;
    }
    void OnDisable()
    {
        GameManager.OnNextLevel -= EnableStartCanvas;
        GameManager.OnWin -= EnableWinCanvas;
        GameManager.OnGameOver -= EnableLoseCanvas;
    }
    void Awake()
    {
        SetupSingleton(this);
    }
    public void DisableStartCanvas()
    {
        StartCanvas.SetActive(false);
    }
    void EnableStartCanvas()
    {
        StartCanvas.SetActive(true);
    }
    void EnableWinCanvas()
    {
        WinCanvas.SetActive(true);
    }
    void EnableLoseCanvas()
    {
        LoseCanvas.SetActive(true);
    }
}
