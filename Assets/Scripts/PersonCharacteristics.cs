using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PersonCharacteristics : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField, Tooltip("")] private string _idleBullet;
    [SerializeField] private string _Bullet;
    
    private void TakeDamage (int damade)
    {
        _health -= damade;
    }
}
