using System.Numerics;
using Raylib_cs;
using Enlatados.Components;

public class renderComponent : IRenderComponent
{
    private readonly IObject _gameObject;

    public renderComponent(IObject gameObject)
    {
        _gameObject = gameObject;
    }

    public void Render()
    {
        Raylib.DrawTextureV(
            _gameObject.texture,
            _gameObject.position,
            Color.White
        );
    }
}