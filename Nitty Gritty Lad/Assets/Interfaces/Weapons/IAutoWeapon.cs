
internal interface IAutoWeapon : IWeapon
{
    public float FireRate { get; set; }
    public float AngleDeviation { get; set; }

    public void FireTimerCountdown(float deltaTime);



}