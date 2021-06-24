using UnityEngine;


internal sealed class GameInit
{
    public GameInit(Controllers controllers, UnitData unitdata, WeaponData wpndata, AmmoData ammodata, Settings settings)
    {
        //Getting rid of annoying cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


        Camera camera = Camera.main;                                             //Initializing The Camera
        var poolingService = new ViewServices();                                 //Init Prefabs Pooling
        var ammoController = new AmmoController(poolingService, ammodata);
        var playerFactory = new PlayerFactory(unitdata.PlayerDat, wpndata, ammoController);      //Initializing Player Factory
        var playerInit = new PlayerInit(playerFactory);                         //Initializing The PlayerInitilaizer
        //var enemyFactory = new EnemyFactory(data.Enemy);
        //var enemyInitialization = new EnemyInitialization(enemyFactory); = new ViewServices();
        

        //Adding IContoller controllers to the respective lists of Controllers Class
        controllers.Add(playerInit.GetPlayer());
        controllers.Add(new ShipController((IControllableUnit)playerInit.GetPlayer()));
        //controllers.Add(enemyInitialization);
        //controllers.Add(new EnemyMoveController(enemyInitialization.GetMoveEnemies(), playerInitialization.GetPlayer()));
        controllers.Add(new CameraController(playerInit.GetPlayer().Transform, camera.transform, settings.CameraSet));
        controllers.Add(ammoController);
    }
}
