using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonDied : MonoBehaviour
{

    private void Awake()
    {
        PersonHealthCharacteristics.Died += OnDied;
    }

    private void OnDied()
    {
        
    }

    private void OnDestroy()
    {
        PersonHealthCharacteristics.Died -= OnDied;
    }
}
