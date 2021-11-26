using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePoint : MonoBehaviour
{
    public string directionBound;
    public Vector2 boundValues;
    public Dir dir;
    public enum Dir
    {
        LEFT,
        RIGHT
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (dir)
            {
                case Dir.LEFT:
                    TurnCommand(other.gameObject, -90);
                    break;
                case Dir.RIGHT:
                    TurnCommand(other.gameObject, 90);
                    break;
            }
            SetBoundPlayer(other);
        }    
    }
    void TurnCommand(GameObject go, float dirValue)
    {
        Rigidbody rb = go.GetComponent<Rigidbody>();
        go.transform.rotation = Quaternion.Euler(0,dirValue,0);
        //rb.MoveRotation(Quaternion.Euler(0, dirValue, 0));
    }
    void SetBoundPlayer(Collider col)
    {
        PlayerController pl = col.GetComponent<PlayerController>();
        pl.boundValues = boundValues;
        pl.directionBound = directionBound;
    }
}
