using System;
using System.Numerics;
using Enlatados.Components;
public class movementPlayerComponent : IMovementComponent
{
    private Player _player;

    public movementPlayerComponent(Player Player) { _player = Player; }
    
    public void  move()
    { //Aqui no usare delta, ya que el cursor depende unicamente del raton
        _player.position = _player.mousePos;
	}

    
}
