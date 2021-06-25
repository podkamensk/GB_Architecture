using UnityEngine;

internal sealed class PlayerFactory : IUnitFactory
// Factory which creates Player
{

    private readonly PlayerData _playerData;
    private WeaponFactory _weaponFactory;
    public PlayerFactory(PlayerData playerData, WeaponData weaponData, AmmoController ammoController)
    {
        _playerData = playerData;
        _weaponFactory = new WeaponFactory(weaponData, ammoController);
    }

    public IUnit Create(WeaponType primaryType, WeaponType secondaryType)
    //creates the Player from asset file. Weapons are by default for now
    {
        Player player = new Player(_playerData._coordinates, _playerData._prefab);

        player.Mass = _playerData._massTotal;
        player.ThrustersForce = _playerData._thrustersForce;
        player.TurnSpeed = _playerData._turnSpeed;
        player.TiltSpeed = _playerData._tiltSpeed;
        player.RollSpeed = _playerData._rollSpeed;

        player.PrimaryWeapon = _weaponFactory.Create(primaryType);
        player.SecondaryWeapon = _weaponFactory.Create(secondaryType);

        return player;
    }
}
