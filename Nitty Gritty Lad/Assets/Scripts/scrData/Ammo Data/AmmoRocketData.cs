using UnityEngine;

[CreateAssetMenu(fileName = "AmmoRocketData", menuName = "Data/Ammo/AmmoRocketData")]
public sealed class AmmoRocketData : ScriptableObject
{
    [SerializeField] public AmmoType _ammoType;
    [SerializeField] public GameObject _prefab;

    [SerializeField] public float _velocity;
    [SerializeField] public float _lifeSpan;
    [SerializeField] public float _baseDamage;

    [SerializeField] public float _activationTime;
    [SerializeField] public float _turnSpeed;
}