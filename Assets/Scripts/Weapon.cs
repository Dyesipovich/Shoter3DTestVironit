using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected int _damage;
    [SerializeField] protected AudioSource _audioSource;
    [SerializeField] protected MusicScriptableObject MusicScriptableObject;
    public abstract void DealingDamage(Vector3 mouseWorldPosition);

    protected virtual void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
}
