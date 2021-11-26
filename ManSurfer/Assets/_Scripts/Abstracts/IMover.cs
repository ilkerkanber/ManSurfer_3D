using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMover 
{
    void Movement(float valueX, float valueZ);
    void SetBound(string direction, Vector2 bounds);
}
