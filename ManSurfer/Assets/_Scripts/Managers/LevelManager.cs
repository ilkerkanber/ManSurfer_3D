using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : ASingleton<LevelManager>
{
    [SerializeField] List<GameObject> levelList;

    void OnEnable()
    {
        GameManager.OnNextLevel += NewLevel;
        GameManager.OnRestartLevel += NewLevel;
    }
    void OnDisable()
    {
        GameManager.OnNextLevel -= NewLevel;
        GameManager.OnRestartLevel -= NewLevel;

    }
    void Awake()
    {
        SetupSingleton(this);
    }
    void Start()
    {
        Instantiate(levelList[GameManager.Instance.currentLevel], Vector3.zero, transform.rotation);
    }
    void NewLevel()
    {
        DestroyImmediate(GameObject.FindGameObjectWithTag("LEVEL"));
        Instantiate(levelList[GameManager.Instance.currentLevel], Vector3.zero, transform.rotation);
    }
}
