using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class CameraController : ILateExecute
{
    private readonly Transform _followTarget;
    private readonly Transform _camera;
    private Vector3 _toTarget;
    private float _distanceToTarget;
    private float _heightToTarget;
    private float _followSharpness;

    public CameraController(Transform player, Transform mainCamera, CameraSettings camSettings)
    {
        _followTarget = player;
        _camera = mainCamera;
        _toTarget = _followTarget.rotation * new Vector3(0f, _heightToTarget, -_distanceToTarget);
        //getting the settings from assets
        _distanceToTarget = camSettings._distanceToTarget;
        _heightToTarget = camSettings._heightToTarget;
        _followSharpness = camSettings._followSharpness;

    }

    public void LateExecute(float deltaTime)
    {
        _toTarget = _followTarget.rotation * new Vector3(0f, _heightToTarget, -_distanceToTarget);
        Vector3 relocate = _followTarget.position + _toTarget;
        _camera.position = Vector3.Slerp(_camera.position, relocate, _followSharpness);
        _camera.rotation = _followTarget.rotation;
    }
}
