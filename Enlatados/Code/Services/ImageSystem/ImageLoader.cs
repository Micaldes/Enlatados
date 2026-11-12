using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ImageLoader : IService, IGameObject
{
    private Dictionary<ImageAssets.ImageID, Image> _images = new Dictionary<ImageAssets.ImageID, Image>();

    public void Initialize()
    {
        foreach(KeyValuePair<ImageAssets.ImageID, string> image in ImageAssets.ImageFiles)
        {
            _images[image.Key] = new Image(image.Value);
        }
    }

    public Texture2D GetTexture(ImageAssets.ImageID id)
    {
        if (_images.ContainsKey(id))
        {
            return _images[id].GetTexture();
        }
        throw new Exception("No se ha reconocido ImageAssets.ImageID como una una textura existente. ");
    }

    public void Unload(ImageAssets.ImageID id)
    {
        if (_images.ContainsKey(id))
        {
            _images[id].Unload();
        }
    }

    public void Input()
    {
    
    }
    public void Update(float deltaTime)
    {
        
    }
    public void Render()
    {

    }
    public void Destroy()
    {
        foreach (var Image in _images.Values)
        {
            Image.Unload();
        }

        _images.Clear();
    }
}

