using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class ObjectPool
{

    private readonly Stack<GameObject> _stack = new Stack<GameObject>();
    private readonly GameObject _prefab;

    public ObjectPool(GameObject prefab)
    {
        _prefab = prefab;
    }

    public void Push(GameObject go)
    {
        _stack.Push(go);
        go.SetActive(false);
    }

    public GameObject Pop()
    //checks if there are any GameObjects in the stack. If yes, pops from it. If no, creates new GameObject.
    {
        GameObject go;
        if (_stack.Count == 0)
        {
            go = Object.Instantiate(_prefab);
        }
        else
        {
            go = _stack.Pop();
        }
        go.SetActive(true);

        return go;
    }

}
