using System;
using UnityEngine;


public class PersonHealthCharacteristics : MonoBehaviour
{
    public static event Action<int> HelthUIInitialize;
    public static Action<int> HelthChange;
    public static Action Died;

    [SerializeField, Min(1)] private int _health;

    private void Awake()
    {
        HelthUIInitialize?.Invoke(_health);

        InputDamage.TakeDamage += OnTakeDamage;
    }

    private void OnTakeDamage(int damade)
    {
        if (damade >= _health)
        {
            HelthChange?.Invoke(0);
            Died?.Invoke();
        }
        else
        {
            _health -= damade;
            HelthChange?.Invoke(_health);
        }
    }

    private void OnDestroy()
    {
        InputDamage.TakeDamage -= OnTakeDamage;
    }
}
