using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    [SerializeField] private Vector3 _speed;
    [SerializeField] private float _maxPressedTime;
    [SerializeField] private float _velocityPerSecond;
    public bool IsGrounded { get; set; } = false;
    private float _pressedTime;
    private Rigidbody _rigidbody;

    //singleton
    public static Control Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance == this)
            Destroy(this);
    }
    //
    public void MouseDown()
    {
        _pressedTime = Time.time;
    }
    public void MouseUp()
    {
        if (IsGrounded) Jump();
    }
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Jump()
    {
        float currentJumpTime = Time.time - _pressedTime;
        if (currentJumpTime > _maxPressedTime)
            currentJumpTime = _maxPressedTime;

        Vector3 currentVelocity = _velocityPerSecond * currentJumpTime* Vector3.up;
        _rigidbody.velocity= currentVelocity;
    }


    protected void FixedUpdate()
    {
        Vector3 _moveDirection = _speed * Time.deltaTime;
        transform.Translate(_moveDirection);
    }
}
