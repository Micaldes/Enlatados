using System;


namespace Enlatados.Components.Interfaces;

public class GameObject
{

	public: 
		IInput InputComponent { get; set; }; 
		IMovementComponent MovementComponent { get; set; }; 
		IRenderComponent RenderComponent{ get; set; };





}
