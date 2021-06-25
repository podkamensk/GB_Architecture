using UnityEngine;

[CreateAssetMenu(fileName = "CannonData", menuName = "Data/Weapon/CannonData")]
public class CannonData : ScriptableObject
{
    [SerializeField] public AmmoType _ammoType;
    [SerializeField] public float _cooldown;
    [SerializeField] public int _burstSeries;
    [SerializeField] public int _burstCount;
    [SerializeField] public float _burstRate;
}
