using System.Numerics;
using Raylib_cs;
using Enlatados.Components;
using Enlatados.Code.Objects.Components;
public class RenderComponent : Component, IRenderComponent
{
    public Texture2D texture { get; set; }
    public float Scale { get; set; }
    public RenderComponent(Texture2D texture, GameObject owner, float scale = 1.0f) : base(owner) { 

        this.texture = texture;
        this.Scale = scale;
    }

    public void Render()
    {
        Raylib.DrawTextureEx(
             texture,
             Owner.MovementComponent.position,
             0f, // Rotación en grados
             Scale,
             Color.White
         );

    }
}