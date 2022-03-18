using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _bulletSpeed;
    private float _bulletDamage;
    private Rigidbody _bulletRigidbody;

    public Bullet(float bulletSpeed, int bulletDamage)
    {
        _bulletSpeed = bulletSpeed;
        _bulletDamage = bulletDamage;
    }

    private void Awake()
    {
        _bulletRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _bulletRigidbody.velocity = transform.forward * _bulletSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
