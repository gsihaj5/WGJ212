using System;
using TMPro;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] protected float coolDown = 1;
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletForce;

    [SerializeField] private TMP_Text fireRateText;

    private bool _isFiring;

    private float _timeFromLastShoot = 0;

    private void Start()
    {
        GearManager.OnGunSucceedUpgrade += UpgradeGun;
    }

    void Update()
    {
        fireRateText.text = (1f / coolDown).ToString("n2");
        if (Input.GetButtonDown("Fire1")) _isFiring = true;
        else if (Input.GetButtonUp("Fire1")) _isFiring = false;

        if (_timeFromLastShoot < coolDown) _timeFromLastShoot += Time.deltaTime;
        else if (_isFiring && (_timeFromLastShoot >= coolDown))
        {
            Fire();
            _timeFromLastShoot = 0;
        }
    }

    private void UpgradeGun(object sender, EventArgs e)
    {
        coolDown -= coolDown / 10;
    }

    private void OnDestroy()
    {
        GearManager.OnGunSucceedUpgrade -= UpgradeGun;
    }

    // ReSharper disable Unity.PerformanceAnalysis
    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}