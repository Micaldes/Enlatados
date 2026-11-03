using System;


namespace Enlatados.Components.Interfaces;

public class GameObject : IGameObject
{


	//public 	IInput InputComponent { get; set; }  --> Solo lo tendrá player, asi evitamos que tengan esta propiedad las latas
	public IMovementComponent MovementComponent { get; set; }
	public IRenderComponent RenderComponent { get; set; }




    public void Update(double deltaTime)

    {

	}
    public void Render()
	{

	}

}






