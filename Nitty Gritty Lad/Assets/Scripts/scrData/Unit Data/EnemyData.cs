using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Data/Unit/EnemyData")]
public sealed class EnemyData : ScriptableObject
{
    [Serializable]
    private struct EnemyInfo
    {
        public EnemyType Type;
        public EnemyProvider EnemyPrefab;
    }

    [SerializeField] private List<EnemyInfo> _enemyInfos;

    public EnemyProvider GetEnemy(EnemyType type)
    {
        var enemyInfo = _enemyInfos.First(info => info.Type == type);
        return enemyInfo.EnemyPrefab;
    }
}