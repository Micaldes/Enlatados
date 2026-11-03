using Raylib_cs;
using System;
using System.Numerics;

public class inputComponent : IInput
{
    public Vector2 nextPosition { get; set; }
	
    //Actualizar el componente de input en cada iteracion
	public void Input()
    {
    // Para permitir juego por teclado
    nextPosition = Raylib.GetMousePosition(); //En cada iteracion se actualiza la posicion del mouse
    }
}
