using Raylib_cs;
using System;
using System.Numerics;


namespace Enlatados.Components;

public class GameObject : IObject
{

    //Atributos
    public Vector2 position { get; set; } 
    public Texture2D texture { get; set; } 

	public 	IInputComponent InputComponent { get; set; }  
	public IMovementComponent MovementComponent { get; set; }
	public IRenderComponent RenderComponent { get; set; }

    

    public GameObject(Vector2 position, Texture2D texture)
    {
        this.position = position;
        this.texture = texture;
    }




  public void Input()
    {
        InputComponent.Input();
    }
  public void Update(double deltaTime){
        MovementComponent.move();
  }

    public void Render()
	{
    RenderComponent.Render();
	}

}








