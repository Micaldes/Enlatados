using System;

public class movementPlayerComponent : IMovementComponent
{

	
	public void move(Vector2 positionMouse, float deltaTime){ //Aqui no usare delta, ya que el cursor depende unicamente del raton
		
		position = positionMouse;
	  
	}

    
}
