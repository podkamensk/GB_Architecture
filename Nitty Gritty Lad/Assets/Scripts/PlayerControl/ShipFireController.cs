using UnityEngine;

internal sealed class ShipFireController : IExecute
{
    //Checks if Thrust button is on and Turns Thrustes On
    private bool _pressedFire;
    private bool _pressedFireSec;
    private IControllableUnit _controlledVessel;

    public ShipFireController(IControllableUnit vessel)
    {
        _controlledVessel = vessel;
    }

    public void Execute(float deltaTime)
    {
        GetInput();
        PrimaryFireControl(_controlledVessel);
        SecondaryFireControl(_controlledVessel);
    }
    public void GetInput()
    {
        //Get input for the primary fire (held down) - automaitc
        if (Input.GetMouseButton(0))
        {
            _pressedFire = true;
        }
        else
        {
            _pressedFire = false;
        }
        //Get input for the secondary fire (pressed down) - semi automatic
        if (Input.GetMouseButtonDown(1))
        {
            _pressedFireSec = true;
        }
    }

    public void PrimaryFireControl(IControllableUnit controlledVessel)
    {
        if (_pressedFire)
        {
            controlledVessel.Fire();
        }
            
    }

    public void SecondaryFireControl(IControllableUnit controlledVessel)
    {
        if (_pressedFireSec)
        {
            controlledVessel.SecondaryFire();
            _pressedFireSec = false;
        }

    }
}
