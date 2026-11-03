using System;
using System.Numerics;


namespace Enlatados.Components;

public class Player : GameObject
{
    public IInput InputComponent { get; set; }


    public Player(Vector2 position, float speed) : base(position, speed)
    {
        InputComponent = new inputComponent();

        MovementComponent = new movementPlayerComponent();


    }
   
}
