
internal interface IPlayer : IUnit, IControllableUnit
{

    public IWeapon PrimaryWeapon { get; set; }
    public IWeapon SecondaryWeapon { get; set; }

    public void WeaponUpdate(float deltaTime);

}
