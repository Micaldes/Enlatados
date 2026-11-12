using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


//Para diferenciar objetos dinámicos de estáticos
public interface IGameObject

{
    public void Initialize();
    public void Input();
    public void Update(float deltaTime);
    public void Render(); 


}

