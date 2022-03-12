using System;
using System.Collections.Generic;
using UnityEngine;


public class PersonCharacteristics : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField, Tooltip("")] private string _idleBullet;
    [SerializeField] private string _Bullet;

    private void Awake()
    {
        GlobalEvents.PersonTakeDamage += OnPersonTakeDamage;
    }

    private void OnPersonTakeDamage(int damade)
    {
        if (_health >= 0)
        {
            if (damade > _health)
            {
                GlobalEvents.PersonHelthChange?.Invoke(0);
            }
            else
            {
                _health -= damade;
            }

        }

    }

    private void OnDestroy()
    {
        GlobalEvents.PersonTakeDamage -= OnPersonTakeDamage;
    }
}
