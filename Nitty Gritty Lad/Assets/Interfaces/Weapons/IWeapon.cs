using UnityEngine;
internal interface IWeapon : IInit, IExecute, ICleanUp
{
    public AmmoType AmmoType { get; set; }
    public int BurstCount { get; set; }
    public AmmoController AmmoController { get; set; }
    public void WeaponTriggerOn(Vector3 gunportTransform);

    public void Shoot(Vector3 gunport, int numbullets, float angleDeviation);
}
