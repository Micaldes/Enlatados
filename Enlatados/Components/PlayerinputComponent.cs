using Raylib_cs;
using System;
using System.Numerics;
using Enlatados.Components;

using Component = Enlatados.Components.Entities.Component;
public class PlayerInputComponent : Component, IInputComponent
{
    public Vector2 mousePos { get; set; }

    public PlayerInputComponent(GameObject owner) : base(owner){}

    public void Input()
    {
        mousePos = Raylib.GetMousePosition(); //En cada iteracion se actualiza la posicion del mouse
    }
}
