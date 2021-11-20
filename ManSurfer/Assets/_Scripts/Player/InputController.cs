using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController
{
    Vector2 startPos;
    Vector2 direction;
    public float GetInput()
    {
        if (Input.touchCount > 0)
        {
            Touch _touch = Input.GetTouch(0);

            switch (_touch.phase)
            {
                case TouchPhase.Began:
                    startPos = _touch.position;
                    break;
                case TouchPhase.Moved:
                    direction = _touch.position - startPos;
                    break;
                case TouchPhase.Ended:
                    direction = Vector2.zero;
                    break;
            }
        }
        return direction.x;
    }
}