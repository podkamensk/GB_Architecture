using UnityEngine;

internal sealed class ShipThrustController : IExecute
{
//Checks if Thrust button is on and Turns Thrustes On
    private bool _pressedThrust;
    private IControllableUnit _controlledVessel;

    public ShipThrustController(IControllableUnit vessel)
    {
        _controlledVessel = vessel;
    }


    public void Execute(float deltaTime)
    {
        GetInput();
        TrhustControl(_controlledVessel);
    }

    public void GetInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _pressedThrust = true;
        }
        else
        {
            _pressedThrust = false;
        }
    }

    public void TrhustControl(IControllableUnit controlledVessel)
    {
        if (_pressedThrust)
            controlledVessel.ThrustersOn();
    }
}