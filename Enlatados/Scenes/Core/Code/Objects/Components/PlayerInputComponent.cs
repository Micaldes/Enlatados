using Raylib_cs;
using System;
using System.Numerics;
using static EventId;
using Enlatados.Scenes.Core.Code.Objects;
using Enlatados.Scenes.Core.Code.Objects.Components;
//using System.Windows.Input;
using Enlatados.Scenes.Core.Code.Interfaces;
using Enlatados.Scenes.Core.Code.Command;

public class PlayerInputComponent : Component, IInputComponent
{
    public Vector2 mousePos { get; set; }

    private ICommand objetoComando;

    public bool mouseLeftPressed { get; set; }
    public PlayerInputComponent(GameObject owner) : base(owner){
        if(Owner is Player p)
        {
            objetoComando = p.getCommand();
        }
    }

    public void Input()
    {
        mousePos = Raylib.GetMousePosition(); //En cada iteracion se actualiza la posicion del mouse
        
        if (Raylib.IsMouseButtonPressed(MouseButton.Left))
        {
            mouseLeftPressed = true;
            if(Owner is Player _player)
            {
                // _player.NotifyObservers(PlayerShoots); //Vamos a encapsular la accion en una clase comando
               
                objetoComando.execute();
            }


        }
    }
}
