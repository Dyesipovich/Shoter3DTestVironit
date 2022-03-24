using UnityEngine;
using UnityEngine.Pool;
using System;

[RequireComponent(typeof(ObjectPool))]
public class Bullet : MonoBehaviour
{
    private float _bulletDamage = 1;
    public float Damage => _bulletDamage;

    private Rigidbody _bulletRigidbody;
    private Rigidbody bulletRigidbody => _bulletRigidbody is null ? _bulletRigidbody = GetComponent<Rigidbody>() : _bulletRigidbody;

    private ObjectPool _objectPool;

    private void Awake()
    {
        _objectPool = GetComponent<ObjectPool>();
    }
    public void Init(float Speed, int Damage)
    {
        _bulletDamage = Damage;
        bulletRigidbody.velocity = transform.forward * Speed * Time.deltaTime;
    }

    private void OnCollisionExit(Collision collision)
    {
        _objectPool.ReturnToPool();
    }
}
