using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;

public class PersonDiedState : MonoBehaviour
{
    public static event Action PersonDied;

    [SerializeField] private Image _diedPanel;
    [SerializeField] private float _timeToRespawn = 10f;

    private Animator _animator;
    private void Awake()
    {
        PersonHealthCharacteristics.Died += OnDied;

        _animator = GetComponent<Animator>();
    }

    private void OnDied()
    {
        _animator.Play("Died");
        _diedPanel.enabled = true;
    }

    private IEnumerator TimeToRespawn ()
    {
        yield return new WaitForSeconds(_timeToRespawn);
        PersonDied?.Invoke();
    }
    private void OnDestroy()
    {
        PersonHealthCharacteristics.Died -= OnDied;
    }
}
