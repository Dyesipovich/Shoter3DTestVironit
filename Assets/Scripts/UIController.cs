using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text _idleHealth;
    [SerializeField] private TMP_Text _health;
    [SerializeField] private TMP_Text _idleBullets;
    [SerializeField] private TMP_Text _idleBulletsClip;
    [SerializeField] private TMP_Text _bullets;
    [SerializeField] private TMP_Text FirstTeameScore;
    [SerializeField] private TMP_Text SecondTeameScore;

    private void Awake()
    {
        PersonHealthCharacteristics.HelthUIInitialize += OnHelthInitialize;
        Firearms.BulletUIInitialize += OnBulletInitialize;
    }

    private void OnHelthInitialize(int health)
    {
        _idleHealth.text = health.ToString();
        _health.text = _idleHealth.text;
    }

    private void OnBulletInitialize(int numberClips, int numberBulletsInClip)
    {
        int numberBullets = numberClips * numberBulletsInClip;
        _idleBullets.text = numberBullets.ToString();
        _idleBulletsClip.text = numberBulletsInClip.ToString();
        _bullets.text = _idleBullets.text;
    }

    private void OnDestroy()
    {
        PersonHealthCharacteristics.HelthUIInitialize -= OnHelthInitialize;
        Firearms.BulletUIInitialize -= OnBulletInitialize;
    }
}
