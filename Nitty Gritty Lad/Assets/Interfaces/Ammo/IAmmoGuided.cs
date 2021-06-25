internal interface IAmmoGuided : IAmmo
{
    public IUnit TargetClass { get; set; }
    public IUnit Target { get; set; }
    public float ActivationTime { get; set; }
    public float TurnSpeed { get; set; }


}