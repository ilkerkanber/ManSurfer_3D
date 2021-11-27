using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoot : MonoBehaviour
{
    PlayerController _playerController;

    void Awake()
    {
        _playerController = GetComponentInParent<PlayerController>();
    }
    void FixedUpdate()
    {
        switch (_playerController.directionBound)
        {
            case "X":
                transform.position = new Vector3(AverageBoundValue(), transform.position.y, transform.position.z);
                break;

            case "Z":
                transform.position = new Vector3(transform.position.x, transform.position.y, AverageBoundValue());
                break;
        }    
    }
    float AverageBoundValue()
    {
        return (_playerController.boundValues.x + _playerController.boundValues.y) / 2;
    }
}
