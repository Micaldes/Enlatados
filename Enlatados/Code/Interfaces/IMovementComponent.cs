using System.Numerics;

public interface IMovementComponent
{
    public Vector2 position { get; set; }
    public void Move(float deltaTime); //metodo de la actualizacion
}
