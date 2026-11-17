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
        Cursor,

        MenuEnlatados,
        //LataMonster

        LataNormal1,
        LataNormal2,
        LataNormal3,

        Explosion

    }

    public static readonly Dictionary<ImageID, string> ImageFiles = new Dictionary<ImageID, string>()
    {
        [ImageID.Background] = "Background.png",
        [ImageID.Cursor] = "Cursor.png",
        [ImageID.LataNormal1] = "LataEstado1.png",
        [ImageID.MenuEnlatados] = "MenuEnlatados.png",
        [ImageID.Explosion] = "LataExplosion.png"
    };
}
