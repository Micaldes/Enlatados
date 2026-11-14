using Raylib_cs;
using System;
using System.Numerics;

namespace Enlatados.Scenes.Core.Code.Objects;

public class Player : GameObject, ISubject<EventId>
{
    public Player(Vector2 position, Texture2D texture, GameLoop parent): base (parent)  
    {
       // texture = Raylib.LoadTexture("../img/Cursor.png");
        InputComponent = new PlayerInputComponent(this);   
        MovementComponent = new PlayerMovementComponent(position, this);
        RenderComponent = new RenderComponent(texture, this);
                                                                            
    }
    List<IObserver<EventId>> observadores = new List<IObserver<EventId>>(); //observadores de eventos

    public void AddObserver(IObserver<EventId> observer)
    {
        observadores.Add(observer);

    }
    public void RemoveObserver(IObserver<EventId> observer)
    {
        observadores.Remove(observer);
    }
    public void NotifyObservers(EventId data)
    {
        foreach (IObserver<EventId> observer in observadores)
        {
            observer.OnUpdate(data);
        }
    }



}
