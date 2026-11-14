using Enlatados.Core.Code.Objects;
using Enlatados.Core.Code.Objects.Components;
using System;
using System.Numerics;
public class LataMovementComponent : Component, IMovementComponent
{
    public Vector2 position { get; set; }
	private float speed;
    public LataMovementComponent(Vector2 position,float speed,GameObject owner) : base(owner) {
		this.position = position;
		this.speed = speed;
	}
	
	public void Move(float deltaTime)
	{
		//Logica de la lata

		position = new Vector2(position.X, position.Y + speed * deltaTime);

		

    }
}
