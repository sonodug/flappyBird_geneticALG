using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdMovementController : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _speed;
    [SerializeField] private float _tapForce = 10;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private Rigidbody2D _rigidbody;

    protected virtual void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
        ResetBird();
    }

    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //PC input
        {
            Jump();
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    public void ResetBird()
    {
        transform.SetPositionAndRotation(_startPosition, Quaternion.Euler(0, 0, 0));
        _rigidbody.velocity = Vector2.zero;
    }

    public void Jump()
    {
        _rigidbody.velocity = new Vector2(_speed, 0);
        transform.rotation = _maxRotation;
        _rigidbody.AddForce(Vector2.up * _tapForce, ForceMode2D.Force);
    }
}