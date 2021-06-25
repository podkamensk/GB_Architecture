using UnityEngine;
using System.IO;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Data/WeaponData")]
public sealed class WeaponData : ScriptableObject

{
    [SerializeField] private string _machinegunDataPath;
    [SerializeField] private string _burstgunDataPath;
    [SerializeField] private string _cannonDataPath;
    [SerializeField] private string _rocketLauncherDataPath;
    private MachinegunData _machinegunDat;
    private BurstgunData _burstgunDat;
    private CannonData _cannonDat;
    private RocketLauncherData _rocketLauncherDat;


    public MachinegunData MachinegunDat
    {
        get
        {
            if (_machinegunDat == null)
            {
                _machinegunDat = Load<MachinegunData>("Data/" + _machinegunDataPath);
            }

            return _machinegunDat;
        }
    }

    public BurstgunData BurstgunDat
    {
        get
        {
            if (_burstgunDat == null)
            {
                _burstgunDat = Load<BurstgunData>("Data/" + _burstgunDataPath);
            }

            return _burstgunDat;
        }
    }

    public CannonData CannonDat
    {
        get
        {
            if (_cannonDat == null)
            {
                _cannonDat = Load<CannonData>("Data/" + _cannonDataPath);
            }

            return _cannonDat;
        }
    }

    public RocketLauncherData RocketLauncherDat
    {
        get
        {
            if (_rocketLauncherDat == null)
            {
                _rocketLauncherDat = Load<RocketLauncherData>("Data/" + _rocketLauncherDataPath);
            }

            return _rocketLauncherDat;
        }
    }



    //Clearly I don't understand this syntax
    private T Load<T>(string resourcesPath) where T : Object =>
    Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
}
