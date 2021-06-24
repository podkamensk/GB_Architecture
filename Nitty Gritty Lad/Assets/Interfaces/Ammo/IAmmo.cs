using UnityEngine;

internal interface IAmmo
{
    public Transform Transform { set; }
    public Vector3 Direction { get; set; }
    public float Velocity { get; set; }
    public float LifeSpan { get; set; }
    public float BaseDamage { get; set; }
    public void Movement(float deltaTime);
    public void OnLifeSpanEnd();
}
