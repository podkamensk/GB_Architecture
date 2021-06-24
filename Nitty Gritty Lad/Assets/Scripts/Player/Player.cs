
using UnityEngine;

internal class Player : IPlayer, IHealth
{

   // private Vector3 _coordinates;
   // private Vector3 _velocities;
   // private Vector3 _accelerations;

    private float _mass;
    private float _turnSpeed;
    private float _tiltSpeed;
    private float _rollSpeed;
    private float _thrustersForce;

    private IWeapon _primaryWeapon;
    private IWeapon _secondaryWeapon;

    private Vector3 _primaryGunport;
    private Vector3 _secondaryGunport;

    public Transform Transform { get; set; }
    public IWeapon PrimaryWeapon { get; set; }
    public IWeapon SecondaryWeapon { get; set; }
    public Vector3 Accelerations { get; set; }
    public Vector3 Velocities { get; set; }
    public Vector3 Coordinates { get; set; }
    public float Mass { get; set; }
    public float TurnSpeed { get => _turnSpeed; set => _turnSpeed = value; }
    public float TiltSpeed { get => _tiltSpeed; set => _tiltSpeed = value; }
    public float RollSpeed { get => _rollSpeed; set => _rollSpeed = value; }
    public float ThrustersForce { get; set; }
    

    public Player(Vector3 coord, Transform prefab)
    {
        Coordinates = coord;
        Transform = Object.Instantiate(prefab, coord, Quaternion.identity);
        _primaryGunport = Transform.position;   //Later this to be taken from prefab OR from the asset data
        _secondaryGunport = Transform.position;   //Later this to be taken from prefab OR from the asset data
    }

    public void Execute(float deltaTime)
    {
        MagicAirBreak(0.998f);     //Magic number. Later will be passed to physics
        MakeMeKinematic();
        WeaponUpdate(deltaTime);
    }

    public void Init()
    {
        
    }


    public void Tilt(float ang_speed)
    {
        Transform.Rotate(Vector3.right, ang_speed * Time.deltaTime);
    }

    public void Turn(float ang_speed)
    {
        Transform.Rotate(Vector3.up, ang_speed * Time.deltaTime);
    }

    public void Roll(float ang_speed)
    {
        Transform.Rotate(Vector3.forward, ang_speed * Time.deltaTime);
    }

    public void ThrustersOn()
    {
        Accelerations += Transform.forward * ThrustersForce/Mass * Time.deltaTime;
    }

    public void Fire()
    {
        if (PrimaryWeapon != null)
        {
            PrimaryWeapon.WeaponTriggerOn(_primaryGunport);
            Debug.Log($"Primary Trigger Pushed ({PrimaryWeapon})");
        }
    }

    public void SecondaryFire()
    {
        Debug.Log(SecondaryWeapon);
        if (SecondaryWeapon != null)
        {
            SecondaryWeapon.WeaponTriggerOn(_secondaryGunport);
            Debug.Log($"Sceondary Trigger Pushed ({SecondaryWeapon})");
        }

    }

    public void MakeMeKinematic()
    {
        Velocities += Accelerations;
        Accelerations *= 0f;
        Coordinates += Velocities;
        Transform.position = Coordinates;
    }

    public void MagicAirBreak(float reductor)
    {
        if (Accelerations.magnitude == 0)
        {
            Velocities *= reductor;// * Time.deltaTime;   need to ue PWR of Log
        }
    }

    public void WeaponUpdate(float deltaTime)
    {
        if (PrimaryWeapon != null)
        {
            PrimaryWeapon.Execute(deltaTime);
            _primaryGunport = Transform.position;
        }
        if (SecondaryWeapon != null)
        {
            SecondaryWeapon.Execute(deltaTime);
            _secondaryGunport = Transform.position;
        }
    }
}
