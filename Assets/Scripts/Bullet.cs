using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int _bulletDamage { get; private set; }
    private float _bulletSpeed;
    
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
        _bulletRigidbody.velocity = transform.forward * _bulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
