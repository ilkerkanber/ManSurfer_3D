using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    Bag _bag;
    Animator anim;
    void OnEnable()
    {
        GameManager.OnGameOver += DeadAnim;
        GameManager.OnWin += WinAnim;
    }
    void OnDisable()
    {
        GameManager.OnGameOver -= DeadAnim;
        GameManager.OnWin -= WinAnim;
    }
    void Awake()
    {
        _bag = GetComponentInParent<Bag>();
        anim = GetComponentInChildren<Animator>();
    }
    void FixedUpdate()
    {
        if (_bag.bag.Count != 0)
        {
            transform.position = _bag.bag[0].gameObject.transform.position - Vector3.up * 0.2f;
        }
    }
    void WinAnim()
    {
        anim.SetTrigger("IsWin");
    }
    void DeadAnim()
    {
        anim.SetTrigger("IsDead");
    }
}
