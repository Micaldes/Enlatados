using Raylib_cs;
using System;
using System.Numerics;


namespace Enlatados.Components;

public class GameObject : IGameObject
{
    public GameLoop Parent { get; private set; }

    public IInputComponent? InputComponent { get; set; }
    public IMovementComponent? MovementComponent { get; set; }
    public IRenderComponent? RenderComponent { get; set; }

    public GameObject(GameLoop parent)
    {
        this.Parent = parent;
    }

    public void Initialize()
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








