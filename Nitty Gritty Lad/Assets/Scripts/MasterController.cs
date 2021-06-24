using UnityEngine;

    public sealed class MasterController : MonoBehaviour
    {
        [SerializeField] private UnitData _unitData;
        [SerializeField] private WeaponData _weaponData;
        [SerializeField] private AmmoData _ammoData;
        [SerializeField] private Settings _allSettings;
        private Controllers _allControllers;
        
        private void Start()
        {
            Debug.Log("Starting Master Controller");
            _allControllers = new Controllers();
            new GameInit(_allControllers, _unitData, _weaponData, _ammoData, _allSettings);
            _allControllers.Init();
        }

        private void Update()
        {
             //Debug.Log("Updateing Master Controller");
             _allControllers.Execute(Time.deltaTime);
        }

        private void LateUpdate()
        {
            _allControllers.LateExecute(Time.deltaTime);
        }

        private void OnDestroy()
        {
            _allControllers.CleanUp();
        }
    }
