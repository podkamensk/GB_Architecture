using UnityEngine;

[CreateAssetMenu(fileName = "AmmoShellData", menuName = "Data/Ammo/AmmoShellData")]
public sealed class AmmoShellData : ScriptableObject
{
    [SerializeField] public AmmoType _ammoType;
    [SerializeField] public GameObject _prefab;

    [SerializeField] public float _velocity;
    [SerializeField] public float _lifeSpan;
    [SerializeField] public float _baseDamage;

}