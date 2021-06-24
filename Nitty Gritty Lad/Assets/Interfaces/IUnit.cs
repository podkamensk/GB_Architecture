using UnityEngine;
internal interface IUnit : IExecute
{
    Vector3 Coordinates { get; set; }
    Transform Transform { get; set; }

    float Mass { get; set; }
    
}
