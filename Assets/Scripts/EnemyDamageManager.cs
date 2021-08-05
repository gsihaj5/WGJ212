using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageManager : MonoBehaviour
{
    public static float Damage
    {
        get { return _damage; }
    }

    private static float _damage;

    private float _mutationCooldown = 10f;
    private float _timer;

    // Start is called before the first frame update
    private void Start()
    {
        _damage = 1;
        _timer = _mutationCooldown;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_timer > 0) _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            _damage *= 1.12f;
            _timer = _mutationCooldown;
        }
    }
}