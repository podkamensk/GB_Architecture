using UnityEngine;

internal interface IControllableUnit : ICanSteer, ICanThrust, ICanFire
{
    public Vector3 Accelerations { get; set; }
    public Vector3 Velocities { get; set; }

    void MakeMeKinematic();
    void MagicAirBreak(float reductor);
}
