using System;
using System.Numerics;

public interface IInputComponent
{
    public Vector2 mousePos { get; set; }

    public bool mouseLeftPressed {  get; set; }
    public void Input();

}
