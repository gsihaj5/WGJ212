using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    private Vector2 _playerDirection;
    private Vector2 _mousePos;

    public Camera cam;

    [SerializeField] private float speed;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _playerDirection.x = Input.GetAxisRaw("Horizontal");
        _playerDirection.y = Input.GetAxisRaw("Vertical");

        _mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(_playerDirection.x * speed, _playerDirection.y * speed);

        Vector2 lookDirection = _mousePos - _rigidbody2D.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;

        _rigidbody2D.rotation = angle;
    }
}