using Raylib_cs;
using System;
using System.Numerics;


namespace Enlatados.Components;

public class GameObject : IGameObject
{

    public IInputComponent? InputComponent { get; set; }
    public IMovementComponent? MovementComponent { get; set; }
    public IRenderComponent? RenderComponent { get; set; }

    public GameObject(Vector2 position, Texture2D texture)
    {

    }
    public void Input()
    {
        InputComponent?.Input();
    }
    public void Update(float deltaTime)
    {
        MovementComponent?.Move(deltaTime);
    }

    public void Render()
    {
        RenderComponent?.Render();
    }

}








