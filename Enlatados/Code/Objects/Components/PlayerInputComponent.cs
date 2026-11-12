using Raylib_cs;
using System;
using System.Numerics;
using Enlatados.Components;
using Enlatados.Code.Objects.Components;

public class PlayerInputComponent : Component, IInputComponent
{
    public Vector2 mousePos { get; set; }

    public bool mouseLeftPressed { get; set; }
    public PlayerInputComponent(GameObject owner) : base(owner){}

    public void Input()
    {
        mousePos = Raylib.GetMousePosition(); //En cada iteracion se actualiza la posicion del mouse
        
        if (Raylib.IsMouseButtonPressed(MouseButton.Left))
        {
            mouseLeftPressed = true;
            Owner.Parent.SendPlayerEvent(EventId.PlayerShoots);
        }
    }
}
