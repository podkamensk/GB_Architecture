
using System;
using UnityEngine;

internal sealed class AmmoShell : Ammo, IAmmoTracing
{
    //private AmmoType _ammoType;
    private float _lifeSpanTimer;


    public Transform Transform { get; set; }
    public Vector3 Direction { get; set; }
    public float Velocity { get; set; }
    public float LifeSpan { get; set; }
    public float BaseDamage { get; set; }

    public AmmoShell(Vector3 direction)
    {
        //_ammoType = AmmoType.Shell;
        Direction = direction;
    }

    public override void Execute(float deltaTime)
    {
        Movement(deltaTime);
        LifeSpanControl(deltaTime);
    }

    public override void Init()
    {
        _lifeSpanTimer = LifeSpan;
    }

    public void Movement(float deltaTime)
    {
        Transform.position += new Vector3(0, 0, Velocity);   //some ridiculous math. Should be corrected
    }
    public void LifeSpanControl(float deltaTime)
    {
        LifeSpan -= deltaTime;
        if (LifeSpan <= 0)
        {
            OnLifeSpanEnd();
        }
    }

    public void OnLifeSpanEnd()
    {
    }

}