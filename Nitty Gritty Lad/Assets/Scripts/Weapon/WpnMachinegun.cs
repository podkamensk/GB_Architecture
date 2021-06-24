using UnityEngine;

sealed internal class WpnMachinegun : Weapon, IAutoWeapon
{

    private float _fireTimer;
    public float FireRate { get; set; }
    public int BurstCount { get; set; }
    public float AngleDeviation { get; set; }
    public AmmoType AmmoType { get; set; }

    public AmmoController AmmoController { get; set; }

    public WpnMachinegun(MachinegunData data)   //Initializing Weapon's class from its asset data
    {
        FireRate = data._fireRate;
        _fireTimer = 0;
        BurstCount = data._burstCount;
        AmmoType = data._ammoType;
        AngleDeviation = data._angleDeviation;
    }

    public void Init()
    {
    }
    public void Execute(float deltaTime)
    {
        FireTimerCountdown(deltaTime);
    }

    public void CleanUp()
    {
    }
    public void WeaponTriggerOn(Vector3 gunport)
    //Fire if firerate allows
    {
        if (_fireTimer <= 0)
        {
            Shoot(gunport, BurstCount, AngleDeviation);
            _fireTimer = FireRate;
        }
    }

    public void FireTimerCountdown(float deltaTime)
    //maintains fire rate of the automatic weapon
    {
        if (_fireTimer > 0)
            _fireTimer -= deltaTime;
    }

    public void Shoot(Vector3 gunport, int numbullets, float angleDeviation)
    //generates Burst number of Ammos
    {
        for (int i = 0; i < numbullets; i += 1)
        {
            // exitpoint.Rotate(exitpoint.up, Random.Range(-angleDeviation, angleDeviation));  //There should be math for trajectory threshold
            // exitpoint.Rotate(exitpoint.forward, Random.Range(-90, 90));
            Debug.Log("pew-pew-pew");
            AmmoController.CreateAmmo(AmmoType, gunport);
        }
    }
}
