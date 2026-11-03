using System;
using System.Numerics;


namespace Enlatados.Components;

public class Player : GameObject
{
    public IInput InputComponent { get; set; }


    public Player(IInput position, speed = 0) : base(position, speed) // Por defecto speed = 0 (ya que da igual la velocidad)
    {
        position = new inputComponent();
        
        MovementComponent = new movementPlayerComponent(); 
                                                                                           
    }

    public void update(){
        InputComponent.Input(); //Leo entrada
        float nextPos = InputComponent.nextPosition; //Le estoy pasando position del mouse
        MovementComponent.move(nextPos,  deltaTime);
    }
   
}
