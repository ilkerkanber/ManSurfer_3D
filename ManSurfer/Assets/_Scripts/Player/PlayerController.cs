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
    CollisionController _collisionController;

    public Vector2 boundValues;
    public string directionBound;
    float inputValue;

    void Awake()
    {
        _bag = GetComponentInChildren<Bag>();
        _collisionController = new CollisionController(_bag);
        _inputController = new InputController();
        _mover = new Mover(this);
    }
    void Update()
    {
        inputValue = _inputController.GetInput();
    }
    void FixedUpdate()
    {
        if (!GameManager.Instance.IsStarted || GameManager.Instance.IsFinished) 
        {
            return;
        }
        _mover.Movement(horizontalSpeed * inputValue, verticalSpeed);
        _mover.SetBound(directionBound,boundValues);
    }
    void OnTriggerEnter(Collider collider)
    {
        _collisionController.OnTriggerEnter(collider);
    }
    void OnTriggerStay(Collider collider)
    {
        _collisionController.OnTriggerStay(collider);
    }
}
