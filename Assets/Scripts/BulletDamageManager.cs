using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Object = System.Object;

public class BulletDamageManager : MonoBehaviour
{
    public static float Damage = 1f;
    [SerializeField] private TMP_Text bulletDamageText;

    private void Start()
    {
        GearManager.OnBulletSuceedUpgrade += UpgradeDamage;
    }

    private void Update()
    {
        bulletDamageText.text = Damage.ToString("n2");
    }

    private void OnDestroy()
    {
        GearManager.OnBulletSuceedUpgrade -= UpgradeDamage;
    }

    private void UpgradeDamage(Object sender, EventArgs e)
    {
        Damage++;
    }
}