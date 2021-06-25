using System.Collections;
using System.Collections.Generic;
using UnityEngine;

sealed internal class AmmoController : IExecute
{
    private List<IAmmo> _ammoFlying;
    private AmmoData _ammoData;
    public static AmmoController RefAmmoController {get; private set; }  //Static singleton

    public ViewServices ViewServices { get; set; }

    public AmmoController(ViewServices viewService, AmmoData ammoData)
    {
        _ammoFlying = new List<IAmmo>();
        ViewServices = viewService;
        _ammoData = ammoData;
    }

    public void Init()
    {
    }

    public void Execute(float deltaTime)
    {
       foreach(Ammo ammo in _ammoFlying)
        {
          ammo.Execute(Time.deltaTime);
        }
    }

    public void CleanUp()
    {
    }

    public void CreateAmmo(AmmoType ammoType, Vector3 direction)
    {
        IAmmo proj;
        switch (ammoType)
        {
            case AmmoType.Bullet:
                proj = new AmmoBullet(direction);
                proj.Velocity = _ammoData.AmmoBulletDat._velocity;
                proj.LifeSpan = _ammoData.AmmoBulletDat._lifeSpan;
                proj.BaseDamage = _ammoData.AmmoBulletDat._baseDamage;
                proj.Transform = _ammoData.AmmoBulletDat._prefab.transform;    //TEST
                AddToAmmoController(proj);
                Debug.Log("Bullet Created");
                break;
            case AmmoType.Shell:
                proj = new AmmoShell(direction);
                proj.Velocity = _ammoData.AmmoShellDat._velocity;
                proj.LifeSpan = _ammoData.AmmoShellDat._lifeSpan;
                proj.BaseDamage = _ammoData.AmmoShellDat._baseDamage;
                proj.Transform = _ammoData.AmmoShellDat._prefab.transform;    //TEST
                AddToAmmoController(proj);
                Debug.Log("Shell Created");
                break;
            case AmmoType.Rocket:
                Debug.Log("Rockets are in progress");
                //AddToAmmoController(proj);
                //Debug.Log("Rocket Created");
                break;
            default:
                break;
        }
    }

    public void AddToAmmoController(IAmmo proj)
    {
        _ammoFlying.Add(proj);
    }
    public void RemoveFromAmmoController(IAmmo proj)
    {
        _ammoFlying.Remove(proj);   //???? Doesn't work well. Find by index? (((
    }
}
