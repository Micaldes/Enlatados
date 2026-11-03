using System;
using System.Numerics;


namespace Enlatados.Components;

public class Player : GameObject
{
    public IInput InputComponent { get; set; }


    public Player(Vector2 position, float speed = 0) : base(position, speed) // Por defecto speed = 0 (ya que da igual la velocidad)
    {
        texture = Raylib.LoadTexture("img/Cursor.png");
        MovementComponent = new movementPlayerComponent();
        InputComponent = new inputComponent();                                                                             
    }

    public void Update(float deltaTime){
        InputComponent.Input(); //Actualizamos la pos del ratón
        float nextPos = InputComponent.nextPosition; //Guardamos el atributo donde se almacena la pos del ratón
        position = MovementComponent.move(nextPos,  deltaTime);
    }
   
}
