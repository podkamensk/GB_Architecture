using UnityEngine;
sealed internal class WpnRocketLauncher : Weapon, ISemiWeapon
{
    private float _cooldown;
    private float _cooldownTimer;
    private int _burstSeries;
    private int _burstSeriesCount;
    private int _burstCount;
    private float _burstRate;
    private float _burstRateTimer;
    private AmmoType _ammoType;
    private bool _seriesAway;
    private Vector3 _tempGunport;


    public float Cooldown { get => _cooldown; set => _cooldown = value; }
    public int BurstSeries { get => _burstSeries; set => _burstSeries = value; }
    public int BurstCount { get => _burstCount; set => _burstCount = value; }
    public float BurstRate { get => _burstRate; set => _burstRate = value; }
    public AmmoType AmmoType { get => _ammoType; set => _ammoType = value; }
    public AmmoController AmmoController { get; set ; }

    public WpnRocketLauncher(RocketLauncherData data)
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
            _cooldownTimer = _cooldown;
            _tempGunport = gunport;
        }
    }

    public void SeriesAway(Vector3 gunport)
    {
        if (_burstSeriesCount < _burstSeries)
        {
            if (_burstRateTimer <= 0)
            {
                Shoot(gunport, _burstCount, 0f);
                _burstCount += 1;
                _burstRateTimer = _burstRate;
            }
            if (_burstSeriesCount >= _burstSeries)
            {
                _seriesAway = false;
                _burstCount = 0;
            }
        }
    }


    public void CooldownCountdown(float deltaTime)
    {
        if (_cooldownTimer > 0)
            _cooldownTimer -= deltaTime;
        if (_burstRateTimer > 0)
            _burstRateTimer -= deltaTime;
    }

    public void Shoot(Vector3 gunport, int numbullets, float angleDeviation)
    {
        Debug.Log("Rockets Wshooooh!");
    }
}