internal interface ICanSteer
{
    public float TurnSpeed {get; set;}
    public float TiltSpeed { get; set; }
    public float RollSpeed { get; set; }
    void Tilt(float ang_speed);
    void Turn(float ang_speed);
    void Roll(float ang_speed);
}