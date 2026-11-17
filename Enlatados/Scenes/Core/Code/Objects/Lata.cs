using Enlatados.Scenes.Core.Code.Objects.Components;
using Raylib_cs;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Enlatados.Scenes.Core.Code.Objects
{
    public class Lata : GameObject , ISubject<EventId>, IObserver<EventId>
    {
        ServiceLocator controladorServicios;
        SoundLoader soundSystem;

        public LataExplosionComponent ExplosionComponent { get; set; }

        int anchoEscalado;
        int altoEscalado;

        protected int lataVida = 5; //Propiedad
        private bool active;
        private float escala = 0.05f; // Escala visual

        private float speed { get; set; } // Para la lata
                                          // 
        private Texture2D texturaLata; // Para recuperarla tras la explosion
        public Lata(Texture2D texture, float speed)
        {
            this.speed = speed;
            texturaLata = texture; //La guardamos
            controladorServicios = ServiceLocator.getInstance();
            soundSystem = controladorServicios.GetService<SoundLoader>();
            Texture2D ExplosionTexture = controladorServicios.GetService<ImageLoader>().GetTexture(ImageAssets.ImageID.Explosion); //Aqui textura explosion
            ExplosionComponent = new LataExplosionComponent(this,ExplosionTexture);

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
            if(RenderComponent is RenderComponent rc)
            {
                rc.texture = texturaLata;
            }

            lataVida = 5; //Para las latas base
        }

        public void RecibirImpacto()
        {
            NotifyObservers(EventId.Impacts);  //Asi el soundLoader ejecutará el sonido
            lataVida -= 1;
           
            //LLamada a su componente de movimiento que hara el efecto de empuje de la lata
            if (lataVida == 0)
            {
                ExplosionComponent.Explode();
                NotifyObservers(EventId.LataDestroyed);
                //setInactive(); Lo hará explosion Component al terminar la explosion
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

            if (!active ||  ExplosionComponent.IsExploding)
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