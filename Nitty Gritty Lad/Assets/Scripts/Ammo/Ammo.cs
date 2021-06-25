
using UnityEngine;

internal abstract class Ammo : IInit, IExecute
{
    public abstract void Init();

    public abstract void Execute(float deltaTime);


}
