using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ObstacleCreater : MonoBehaviour
{
    [field:SerializeField]
    public int BoxCount{ get; private set; }
    
    [SerializeField] GameObject obstacleBox;
    public bool IsEntered;

    void Start()
    {
        Create(BoxCount);
    }
    void Update()
    {
        if (transform.childCount == BoxCount)
        {
            return;
        }
        if (transform.childCount < BoxCount)
        {
            Create(BoxCount - transform.childCount);
        }
        else
        {
            Remove(transform.childCount - BoxCount);
        }
    }
    void Create(int count)
    {
        for (int i = 1; i <= count; i++)
        {
            Instantiate(obstacleBox, transform.position + (Vector3.up * transform.childCount * 0.5f), transform.rotation, transform);
        }
    }
    void Remove(int count)
    {
        for (int i = 1; i <= count; i++)
        {
            DestroyImmediate(transform.GetChild(transform.childCount-1).gameObject);
        }
    }

}
