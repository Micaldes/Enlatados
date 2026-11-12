using Enlatados.Components;
using System;
using System.Numerics;
public class LataMovementComponent : Component, IMovementComponent
{
    public Vector2 position { get; set; }
    public LataMovementComponent(GameObject owner) : base(owner) { }
	
	public void Move(float deltaTime)
	{
		//Logica de la lata
	}
}
