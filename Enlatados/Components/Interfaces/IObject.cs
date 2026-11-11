using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


//Para diferenciar objetos dinámicos de estáticos
    public interface IObject

    {


    public Vector2 position { get; set; }
    public Texture2D texture { get; set; }

    public void Render(); //Comun a todos los objetos
    
    }

