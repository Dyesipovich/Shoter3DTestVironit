using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _bulletDamage = 1;
    public float Damage => _bulletDamage;

    private Rigidbody _bulletRigidbody;
    private Rigidbody bulletRigidbody => _bulletRigidbody is null ? _bulletRigidbody = GetComponent<Rigidbody>() : _bulletRigidbody;

    public void Init(float Speed, int Damage)
    {
        _bulletDamage = Damage;
        bulletRigidbody.velocity = transform.forward * Speed * Time.deltaTime;
    }

    /// <summary>
    /// <para>Says that this instance is no longer needed</para>
    /// <para>ToDo: Make it Poolable</para>
    /// </summary>
    public void Release()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (!collision.gameObject.CompareTag("Player")) Release();

    }
}
