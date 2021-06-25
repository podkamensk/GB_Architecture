using UnityEngine;
using System.IO;

[CreateAssetMenu(fileName = "Settings", menuName = "Settings/AllSettings")]
public sealed class Settings : ScriptableObject
//The class proveds acces to the settings (e.g. Camera Settings)
{
    [SerializeField] private string _cameraSettingsPath;
    private CameraSettings _cameraSet;

    public CameraSettings CameraSet
    {
        get
        {
            //if (_playerDat == null)
            //{
            _cameraSet = Load<CameraSettings>("Settings/" + _cameraSettingsPath);
            //}

            return _cameraSet;
        }
    }

    //Clearly I don't understand this syntax
    private T Load<T>(string resourcesPath) where T : Object =>
    Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
}
