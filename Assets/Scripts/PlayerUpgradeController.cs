using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgradeController : MonoBehaviour
{
    private bool _canBuy = false;
    [SerializeField] private float buyCooldown = 1f;

    private float _lastBuy;

    public static event EventHandler OnGunAttemptUpgraded;

    public static event EventHandler OnBulletAttemptUpgraded;

    void Start()
    {
        _lastBuy = 0f;
    }

    void Update()
    {
        HandleBuy();
    }

    private void HandleBuy()
    {
        if (_lastBuy > 0)
        {
            _lastBuy -= Time.deltaTime;
        }

        if (_canBuy && _lastBuy <= 0) BuyUpgrade();
    }

    private void BuyUpgrade()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _lastBuy += buyCooldown;
            OnGunAttemptUpgraded?.Invoke(this, EventArgs.Empty);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _lastBuy += buyCooldown;
            OnBulletAttemptUpgraded?.Invoke(this, EventArgs.Empty);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BuyingZone"))
        {
            _canBuy = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BuyingZone"))
        {
            _canBuy = false;
        }
    }
}

public class UpgradeEventArgs : EventArgs
{
    public float Cost
    {
        get { return _cost; }
    }

    private float _cost;

    public UpgradeEventArgs(float cost)
    {
        _cost = cost;
    }
}