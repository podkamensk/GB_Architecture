using UnityEngine;
sealed internal class WpnCannon : Weapon, ISemiWeapon
{
    private float _cooldownTimer;
    private int _burstSeriesCount;
    private float _burstRateTimer;
    private bool _seriesAway;
    private Vector3 _tempGunport;


    public float Cooldown { get; set; }
    public int BurstSeries { get; set; }
    public int BurstCount { get; set; }
    public float BurstRate { get; set; }
    public AmmoType AmmoType { get; set; }
    public AmmoController AmmoController { get; set; }

    public WpnCannon(CannonData data)
    {
        AmmoType = data._ammoType;
        Cooldown = data._cooldown;
        _cooldownTimer = 0;
        BurstSeries = data._burstSeries;
        _burstSeriesCount = 0;
        BurstCount = data._burstCount;
        BurstRate = data._burstRate;
        _burstRateTimer = 0;
        _seriesAway = false;
    }
    public void Init()
    {
    }

    public void Execute(float deltaTime)
    //maintains cooldown rate of the automatic weapon
    {
        CooldownCountdown(deltaTime);
        if (_seriesAway)
            SeriesAway(_tempGunport);
    }

    public void CleanUp()
    {
    }

    public void WeaponTriggerOn(Vector3 gunport)
    {
        if (_cooldownTimer <= 0 && _seriesAway == false)
        {
            _seriesAway = true;
            _cooldownTimer = Cooldown;
            _tempGunport = gunport;
        }
    }

    public void SeriesAway(Vector3 gunport)
    //Happens during series of shooting. Then turns series away to false
    {
        if (_burstSeriesCount < BurstSeries)
        {
            if (_burstRateTimer <= 0)
            {
                Shoot(gunport, BurstCount, 0f);
                _burstSeriesCount += 1;
                _burstRateTimer = BurstRate;
            }
        }
        else
        {
            _seriesAway = false;
            _burstSeriesCount = 0;
        }
    }


    public void CooldownCountdown(float deltaTime)
    //reduces intershot and reload cooldown timers
    {
        if (_cooldownTimer > 0)
            _cooldownTimer -= deltaTime;
        if (_burstRateTimer > 0)
            _burstRateTimer -= deltaTime;
    }

    public void Shoot(Vector3 gunport, int numbullets, float angleDeviation)
    {
    //Creates ammo of certain type and certain
        AmmoController.CreateAmmo(AmmoType, gunport);
        Debug.Log("Cannon Bam!");
    }
}