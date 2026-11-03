using System;


namespace Enlatados.Components.Interfaces;

public class GameObject
{


	//public 	IInput InputComponent { get; set; }  --> Solo lo tendrá player, asi evitamos que tengan esta propiedad las latas
	public IMovementComponent MovementComponent { get; set; }
	public IRenderComponent RenderComponent { get; set; }





}
