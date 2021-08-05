using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    private Transform _playerTransform;

    [SerializeField] private float speed;

    public float Damage
    {
        get { return damage; }
    }

    [SerializeField] private float damage;

    [SerializeField] private float health;
    [SerializeField] private GameObject gearPrefab;

    private Transform _transform;

    private float _gearDropChance = .8f;

    public static EventHandler EnemyKilled;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        _playerTransform = GameObject.FindWithTag("Player").transform;
        health = EnemyHealthManager.Health;
    }

    private void Update()
    {
        if (health <= 0)
        {
            if (Random.Range(0f, 1f) <= _gearDropChance)
            {
                Instantiate(gearPrefab, gameObject.transform.position, Quaternion.identity);
            }

            EnemyKilled?.Invoke(this, EventArgs.Empty);

            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        var forwardDirection = _transform.up;
        _rigidbody2D.velocity = new Vector2(forwardDirection.x * speed, forwardDirection.y * speed);

        var playerPosition3d = _playerTransform.position;
        Vector2 playerPos = new Vector2(playerPosition3d.x, playerPosition3d.y);

        Vector2 lookDirection = playerPos - _rigidbody2D.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;

        _rigidbody2D.rotation = angle;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            health -= BulletDamageManager.Damage;
        }
    }
}