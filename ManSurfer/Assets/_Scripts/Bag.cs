using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    public float lerpSpeedLimit = 3f;
    public List<Box> bag;

    public void AddCube(Box newBox)
    {
        SortCubes(1);
        newBox.transform.position = transform.position;
        newBox.speed = lerpSpeedLimit;
        newBox.IsBag = true;
        bag.Add(newBox);
    }
    public void RemoveCube(int count)
    {
        SortCubes(-1);
        for (int i = 0; i < count; i++)
        {
            bag[i].IsBag = false;
            bag.RemoveAt(i);
        }
    }
    void SortCubes(int direction)
    {
        for (int i = 0; i < bag.Count; i++)
        {
            bag[i].transform.position += (Vector3.up * 0.5f * direction);
            bag[i].speed -= (0.2f * direction);
        }
    }
}