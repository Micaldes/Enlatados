using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Raylib_cs;
using static ImageAssets.ImageID;
using Enlatados.Scenes.Core.Code.HUD;
using Enlatados.Scenes.Core.Code.ObjectPool;
using Enlatados.Scenes.Core.Code.Objects;

namespace Enlatados.Scenes.Core.Code
{
    public class Game : IState
    {
        public States StateID { get; } = States.State_Core;
        public StateManager StateManagement { get; set; } = StateManager.getInstance();

        private const float deltaFijo = 1f / 60f;
        private int SCREEN_WIDTH = Raylib.GetScreenWidth();
        private int SCREEN_HEIGHT = Raylib.GetScreenHeight();

        private LataPool _latas;
        private float _spawnTimer = 0f;
        private const float SPAWN_INTERVAL = 1.5f;

        private Player _player;
        private StaticObject _bg;
        private Cronometro _reloj;

        

        public void Enter()
        {
            // Registramos el sistema de sonido como observador de los eventos del jugador
            SoundLoader soundSystem = ServiceLocator.GetService<SoundLoader>();
         

            // Inicialización de entidades y escenario
            _player = new Player(new Vector2(0, 0), ServiceLocator.GetService<ImageLoader>().GetTexture(Cursor));
            _bg = new StaticObject(new Vector2(0, 0), ServiceLocator.GetService<ImageLoader>().GetTexture(Background), SCREEN_WIDTH, SCREEN_HEIGHT);
            _reloj = new Cronometro();

            Texture2D texturaLata = ServiceLocator.GetService<ImageLoader>().GetTexture(LataMonster);
            _latas = new LataPool(10, texturaLata, 250f);

            // Ocultamos el cursor del sistema para mostrar solo la mira
            Raylib.HideCursor();

            // Conexión de observadores entre jugador, latas y cronómetro
            for (int i = 0; i < _latas.coleccion.Count(); i++)
            {
                _player.AddObserver(_latas.coleccion[i]);
                _latas.coleccion[i].AddObserver(_reloj);
            }
        }

        public void HandleInput()
        {
            _player.Input();
        }

        public void Update()
        {
            _player.Update(deltaFijo);
            _reloj.Update(deltaFijo);

            // Temporizador de aparición
            _spawnTimer += deltaFijo;
            if (_spawnTimer >= SPAWN_INTERVAL)
            {
                Lata lataLibre = _latas.getNextAvailable();
                if (lataLibre != null)
                {
                    lataLibre.setActive();
                }
                _spawnTimer = 0f;
            }

            // Movimiento y reciclaje al salir por abajo
            foreach (Lata lata in _latas.coleccion)
            {
                if (lata.isActive())
                {
                    lata.Update(deltaFijo);

                    if (lata.MovementComponent.position.Y > Raylib.GetScreenHeight())
                    {
                        lata.setInactive();
                    }
                }
            }
        }

        public void Render()
        {
            _bg.Render();

            foreach (Lata lata in _latas.coleccion)
            {
                if (lata.isActive())
                {
                    lata.Render();
                }
            }

            _player.Render();
            _reloj.Render();
        }

        public void Exit()
        {
            // Restauramos el cursor para los menús y desvinculamos observadores
            Raylib.ShowCursor();
           
            _bg.Unload();
        }

        

        //public void SendPlayerEvent(EventId eventType)
        //{
        //    NotifyObservers(new PlayerEventData(eventType));
        //    _player.NotifyObservers(eventType);
        //}
    }
}