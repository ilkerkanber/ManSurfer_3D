using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IEntityController
{
    [SerializeField] float verticalSpeed;
    [SerializeField] float horizontalSpeed;

    IMover _mover;
    InputController _inputController;
    Bag _bag;

    float inputValue,bugTimer;

    void Awake()
    {
        _bag = GetComponentInChildren<Bag>();
        _inputController = new InputController();
        _mover = new Mover(this);
    }
    void Update()
    {
        inputValue = _inputController.GetInput();
    }
    void FixedUpdate()
    {
        _mover.Active(horizontalSpeed * inputValue, verticalSpeed);        
    }
    void OnTriggerEnter(Collider collider)
    {
        if (Time.time < bugTimer + 0.2f)
        {
            return;
        }
        if (collider.CompareTag("Collectable"))
        {
            _bag.AddCube(collider.GetComponent<Box>());
        }
        if (collider.transform.parent.TryGetComponent<ObstacleCreater>(out ObstacleCreater _obs))
        {
            if (!_obs.IsEntered)
            {
                _bag.RemoveCube(_obs.BoxCount);
                _obs.IsEntered = true;
            }
        }
    }
}
