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

    float inputValue;
    void OnEnable()
    {
        GameManager.OnGameOver += OnFreeze;
        GameManager.OnWin += OnFreeze;
    }
    void OnDisable()
    {
        GameManager.OnGameOver -= OnFreeze;
        GameManager.OnWin -= OnFreeze;
    }
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
        _mover.Active(horizontalSpeed * inputValue, verticalSpeed);        
    }
    void OnFreeze()
    {
        verticalSpeed = 0;
        horizontalSpeed = 0;
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
