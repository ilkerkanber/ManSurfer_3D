using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePoint : MonoBehaviour
{
    public Direction direction;
    public enum Direction{
        RIGHT,
        LEFT
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (direction)
            {
                case Direction.LEFT:
                    TurnCommand(other.gameObject, -90);
                    break;
                case Direction.RIGHT:
                    TurnCommand(other.gameObject, 90);
                    break;
            }
        }    
    }
    void TurnCommand(GameObject go, float dirValue)
    {
        go.transform.localRotation = Quaternion.Euler(0, dirValue, 0);    
    }
}
