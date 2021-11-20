using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover:IMover
{
    IEntityController _playerController;
    Rigidbody rb;
    public Mover(IEntityController playerController)
    {
        _playerController = playerController;
        rb = _playerController.GetComponent<Rigidbody>();
    }
    public void Active(float valueX, float valueZ)
    {
        float amountX = (valueX * Time.deltaTime) / 100;
        float amountZ = (valueZ * Time.deltaTime);
        Vector3 newPos = _playerController.transform.position + new Vector3(amountX, 0, amountZ);
        newPos.x = Mathf.Clamp(newPos.x, -2f, 2f);
        rb.MovePosition(newPos);
    }
}