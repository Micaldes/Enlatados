using Enlatados.Components;
using Raylib_cs;
using System.Numerics;

public class StaticObject : IObject
{
    public bool dirty = true; //El lienzo necesita ser pintado

    public Vector2 position { get; set; }
    public Texture2D texture { get; set; }
   

    private RenderTexture2D _targetCanvas;
    private int _width;
    private int _height;

    public StaticObject(Vector2 position, Texture2D texture, int width, int height)
    {
        this.position = position;
        this.texture = texture;
        this._width = width;
        this._height = height;
      

        _targetCanvas = Raylib.LoadRenderTexture(width, height); //Estamos reservando el lienzo en VRAM
    }

    public void Render()
    {
        // Si está dirty, escalamos la textura original al tamaño completo del canvas
        if (dirty)
        {
            Raylib.BeginTextureMode(_targetCanvas);
            Raylib.ClearBackground(Color.Blank);

            // tomamos toda la imagen
            Rectangle sourceRec = new Rectangle(0, 0, texture.Width, texture.Height);

            // Estiramos el canvas (pantalla completa: width x height)
            Rectangle destRec = new Rectangle(0, 0, _width, _height);

            // Dibujamos la textura sobre el canvas
            Raylib.DrawTexturePro(
                texture,
                sourceRec,
                destRec,
                Vector2.Zero,
                0.0f,
                Color.White
            );

            Raylib.EndTextureMode();
            dirty = false;
        }
        //Lo hemos dibujado en el lienzo pero queda proyectarlo en pantalla. (Ya en VRAM)


        // Proyectamos el canvas final en la pantalla, pero teniendo en cuenta lo siguiente
        //En cada frame Raylib elimina/ borra la pantalla con ClearBackGround(Color.Black)
        //Para no tener que dibujar y estirar la texura cada frame, proyectamos directamente el lienzo ahorranco cálculos.
        Rectangle canvasSource = new Rectangle(0, 0, _targetCanvas.Texture.Width, -_targetCanvas.Texture.Height);
        //Hemos cogido todo el canvas
        Rectangle canvasDest = new Rectangle(0, 0, _targetCanvas.Texture.Width, _targetCanvas.Texture.Height);
        //Elegimos el lugar de la pantalla en el que voy a pegar el canvas
        Raylib.DrawTexturePro(_targetCanvas.Texture, canvasSource, canvasDest, Vector2.Zero, 0.0f, Color.White);
    }

    public void Unload()
    {
        Raylib.UnloadRenderTexture(_targetCanvas);  //Liberar memoria de VRAM que usé para reservar el renderTexture2D
    }
}