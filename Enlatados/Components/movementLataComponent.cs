using Enlatados.Components;
using System;

public class movementLataComponent : IMovementComponent
{
	Lata _lata;
	public movementLataComponent(Lata lata) { _lata = lata; }
	
	
	public void move()
	{
		//Logica de la lata
	}
}
