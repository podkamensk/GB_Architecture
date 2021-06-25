using UnityEngine;
using System.IO;

[CreateAssetMenu(fileName = "AmmoData", menuName = "Data/AmmoData")]
public sealed class AmmoData : ScriptableObject

{
    [SerializeField] private string _ammoBulletDataPath;
    [SerializeField] private string _ammoShellDataPath;
    [SerializeField] private string _ammoRocketDataPath;
    private AmmoBulletData _ammoBulletDat;
    private AmmoShellData _ammoShellDat;
    private AmmoRocketData _ammoRocketDat;

    public AmmoBulletData AmmoBulletDat
    {
        get
        {
            if (_ammoBulletDat == null)
            {
                _ammoBulletDat = Load<AmmoBulletData>("Data/" + _ammoBulletDataPath);
            }

            return _ammoBulletDat;
        }
    }

    public AmmoShellData AmmoShellDat
    {
        get
        {
            if (_ammoShellDat == null)
            {
                _ammoShellDat = Load<AmmoShellData>("Data/" + _ammoShellDataPath);
            }

            return _ammoShellDat;
        }
    }

    public AmmoRocketData AmmoRocketDat
    {
        get
        {
            if (_ammoRocketDat == null)
            {
                _ammoRocketDat = Load<AmmoRocketData>("Data/" + _ammoRocketDataPath);
            }

            return _ammoRocketDat;
        }
    }




    //Clearly I don't understand this syntax
    private T Load<T>(string resourcesPath) where T : Object =>
    Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
}
