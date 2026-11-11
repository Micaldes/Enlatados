using Raylib_cs;
using System;
using System.Numerics;
using Enlatados.Components;

public class PlayerinputComponent : IInputComponent
{
    private Player _player;
    public PlayerinputComponent(Player Player) { _player = Player; }
   // public Vector2 nextPos { get; set; }
    //Actualizar el componente de input en cada iteracion
    public void Input()
    {

        _player.mousePos = Raylib.GetMousePosition(); //En cada iteracion se actualiza la posicion del mouse
    }
}
