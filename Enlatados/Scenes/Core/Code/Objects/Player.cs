using Enlatados.Scenes.Core.Code.Command;
using Raylib_cs;
using System;
using System.Numerics;
//using System.Windows.Input;
using Enlatados.Scenes.Core.Code.Interfaces;
namespace Enlatados.Scenes.Core.Code.Objects;

public class Player : GameObject, ISubject<EventId>
{
    private ICommand comando;
    public Player(Vector2 position, Texture2D texture): base ()  
    {

        comando = new ShootCommand(this);
        //Si metemos recarga usamos otro comando
        // texture = Raylib.LoadTexture("../img/Cursor.png");
        InputComponent = new PlayerInputComponent(this);   
        MovementComponent = new PlayerMovementComponent(position, this);
        RenderComponent = new RenderComponent(texture, this);
       
    }
    public ICommand getCommand()
    {
        return comando;
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
