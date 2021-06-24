using UnityEngine;
using System.IO;

[CreateAssetMenu(fileName = "UnitData", menuName = "Data/UnitData")]
public sealed class UnitData : ScriptableObject
{
    [SerializeField] private string _playerDataPath;
    [SerializeField] private string _enemyDataPath;
    private PlayerData _playerDat;
    private EnemyData _enemyDat;


    public PlayerData PlayerDat
    {
        get
        {
            if (_playerDat == null)
            {
                _playerDat = Load<PlayerData>("Data/" + _playerDataPath);
            }

            return _playerDat;
        }
    }

    public EnemyData EnemyDat
    {
        get
        {
            if (_enemyDat == null)
            {
                _enemyDat = Load<EnemyData>("Data/" + _enemyDataPath);
            }

            return _enemyDat;
        }
    }

    //Clearly I don't understand this syntax
    private T Load<T>(string resourcesPath) where T : Object =>
    Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
}
