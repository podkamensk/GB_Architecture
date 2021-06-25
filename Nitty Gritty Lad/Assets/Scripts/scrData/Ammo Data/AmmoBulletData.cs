using UnityEngine;

[CreateAssetMenu(fileName = "AmmoBulletData", menuName = "Data/Ammo/AmmoBulletData")]
public sealed class AmmoBulletData : ScriptableObject
{
    [SerializeField] public AmmoType _ammoType;
    [SerializeField] public GameObject _prefab;

    [SerializeField] public float _velocity;
    [SerializeField] public float _lifeSpan;
    [SerializeField] public float _baseDamage;

}