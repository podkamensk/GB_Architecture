
internal interface ISemiWeapon : IWeapon
{
    public float Cooldown { get; set; }
    public int BurstSeries { get; set; }
    public float BurstRate { get; set; }

    public void CooldownCountdown(float deltaTime);
}