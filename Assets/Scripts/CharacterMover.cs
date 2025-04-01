using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMover : Character
{
    private string _horizontalAxis = "Horizontal";
    private string _verticalAxis = "Vertical";

    private float _xForce;
    private float _zForce;
    
    private Rigidbody _rigidbody;

    private float _deadZone = 0.05f;

    private bool _isMove;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        GetInput();

        if (DeadZone())
        {
            _isMove = true;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (_isMove)
        {
            _rigidbody.AddForce(Vector3.right * (_xForce * Speed), ForceMode.Force);
            _rigidbody.AddForce(Vector3.forward * (_zForce * Speed), ForceMode.Force);

            Vector3 direction = _rigidbody.velocity;
            
            if (direction.magnitude > _deadZone)
                transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    private bool DeadZone() => Mathf.Abs(_zForce) > _deadZone || Mathf.Abs(_xForce) > _deadZone;

    private void GetInput()
    {
        _xForce = Input.GetAxis(_horizontalAxis);
        _zForce = Input.GetAxis(_verticalAxis);
    }
}