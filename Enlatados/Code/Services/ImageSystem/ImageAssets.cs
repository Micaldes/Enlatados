using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ImageAssets
{
    public enum ImageID
    {
        Background,
        Cursor
    }

    public static readonly Dictionary<ImageID, string> ImageFiles = new Dictionary<ImageID, string>()
    {
        [ImageID.Background] = "Background.png",
        [ImageID.Cursor] = "Cursor.png"
    };
}
