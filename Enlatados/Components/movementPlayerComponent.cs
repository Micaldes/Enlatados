using System;

public class movementPlayerComponent : IMovementComponent
{

	
	public Vector2 move(Vector2 positionMouse, float deltaTime){ //Aqui no usare delta, ya que el cursor depende unicamente del raton
		return positionMouse;
	}

    
}
