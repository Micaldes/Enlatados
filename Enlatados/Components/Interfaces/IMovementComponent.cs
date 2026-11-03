using System;

public interface IMovementComponent
{
    public float speed {get; set;} // Para la lata 

   public Vector2 move(Vector2 nextPosition, float deltaTime); //metodo de la actualizacion
}
