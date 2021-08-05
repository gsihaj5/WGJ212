using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform boundary1;
    [SerializeField] private Transform boundary2;
    [SerializeField] private GameObject enemies;

    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private float spawnCooldown;
    [SerializeField] private float enemyLimit = 20;
    [SerializeField] private string orientation = "horizontal";

    private float _spawnTimer;

    private float _mutationCooldown = 10f;
    private float _mutationTimer;

    private void Start()
    {
        _spawnTimer = spawnCooldown;
        _mutationTimer = _mutationCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (_mutationTimer > 0) _mutationTimer -= Time.deltaTime;

        if (_mutationTimer <= 0)
        {
            spawnCooldown -= spawnCooldown * .12f;
            _mutationTimer = _mutationCooldown;
        }

        Spawn();
    }

    void Spawn()
    {
        if (enemies.transform.childCount < enemyLimit)
        {
            _spawnTimer -= Time.deltaTime;
            if (_spawnTimer <= 0f)
            {
                Instantiate(
                    enemyPrefab,
                    RandomPos(),
                    Quaternion.identity, enemies.transform);

                _spawnTimer = spawnCooldown;
            }
        }
    }

    private Vector3 RandomPos()
    {
        if (orientation == "horizontal")
            return new Vector3(
                Random.Range(boundary1.position.x, boundary2.position.x),
                gameObject.transform.position.y
            );

        return new Vector3(
            gameObject.transform.position.x,
            Random.Range(boundary1.position.y, boundary2.position.y)
        );
    }
}