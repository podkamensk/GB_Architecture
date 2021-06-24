using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class ViewServices
{

    private readonly Dictionary<int, ObjectPool> _viewCache = new Dictionary<int, ObjectPool>(capacity: 16);

    public void Create(GameObject prefab)
    //checks if there is a pool for this prefab. if not, creates it. Then Pops GameObject from relevant stack (ViewPool)
    {
        if (!_viewCache.TryGetValue(prefab.GetInstanceID(), out ObjectPool viewPool))
        {
            viewPool = new ObjectPool(prefab);
            _viewCache[prefab.GetInstanceID()] = viewPool;
        }

        viewPool.Pop();
    }

    public void Destroy(GameObject prefab)
    //pushes gameobject to relevant Pool
    {
        _viewCache[prefab.GetInstanceID()].Push(prefab);
    }






}
