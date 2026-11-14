using Raylib_cs;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Enlatados.Components
{
    public class Lata : GameObject , ISubject<EventId>, IObserver<EventId>
    {

        int anchoEscalado;
        int altoEscalado;

        protected int lataVida = 3; //Propiedad
        private bool active;
        private float escala = 0.25f; // Escala visual

        private float speed { get; set; } // Para la lata 
        public Lata(Texture2D texture, float speed, GameLoop parent) : base(parent)
        {
            this.speed = speed;

            

            MovementComponent = new LataMovementComponent(Vector2.Zero, speed, this);
            RenderComponent = new RenderComponent(texture, this, escala);

            anchoEscalado = (int)(RenderComponent.texture.Width * escala);
            altoEscalado = (int)(RenderComponent.texture.Height * escala);
            active = false;
        }

        public bool isActive()
        {
            return active;
        }

        public void setActive()
        {
            if (RenderComponent is RenderComponent )
            {

                lataVida = 3;
                float posX = Random.Shared.Next(anchoEscalado, Raylib.GetScreenWidth() - anchoEscalado);
                float posY = -altoEscalado; // Empieza justo por encima del borde superior

                if (MovementComponent is LataMovementComponent mc)
                {
                    mc.position = new Vector2(posX, posY);

                }
            }
            active = true;
        }

        public void setInactive()
        {
            active = false;
        }

        public void RecibirImpacto()
        {
            lataVida -= 1;
            if(lataVida == 0)
            {
                NotifyObservers(EventId.LataDestroyed);
                setInactive();
            }
        }

        //Metodos del ISubject

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
            foreach(IObserver<EventId> observer in observadores)
            {
                observer.OnUpdate(data);
            }
        }

        //Metodos del Observador
        public void OnUpdate(EventId data)
        {

            if (!active)
            {
                return; //Ni lo comprueba
            }

            if (data == EventId.PlayerShoots)
            {

                // Construyes el rectángulo con la posición y el tamaño de la lata
                Rectangle lataRect = new Rectangle(MovementComponent.position.X, MovementComponent.position.Y, anchoEscalado, altoEscalado);
                //Comprobar si mousePos está dentro de las dimensiones de la lata

                if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(),lataRect))
                {
                    RecibirImpacto();
                }
            }
        }
    }
}