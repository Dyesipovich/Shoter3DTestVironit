using System;
using UnityEngine;


public class PersonCharacteristics : MonoBehaviour
{
    public static event Action<int> HelthInitialize;
    
    [SerializeField, Min(1)] private int _health;

    private void Awake()
    {
        HelthInitialize?.Invoke(_health);
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
