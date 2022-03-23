using System;
using UnityEngine;

[RequireComponent(typeof(Pool))]
public class Firearms : Weapon
{
    public static Action<int,int> BulletUIInitialize;

    [Header("BulletCharacteristics")]
    [SerializeField, Min(1)] private int _numberClips;
    [SerializeField, Min(1)] private int _numberBulletsInClip;
    [SerializeField, Min(1)] private float _bulletSpeed;
    [SerializeField] private Transform _bulletSpawnPosition;

    [Space(5)]
    [Header("WeaponCharacteristics")]
    [SerializeField, Min(1)] private float _weaponRateOfFire;
    [SerializeField, Min(1)] private float _weaponRelodSpeed;

    private Pool _pool;
    private void Awake()
    {
        PersonShooterController.WeaponTriggerPressed += DealingDamage;
        BulletUIInitialize?.Invoke(_numberClips, _numberBulletsInClip);
        _pool = GetComponent<Pool>();
    }

    public override void DealingDamage(Vector3 mouseWorldPosition)
    {
        Vector3 aimDirection = (mouseWorldPosition - _bulletSpawnPosition.position).normalized;
        var newBullet = _pool.GetFreeElement(_bulletSpawnPosition.position, Quaternion.LookRotation(aimDirection, Vector3.up));

        if (!newBullet.TryGetComponent<Bullet>(out var bulletBehaviour))
        {
            throw new MissingComponentException();
        }
        
        bulletBehaviour.Init(_bulletSpeed, _damage);
    }
    public virtual void WeaponReload()
    {

    }

    private void OnDestroy()
    {
        PersonShooterController.WeaponTriggerPressed -= DealingDamage;
    }
}
