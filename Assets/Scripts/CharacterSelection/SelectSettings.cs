using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class SelectSettings : MonoBehaviour, IDragHandler
{
    [SerializeField] private Toggle[] _selectTeamToggle;
    [SerializeField] private GameObject[] _selectPerson;
    private bool _isFirstTeam;

    private void Update()
    {
        SelectTeam();
    }

    private void SelectTeam()
    {
        if (_selectTeamToggle[0].isOn)
        {
            _selectPerson[0].SetActive(true);
            _selectPerson[1].SetActive(false);
            _isFirstTeam = true;
        }
        else
        {
            _selectPerson[0].SetActive(false);
            _selectPerson[1].SetActive(true);
            _isFirstTeam = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_isFirstTeam)
        {
            _selectPerson[0].transform.Rotate(0f, -eventData.delta.x, 0f);
        }
        else
        {
            _selectPerson[1].transform.Rotate(0f, -eventData.delta.x, 0f);
        }
    }

}
