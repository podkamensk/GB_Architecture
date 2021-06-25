using UnityEngine;

internal sealed class PlayerInit
{

    private readonly PlayerFactory _playerFactory;
    private IUnit _player;

    public PlayerInit(PlayerFactory playerFactory)//, Vector3 positionPlayer)
    {
        _playerFactory = playerFactory;
        _player = _playerFactory.Create(WeaponType.machinegun, WeaponType.cannon);   // default for now
    }

    public IUnit GetPlayer()
    {
        return _player;
    }

}
