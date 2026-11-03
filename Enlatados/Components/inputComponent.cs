using Raylib_cs;
using System;
using System.Numerics;

public class inputComponent : IInput
{
    Vector2 nextPosition;
    public inputComponent(Vector2 position)
    {
        nextPosition = position;
    }
	
    //Actualizar el componente de input en cada iteracion
	public void updateInput()
    {
        if (Raylib.IsKeyDown(KeyboardKey.W))
        {
            nextPosition = new Vector2(0, -1);
        }
        else if (Raylib.IsKeyDown(KeyboardKey.S))
        {
            nextPosition = new Vector2(0, 1);
        }
        else if (Raylib.IsKeyDown(KeyboardKey.A))
        {
            nextPosition = new Vector2(-1, 0);
        }
        else if (Raylib.IsKeyDown(KeyboardKey.D))
        {
            nextPosition = new Vector2(1, 0);
        }

    }
}
