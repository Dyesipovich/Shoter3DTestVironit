using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField, Min(1)] private float _damage;
    public abstract void DealingDamage();
}
