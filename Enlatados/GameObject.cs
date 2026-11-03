using System;


namespace Enlatados.Components.Interfaces;

public class GameObject
{


	public 	IInput InputComponent { get; set; }
	public IMovementComponent MovementComponent { get; set; }
	public IRenderComponent RenderComponent { get; set; }





}
