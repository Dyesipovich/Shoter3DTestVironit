using System;
using System.Collections.Generic;
using UnityEngine;

public class Firearms : Weapon
{
    public static Action<int,int> BulletUIInitialize;

    [Header("BulletCharacteristics")]
    [SerializeField] private Bullet _bullet;
    [SerializeField, Min(1)] private int _numberClips;
    [SerializeField, Min(1)] private int _numberBulletsInClip;
    [SerializeField, Min(1)] private float _bulletSpeed;

    [Space(5)]
    [Header("WeaponCharacteristics")]
    [SerializeField, Min(1)] private float _weaponRateOfFire;
    [SerializeField, Min(1)] private float _weaponRelodSpeed;

    private Bullet[] Bullets;

    private void Awake()
    {
        PersonShooterController.WeaponTriggerPressed += DealingDamage;
        BulletUIInitialize?.Invoke(_numberClips, _numberBulletsInClip);
        Bullets = new Bullet[_numberBulletsInClip];
    }

    public override void DealingDamage()
    {

    }
    public virtual void WeaponReload()
    {

    }

    private void OnDestroy()
    {
        PersonShooterController.WeaponTriggerPressed -= DealingDamage;
    }
}
