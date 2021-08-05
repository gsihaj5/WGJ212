using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public static float Health
    {
        get { return _health; }
    }

    private static float _health;

    private float _mutationCooldown = 10f;
    private float _timer;

    // Start is called before the first frame update
    private void Start()
    {
        _health = 2;
        _timer = _mutationCooldown;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_timer > 0) _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            _health *= 1.12f;
            _timer = _mutationCooldown;
        }
    }
}