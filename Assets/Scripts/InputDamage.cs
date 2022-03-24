using System;
using UnityEngine;

public class InputDamage : MonoBehaviour
{
    public static Action<int> TakeDamage;

    [SerializeField, Range (1,100), Tooltip("1~100%")] private float _percentBlockDamage;

    [Space(5)]
    [Header("Headshot")]
    [SerializeField] private bool _isHead;
    [SerializeField, Min(1), Tooltip("To avoid increasing the hit damage, set the value to 1")] private float _headshotMultiplier = 2f;
    
    private const float convertPercents = 100f;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            var bulletBehaviour = other.gameObject.GetComponent<Bullet>();
            Damage(_isHead ? bulletBehaviour.Damage * _headshotMultiplier : bulletBehaviour.Damage);
        }
    }

    private void Damage(float bulletDamage)
    {
        int damge = (int)Math.Round(bulletDamage * _percentBlockDamage / convertPercents);
        //TakeDamage?.Invoke(damge);
        print(damge);
    }
}
