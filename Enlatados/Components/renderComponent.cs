using System.Numerics;
using Raylib_cs;
using Enlatados.Components;
public class RenderComponent : Component, IRenderComponent
{
    public Texture2D texture { get; set; }
    public RenderComponent(Texture2D texture, GameObject owner) : base(owner) { 

        this.texture = texture;

    }

    public void Render()
    {
        Raylib.DrawTextureV(
            texture,
            Owner.MovementComponent.position,
            Color.White
        );

    }
}