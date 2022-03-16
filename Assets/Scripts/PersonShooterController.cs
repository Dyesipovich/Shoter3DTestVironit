using System;
using UnityEngine;
using Cinemachine;
using StarterAssets;

public class PersonShooterController : MonoBehaviour
{
    [SerializeField] private Cinemachine3rdPersonFollow _personFollowComponent;
    private StarterAssetsInputs _input;

    private void Awake()
    {
        //_personFollowComponent = virtualCamera.GetCinemachineComponent<Cinemachine3rdPersonFollow>();
        _input = GetComponent<StarterAssetsInputs>();
    }

    private void Update()
    {
        
    }

    private void Aim ()
    {
    //    if(_input.aim)
    //    {
    //        if (_personFollowComponent.CameraDistance > aimCameraDistance)
    //        {
    //            _personFollowComponent.CameraDistance -= aimChangeSpeed * Time.deltaTime;
    //        }
    //        else
    //        { 
    //            _personFollowComponent.CameraDistance = aimCameraDistance; 
    //        }
    //        thirdPersonController.SetSensitivity(aimSensitivity);
    //        thirdPersonController.SetRotateOnMove(false);
    //    }
    //    else
    //    {
    //        if (personFollowComponent.CameraDistance < normalCameraDistance)
    //        {
    //            personFollowComponent.CameraDistance += aimChangeSpeed * Time.deltaTime;
    //        }
    //        else
    //        {
    //            personFollowComponent.CameraDistance = normalCameraDistance;
    //        }
    //        thirdPersonController.SetSensitivity(normalSensitivity);
    //        thirdPersonController.SetRotateOnMove(true);
    //    }
    }

}
