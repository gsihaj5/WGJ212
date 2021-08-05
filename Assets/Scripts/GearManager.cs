using System;
using TMPro;
using UnityEngine;

public class GearManager : MonoBehaviour
{
    private float _gearCount = 0;
    [SerializeField] private TMP_Text gearDisplay;

    public static event EventHandler OnGunSucceedUpgrade;
    public static event EventHandler OnBulletSuceedUpgrade;

    private float _gunUpgradeCost = 1f;
    private float _bulletUpgradeCost = 1f;

    private void Start()
    {
        PlayerCollision.OnGearCollected += GearCollected;
        PlayerUpgradeController.OnGunAttemptUpgraded += SpendGearForGunAttemptUpgrade;
        PlayerUpgradeController.OnBulletAttemptUpgraded += SpendGearForBulletAttemptUpgrade;
    }

    private void SpendGearForGunAttemptUpgrade(object sender, EventArgs e)
    {
        if (_gearCount - _gunUpgradeCost >= 0)
        {
            _gearCount -= _gunUpgradeCost;
            _gunUpgradeCost = _gunUpgradeCost * 1.07f;
            OnGunSucceedUpgrade?.Invoke(this, EventArgs.Empty);
        }

        UpdateGearCount();
    }

    private void SpendGearForBulletAttemptUpgrade(object sender, EventArgs e)
    {
        if (_gearCount - _bulletUpgradeCost >= 0)
        {
            _gearCount -= _bulletUpgradeCost;
            _bulletUpgradeCost = _bulletUpgradeCost * 1.07f;
            OnBulletSuceedUpgrade?.Invoke(this, EventArgs.Empty);
        }

        UpdateGearCount();
    }

    private void GearCollected(object sender, EventArgs e)
    {
        _gearCount++;
        gearDisplay.text = _gearCount.ToString("n2");
    }

    private void UpdateGearCount()
    {
        gearDisplay.text = _gearCount.ToString("n2");
    }

    private void OnDestroy()
    {
        PlayerCollision.OnGearCollected -= GearCollected;
        PlayerUpgradeController.OnGunAttemptUpgraded -= SpendGearForGunAttemptUpgrade;
        PlayerUpgradeController.OnBulletAttemptUpgraded -= SpendGearForBulletAttemptUpgrade;
    }
}