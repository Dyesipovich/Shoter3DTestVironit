using System;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.UI;

public class PersonShooterController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _personFollowComponent;

    [SerializeField] private float _aimIdle = 25f;
    [SerializeField] private float _aimApproximation = 15f;

    [SerializeField] private float _idleSensitivity = 1f;
    [SerializeField] private float _aimSensitivity = 0.5f;

    [SerializeField] private LayerMask _aimColliderLayerMask = new LayerMask();

    [SerializeField] private Image _crosshair;

    [SerializeField] private float _smoothnessTurningToCrosshair = 1f;
    
    [SerializeField] private Transform _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPosition;

    private StarterAssetsInputs _input;
    private ThirdPersonController _thirdPersonController;

    private void Awake()
    {
        _input = GetComponent<StarterAssetsInputs>();
        _thirdPersonController = GetComponent<ThirdPersonController>();
    }

    private void Update()
    {
        Aim();
    }

    private void Aim()
    {
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 500f, _aimColliderLayerMask))
        {
            mouseWorldPosition = raycastHit.point;
        }

        if (_input.aim)
        {
            AimState(_aimApproximation, _aimSensitivity, true, false);
            
            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;
            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * _smoothnessTurningToCrosshair);

            Shot(mouseWorldPosition);

        }
        else
        {
            AimState(_aimIdle, _idleSensitivity, false, true);
        }
    }

    private void Shot (Vector3 mouseWorldPosition)
    {
        if (_input.shot)
        {
            Vector3 aimDirection = (mouseWorldPosition - _bulletSpawnPosition.position).normalized;
            Instantiate(_bulletPrefab, _bulletSpawnPosition.position, Quaternion.LookRotation(aimDirection, Vector3.up));
            _input.shot = false;
        }
    }

    private void AimState(float aimValue, float sensitivity, bool crosshairEnabled, bool rotateOnMove)
    {
        _personFollowComponent.m_Lens.FieldOfView = aimValue;
        _thirdPersonController.SetSensitivity(sensitivity);
        _thirdPersonController.SetRotateOnMove(rotateOnMove);
        _crosshair.enabled = crosshairEnabled;
    }
}