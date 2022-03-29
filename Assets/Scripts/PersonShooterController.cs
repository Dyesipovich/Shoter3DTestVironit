using System;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.UI;

public class PersonShooterController : MonoBehaviour
{
    public static event Action<Vector3> WeaponTriggerPressed;
    public static event Action WeaponReloding;

    [SerializeField] private CinemachineVirtualCamera _personFollowComponent;

    [SerializeField] private float _aimIdle = 25f;
    [SerializeField] private float _aimApproximation = 15f;

    [SerializeField] private float _idleSensitivity = 1f;
    [SerializeField] private float _aimSensitivity = 0.5f;

    [SerializeField] private LayerMask _aimColliderLayerMask = new LayerMask();

    [SerializeField] private Image _crosshair;

    [SerializeField] private float _smoothnessTurningToCrosshair = 1f;

    private StarterAssetsInputs _input;
    private ThirdPersonController _thirdPersonController;
    private bool _isReload = true;

    private void Awake()
    {
        _input = GetComponent<StarterAssetsInputs>();
        _thirdPersonController = GetComponent<ThirdPersonController>();
        Firearms.CanReload += OnCanReload;
    }

    private void FixedUpdate()
    {
        AimShooting();
        ReloadingWeapon();
    }

    private void AimShooting()
    {
        if (_input.aim && _isReload)
        {
            Vector3 mouseWorldPosition = Vector3.zero;
            Vector2 screenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
            Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, 500f, _aimColliderLayerMask))
            {
                mouseWorldPosition = raycastHit.point;
            }

            AimState(_aimApproximation, _aimSensitivity, true, false);
            
            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;
            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * _smoothnessTurningToCrosshair);

            Shoot(mouseWorldPosition);

        }
        else
        {
            AimState(_aimIdle, _idleSensitivity, false, true);
        }
    }

    private void Shoot (Vector3 mouseWorldPosition)
    {
        if (!_input.shoot || !_input.aim) return;
        WeaponTriggerPressed?.Invoke(mouseWorldPosition);
        _input.shoot = false;
    }

    private void ReloadingWeapon()
    {
        if (_input.weaponReloading && _isReload)
        {
            WeaponReloding?.Invoke();
        }
    }

    private void OnCanReload(bool flag) => _isReload = flag;

    private void AimState(float aimValue, float sensitivity, bool crosshairEnabled, bool rotateOnMove)
    {
        _personFollowComponent.m_Lens.FieldOfView = aimValue;
        _thirdPersonController.SetSensitivity(sensitivity);
        _thirdPersonController.SetRotateOnMove(rotateOnMove);
        _crosshair.enabled = crosshairEnabled;
    }

    private void OnDestroy()
    {
        Firearms.CanReload -= OnCanReload;
    }
}
