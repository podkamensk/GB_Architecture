using UnityEngine;

[CreateAssetMenu(fileName = "MachinegunData", menuName = "Data/Weapon/MachinegunData")]
public class MachinegunData : ScriptableObject
{
    [SerializeField] public AmmoType _ammoType;
    [SerializeField] public float _fireRate;
    [SerializeField] public int _burstCount;
    
    [SerializeField] public float _angleDeviation;
}
