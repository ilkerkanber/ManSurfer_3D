using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover: IMover
{
    IEntityController _playerController;
    Rigidbody rb;
    public Mover(IEntityController playerController)
    {
        _playerController = playerController;
        rb = _playerController.GetComponent<Rigidbody>();
    }
    public void Movement(float valueX, float valueZ)
    {
        float amountX = (valueX * Time.deltaTime) / 100;
        float amountZ = (valueZ * Time.deltaTime);
        _playerController.transform.Translate(amountX, 0, amountZ);
    }
    public void SetBound(string direction,Vector2 bounds)
    {
        float x = _playerController.transform.position.x;
        float z = _playerController.transform.position.z;

        switch (direction)
        {
            case "X":
                x = Mathf.Clamp(_playerController.transform.position.x, bounds.x, bounds.y);
                break;
            case "Z":
                z = Mathf.Clamp(_playerController.transform.position.z, bounds.x, bounds.y);
                break;
        }
        _playerController.transform.position = new Vector3(x, 0, z);

    }
}