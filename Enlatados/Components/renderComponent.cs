using System.Numerics;
using Raylib_cs;
using Enlatados.Components;

public class renderComponent : IRenderComponent
{
    private readonly GameObject _gameObject;

    public renderComponent(GameObject gameObject)
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