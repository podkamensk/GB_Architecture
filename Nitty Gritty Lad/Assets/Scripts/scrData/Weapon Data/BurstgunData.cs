using UnityEngine;

[CreateAssetMenu(fileName = "BurstgunData", menuName = "Data/Weapon/BurstgunData")]
public class BurstgunData : ScriptableObject
{
    [SerializeField] public float _fireRate;
    [SerializeField] public int _burstCount;
    [SerializeField] public AmmoType _ammoType;
    [SerializeField] public float _angleDeviation;
}
