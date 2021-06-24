using UnityEngine;

internal sealed class ShipController : IExecute
//combines Steer. Thrust and Fire controllers in one Controller to be initialized in GameInit
{
    private ShipRotationController _shipSteerController;
    private ShipThrustController _shipThrustController;
    private ShipFireController _shipFireController;

    public ShipController(IControllableUnit player)
    {
        _shipSteerController = new ShipRotationController(player);
        _shipThrustController = new ShipThrustController(player);
        _shipFireController = new ShipFireController(player);
    }

    public void Execute(float deltaTime)
    {
        _shipSteerController.Execute(Time.deltaTime);
        _shipThrustController.Execute(Time.deltaTime);
        _shipFireController.Execute(Time.deltaTime);
    }
}
