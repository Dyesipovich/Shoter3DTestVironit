using System;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.UI;

public class PersonShooterController : MonoBehaviour
{
    public static event Action<Vector3> WeaponTriggerPressed;

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

    private void Awake()
    {
        _input = GetComponent<StarterAssetsInputs>();
        _thirdPersonController = GetComponent<ThirdPersonController>();
    }

    private void FixedUpdate()
    {
        AimShooting();
    }

    private void AimShooting()
    {
        if (_input.aim)
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

    private void AimState(float aimValue, float sensitivity, bool crosshairEnabled, bool rotateOnMove)
    {
        _personFollowComponent.m_Lens.FieldOfView = aimValue;
        _thirdPersonController.SetSensitivity(sensitivity);
        _thirdPersonController.SetRotateOnMove(rotateOnMove);
        _crosshair.enabled = crosshairEnabled;
    }
}
