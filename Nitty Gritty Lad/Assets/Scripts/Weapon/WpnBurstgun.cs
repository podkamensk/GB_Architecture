using UnityEngine;

sealed internal class WpnBurstgun : Weapon, IAutoWeapon
{
    private float _fireRate;
    private float _fireTimer;
    private float _angleDeviation;
    private int _burstCount;
    private AmmoType _ammoType;
    public float FireRate { get => _fireRate; set => _fireRate = value; }
    public int BurstCount { get => _burstCount; set => _burstCount = value; }
    public float AngleDeviation { get => _angleDeviation; set => _angleDeviation = value; }
    public AmmoType AmmoType { get => _ammoType; set => _ammoType = value; }
    public AmmoController AmmoController { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public WpnBurstgun(BurstgunData data)
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
    {
        if (_fireTimer <= 0)
        {
            Shoot(gunport, _burstCount, _angleDeviation);
            _fireTimer = _fireRate;
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
        Debug.Log("Burstgun Bannng");
    }
}