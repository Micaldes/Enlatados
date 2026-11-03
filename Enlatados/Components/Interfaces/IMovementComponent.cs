using System;

public interface IMovementComponent
{

    public Vector2 position{get; set;} // Ambas para lata y cursor
    public float speed {get; set;} // Para la lata 

   public void move(Vector2 nextPosition, float deltaTime); //metodo de la actualizacion
}
