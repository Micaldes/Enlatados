using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

public class Image
{
    private Raylib_cs.Texture2D _texture;

    public Image(string imagePath)
    {
        _texture = Raylib.LoadTexture(Path.Combine(AppContext.BaseDirectory, "Assets", "Images", imagePath));
        Raylib.SetTextureFilter(_texture, TextureFilter.Point);
    }

    public Texture2D GetTexture()
    {
        return _texture;
    }

    public void Unload()
    {
        Raylib.UnloadTexture(_texture);
    }
}

