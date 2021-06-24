using UnityEngine;

[CreateAssetMenu(fileName = "RocketLauncherData", menuName = "Data/Weapon/RocketLauncherData")]
public class RocketLauncherData : ScriptableObject
{
    [SerializeField] public AmmoType _ammoType;
    [SerializeField] public float _cooldown;
    [SerializeField] public int _burstSeries;
    [SerializeField] public int _burstCount;
    [SerializeField] public float _burstRate;
}
