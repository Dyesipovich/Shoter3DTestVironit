using System;
using UnityEngine;

public class InputDamage : MonoBehaviour
{
    [SerializeField] private double _damagePercent;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            //GlobalEvents.PersonTakeDamage?.Invoke(Math.Round());
        }
    }
}
