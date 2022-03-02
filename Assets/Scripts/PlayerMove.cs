using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed;

    private PlayerInputSystem _inputSystem;
    private void Awake()
    {
        _inputSystem = new PlayerInputSystem();
        _inputSystem.Player.Shoot.performed += context => Shoot();
    }

    private void OnEnable()
    {
        _inputSystem.Enable();
    }

    private void OnDisable()
    {
        _inputSystem.Disable();
    }

    private void Update()
    {
        //считываем с инпут системы показания нажатия
        Vector2 moveDirection = _inputSystem.Player.Move.ReadValue<Vector2>();
        
        Move (moveDirection);

    }

    private void Move(Vector2 direction)
    {
        float scaledMoveSpeed = _moveSpeed * Time.deltaTime;

        Vector3 moveDirection = new Vector3(direction.x, 0f, direction.y);
        transform.position += moveDirection * scaledMoveSpeed;
    }


    private void Shoot()
    {
        print("Shoot");
    }
}
