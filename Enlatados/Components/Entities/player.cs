using Raylib_cs;
using System;
using System.Numerics;
using Enlatados.Components;

namespace Enlatados.Components;

public class Player : GameObject
{

    public Vector2 mousePos { get; set;  }


    public Player(Vector2 position, Texture2D texture): base (position,texture)  
    {
       // texture = Raylib.LoadTexture("../img/Cursor.png");
        InputComponent = new PlayerinputComponent(this);   
        MovementComponent = new movementPlayerComponent(this);
        RenderComponent = new renderComponent(this);
                                                                            
    }

  
   
}
