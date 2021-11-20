using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    public float lerpSpeedLimit = 3f;
    public List<Box> bag;
    
    GameObject myBox;
    GameObject trasheBox;
    
    void Start()
    {
        myBox = GameObject.FindGameObjectWithTag("MyBox");
        trasheBox = GameObject.FindGameObjectWithTag("TrasheBoxs");
    }
    public void AddCube(Box newBox)
    {
        SortCubes(1);
        SortSpeeds(1);
        newBox.transform.position = transform.position;
        newBox.transform.parent = myBox.transform;
        newBox.speed = lerpSpeedLimit;
        newBox.IsBag = true;
        bag.Add(newBox);
    }
    public void RemoveCube(int count)
    {
        if (bag.Count == 0)
        {
            return;
        }
        int remove = bag.Count - count;
        int bCOunt = bag.Count;
        for (int i = bCOunt-1; i >= remove; i--) 
        {
            bag[i].IsBag = false;
            bag[i].transform.parent = trasheBox.transform;
            bag.RemoveAt(i);
            if (bag.Count == 0)
            {
                GameManager.Instance.GameOver();
                return;
            }
            SortSpeeds(-1);
        }
    }
    void SortCubes(int direction)
    {
        for (int i = 0; i < bag.Count; i++)
        {
            bag[i].transform.position += (Vector3.up * 0.5f * direction);
        }
    }
    void SortSpeeds(int direction)
    {
        for (int i = 0; i < bag.Count; i++)
        {
            bag[i].speed -= (0.2f * direction);
        }
    }
}