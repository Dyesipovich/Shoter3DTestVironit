using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text _idleHealth;
    [SerializeField] private TMP_Text _health;
    [SerializeField] private TMP_Text _allBullets;
    [SerializeField] private TMP_Text _idleBulletsClip;
    [SerializeField] private TMP_Text _bulletsCount;
    [SerializeField] private TMP_Text FirstTeameScore;
    [SerializeField] private TMP_Text SecondTeameScore;
    
    private readonly string _line = "/";

    private void Awake()
    {
        PersonHealthCharacteristics.HelthStartInitialize += OnHelthInitialize;
        Firearms.BulletStartInitialize += OnBulletInitialize;
        Firearms.BulletsCountChange += OnBulletsCountChange;
        Firearms.ReloadingWeapon += OnReloadingWeapon;
        PersonHealthCharacteristics.HelthChange += OnHealthChange;
    }

    private void OnHelthInitialize(int health)
    {
        _idleHealth.text = health.ToString() + _line;
        _health.text = _idleHealth.text;
    }
    private void OnHealthChange(int damage)
    {

    }

    private void OnBulletInitialize(int allBullets, int bulletsCount, int maxBulletInClip)
    {
        _allBullets.text = allBullets.ToString();
        _idleBulletsClip.text = _line + maxBulletInClip.ToString();
        _bulletsCount.text = bulletsCount.ToString();
    }

    private void OnBulletsCountChange(int bulletsCount)
    {
        _bulletsCount.text = bulletsCount.ToString();
    }
    private void OnReloadingWeapon (int allBullets, int bulletsCount)
    {
        _allBullets.text = allBullets.ToString();
        _bulletsCount.text = bulletsCount.ToString ();
    }

    private void OnDestroy()
    {
        PersonHealthCharacteristics.HelthStartInitialize -= OnHelthInitialize;
        Firearms.BulletStartInitialize -= OnBulletInitialize;
        Firearms.BulletsCountChange -= OnBulletsCountChange;
        Firearms.ReloadingWeapon -= OnReloadingWeapon;
    }
}
