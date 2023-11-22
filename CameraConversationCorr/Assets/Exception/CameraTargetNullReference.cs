using System;

public class CameraTargetNullReference : NullReferenceException
{
    public override string Message => "Camera missing target: null reference exception";
}
