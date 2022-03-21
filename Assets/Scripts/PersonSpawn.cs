using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _personPrefab;
    [SerializeField] private Transform _spawnPoint;

    private void Awake()
    {
        
    }

    private void SpawnPerson()
    {
        Instantiate (_personPrefab, _spawnPoint);
    }
}
