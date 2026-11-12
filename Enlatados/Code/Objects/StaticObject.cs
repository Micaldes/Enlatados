using Enlatados.Components;
using Raylib_cs;
using System.Numerics;

public class StaticObject : IGameObject
{
    public bool dirty = true; //El lienzo necesita ser pintado

    public Vector2 position { get; set; }
    public Texture2D texture { get; set; }
   

    private int _width;
    private int _height;

    public StaticObject(Vector2 position, Texture2D texture, int width, int height)
    {
        this.position = position;
        this.texture = texture;
        this._width = width;
        this._height = height;

    }

    public void Initialize()
    {

    }
    public void Input()
    {

    }
    public void Update(float deltaTime)
    {

    }

    public void Render()
    {

        Rectangle sourceRec = new Rectangle(0, 0, texture.Width, texture.Height);

        Rectangle destRec = new Rectangle(position.X, position.Y, _width, _height);

        Raylib.DrawTexturePro(texture, sourceRec, destRec, Vector2.Zero, 0.0f,Color.White);
    }

    public void Destroy()
    {

    }
}