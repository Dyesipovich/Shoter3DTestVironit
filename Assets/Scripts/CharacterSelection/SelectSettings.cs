using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectSettings : MonoBehaviour
{
    [SerializeField] private Toggle[] _selectTeam;

    private void Update()
    {
        _selectTeam[0].isOn = true;
    }

    private void SelectTeam()
    {

    }
}
