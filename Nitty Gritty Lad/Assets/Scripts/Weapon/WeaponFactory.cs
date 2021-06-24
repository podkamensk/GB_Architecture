using UnityEngine;

internal sealed class WeaponFactory : IWeaponFactory
// Factory which creates Player
{

    private readonly WeaponData _weaponData;
    private AmmoController _ammoController;

    public WeaponFactory(WeaponData data, AmmoController ammoController)
    {
        _weaponData = data;
        _ammoController = ammoController;
    }

    public IWeapon Create(WeaponType type)
    {
        IWeapon wpn;
        switch (type)
        {
            case WeaponType.machinegun:
                wpn = new WpnMachinegun(_weaponData.MachinegunDat);
                break;
            case WeaponType.burstgun:
                wpn = new WpnBurstgun(_weaponData.BurstgunDat);
                break;
            case WeaponType.cannon:
                wpn = new WpnCannon(_weaponData.CannonDat);
                break;
            case WeaponType.rocketlauncher:
                wpn = new WpnRocketLauncher(_weaponData.RocketLauncherDat);
                break;
            default:
                wpn = null;
                return wpn;
        }
        wpn.AmmoController = _ammoController;
        return wpn;
    }
}
