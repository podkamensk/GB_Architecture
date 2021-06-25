using System;
using UnityEngine;

[CreateAssetMenu(fileName = "CameraSettings", menuName = "Settings/CameraSettings")]
public sealed class CameraSettings : ScriptableObject
{

    [SerializeField] public float _distanceToTarget;
    [SerializeField] public float _heightToTarget;
    [SerializeField, Range(0.01f, 0.2f)] public float _followSharpness;

}