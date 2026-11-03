using System;
using System.Numerics;


namespace Enlatados.Components;

public class GameObject : IGameObject
{

    //Atributos

    public float speed { get; set; }
    public Vector2 position { get; set; } 



	//public 	IInput InputComponent { get; set; }  --> Solo lo tendrá player, asi evitamos que tengan esta propiedad las latas
	public IMovementComponent MovementComponent { get; set; }
	public IRenderComponent RenderComponent { get; set; }

    public GameObject(Vector2 position, float speed)
    {
        this.position = position;
        this.speed = speed;
        this.RenderComponent = new renderComponent(); //Para evitar su llamada en cada entidad, se inicializa en el constructor de la clase base.
    }


    public void Update(double deltaTime)
    {

	}

    public void Render()
	{

	}

}






