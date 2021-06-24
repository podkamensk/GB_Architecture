using UnityEngine;

internal sealed class ShipRotationController : IExecute
//checks if WSAD buttons are pressed and sends the command to Rotate transform
{
    private bool _pressedLeft;
    private bool _pressedRight;
    private bool _pressedUp;
    private bool _pressedDown;
    private IControllableUnit _controlledVessel;
    public ShipRotationController(IControllableUnit vessel)
    {
        _controlledVessel = vessel;
    }

    public void Execute(float deltaTime)
    {
        GetInput();
        Steer(_controlledVessel);
    }

    public void GetInput()
    {
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            _pressedLeft = true;
            _pressedRight = false;
        }

        else if (!Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            _pressedLeft = false;
            _pressedRight = true;
        }
        else
        {
            _pressedLeft = false;
            _pressedRight = false;
        }

        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            _pressedUp = true;
            _pressedDown = false;
        }

        else if (!Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
        {
            _pressedUp = false;
            _pressedDown = true;
        }
        else
        {
            _pressedUp = true;
            _pressedDown = true;
        }
    }

    public void Steer(IControllableUnit controlledVessel) 
    {
        if (_pressedUp)
            controlledVessel.Tilt(controlledVessel.TiltSpeed);
        if (_pressedDown)
            controlledVessel.Tilt(-controlledVessel.TiltSpeed);
        if (_pressedLeft)
            controlledVessel.Turn(-controlledVessel.TurnSpeed);
        if (_pressedRight)
            controlledVessel.Turn(controlledVessel.TurnSpeed);
    }
}
