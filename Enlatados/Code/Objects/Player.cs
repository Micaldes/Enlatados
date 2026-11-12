using Raylib_cs;
using System;
using System.Numerics;
using Enlatados.Components;

namespace Enlatados.Components;

public class Player : GameObject
{
    public Player(Vector2 position, Texture2D texture, GameLoop parent): base (parent)  
    {
       // texture = Raylib.LoadTexture("../img/Cursor.png");
        InputComponent = new PlayerInputComponent(this);   
        MovementComponent = new PlayerMovementComponent(position, this);
        RenderComponent = new RenderComponent(texture, this);
                                                                            
    }

  
   
}
