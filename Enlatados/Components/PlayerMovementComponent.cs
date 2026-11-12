using System;
using System.Numerics;
using Enlatados.Components;

public class PlayerMovementComponent : Component, IMovementComponent
{
    public Vector2 position { get; set; }
    public PlayerMovementComponent(Vector2 position, GameObject owner): base(owner) { 
        
        this.position = position;

    }
    
    public void  Move(float deltaTime)
    { //Aqui no usare delta, ya que el cursor depende unicamente del raton
        position = Owner.InputComponent.mousePos;

        if (Owner.InputComponent.mouseLeftPressed)
        {
            Console.WriteLine("MOUSE LEFT BUTTON PRESSED");
        }
	}

}
