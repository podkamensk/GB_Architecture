
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Unit/PlayerData")]
public sealed class PlayerData : ScriptableObject
{
    [SerializeField] public Transform _prefab;

    [SerializeField] public Vector3 _coordinates;

    [SerializeField] public float _maxVel;
    [SerializeField] public float _turnSpeed;
    [SerializeField] public float _tiltSpeed;
    [SerializeField] public float _rollSpeed;

    [SerializeField] public float _massTotal;
    [SerializeField] public float _thrustersForce;
    [SerializeField] public float _hullHP;


}
