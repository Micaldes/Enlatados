using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using static ImageAssets.ImageID;
using Enlatados.Core.Code.HUD;
using Enlatados.Core.Code.ObjectPool;
using Enlatados.Core.Code.Objects;

namespace Enlatados

{
    public class GameLoop : ISubject<PlayerEventData>
    {

        private const double deltaFijo = 1 / 60d;
        //intervalo de tiempo constante que queremos que transcurra
        //entre actualizaciones de la simulación

        //Probando cosas de las latas
        //private List<Lata> _latas = new List<Lata>();
        private LataPool _latas;
        private float _spawnTimer = 0f;
        private const float SPAWN_INTERVAL = 1.5f; // Segundos entre cada lata


       
      



        private const int FPS = 120;
        private const int SCREEN_WIDTH = 1920;
        private const int SCREEN_HEIGTH = 1080;

        private Player _player;
        private StaticObject _bg;

        private Cronometro reloj ;

        //Gestión de tiempos
        double  currentTime;
        double lastTime;
        double  lag  = 0;
        double deltaTime;
        public void Run()
        {
            Init();

            lastTime = Raylib.GetTime();
            while (!Raylib.WindowShouldClose())
            {
                currentTime = Raylib.GetTime();
                deltaTime = currentTime - lastTime; //Tiempo transcurrido entre dos frames consecutivos o dicho de otro modo tiempo que tarda en procesarse el frame anterior
                lastTime = currentTime;

                lag += deltaTime;


                ReadInput();
                while (lag >= deltaFijo)
                {
                    Update(deltaFijo);

                    lag -= deltaFijo;
                }
              
                Render(); //Es independiente al paso del tiempo del juego.
            }

            ServiceLocator.GetService<ImageLoader>().Destroy();
            ServiceLocator.GetService<SoundLoader>().Destroy();
            ServiceLocator.Clear();

            Raylib.CloseWindow();
        }

        private void Init()
        {
            Raylib.InitWindow(
                SCREEN_WIDTH,
                SCREEN_HEIGTH,
                "Enlatados");

            Raylib.SetTargetFPS(FPS);
             Raylib.ToggleFullscreen();
           // Raylib.SetWindowPosition(100, 100);
            SoundLoader _soundSystem = new SoundLoader();
            _soundSystem.Initialize();
            ServiceLocator.RegisterService<SoundLoader>(_soundSystem);

            ImageLoader _imageSystem = new ImageLoader();
            _imageSystem.Initialize();
            ServiceLocator.RegisterService<ImageLoader>(_imageSystem);
            AddObserver(_soundSystem);

            _player = new Player(new Vector2(0, 0), ServiceLocator.GetService<ImageLoader>().GetTexture(Cursor), this);
            _bg = new StaticObject(new Vector2(0, 0), ServiceLocator.GetService<ImageLoader>().GetTexture(Background), SCREEN_WIDTH, SCREEN_HEIGTH);
            reloj = new Cronometro();

            Texture2D texturaLata = ServiceLocator.GetService<ImageLoader>().GetTexture(LataMonster);// Esta el ID al de tu enum

            _latas = new LataPool(10, texturaLata, 250f, this);

            Raylib.HideCursor(); //Ocultamos el cursor para que se vea sólo el png de la mira


            // Observadores
            for(int i = 0; i < _latas.coleccion.Count();i++)
            {
                _player.AddObserver(_latas.coleccion[i]);
                _latas.coleccion[i].AddObserver(reloj);
            }
            
            
        }

        private void ReadInput()
        {
            // Read input
            _player.Input();
        }

        private void Update(double deltaFijo)
        {
            // Update game logic
            _player.Update((float)deltaFijo); //No uso deltaFijo pero lo paso igual para el resto de objects

            reloj.Update((float)deltaFijo);


            // Temporizador de aparición
            _spawnTimer += (float)deltaFijo;
            if (_spawnTimer >= SPAWN_INTERVAL)
            {
                // Pides una lata libre al pool y la activas (ajusta el nombre al método de tu LataPool)
                Lata lataLibre = _latas.getNextAvailable();
                if (lataLibre != null)
                {
                    lataLibre.setActive();
                }
                _spawnTimer = 0f;
            }

            // Movimiento y reciclaje al salir por abajo
            foreach (Lata lata in _latas.coleccion) // O el método/propiedad con el que accedas a las latas
            {
                if (lata.isActive())
                {
                    lata.Update((float)deltaFijo);

                    if (lata.MovementComponent.position.Y > Raylib.GetScreenHeight())
                    {
                        lata.setInactive(); // Se devuelve al pool en lugar de borrarse
                    }
                }
            }
        }

        private void Render()
        {
            // Render
            Raylib.BeginDrawing();

            // Rener: clean background
            Raylib.ClearBackground(Color.Black);
            
            //Render background
            _bg.Render();


            // Render latas
            foreach (Lata lata in _latas.coleccion)
            {
                if (lata.isActive())
                {
                    lata.Render();
                }
                
            }

            // Render: draw player
            _player.Render();



            reloj.Render();
            ServiceLocator.GetService<SoundLoader>().Render();


           
            // Render: Title and FPS
            //Raylib.DrawText("Hello NoGameloop!", 16, _mazeScreenHeight + 12, 20, Color.Yellow);
            RenderFpsCounter();

            Raylib.EndDrawing();
        }

        private void RenderFpsCounter()
        {
            const int fpsFontSize = 20;
            const int fpsMargin = 10;

            string fpsText = $"FPS: {Raylib.GetFPS()}";
            int textWidth = Raylib.MeasureText(fpsText, fpsFontSize);

            int x = Raylib.GetScreenWidth() - textWidth - fpsMargin;
            //int y = _mazeScreenHeight + 12;
            //Raylib.DrawText(fpsText, x, y, fpsFontSize, Color.Green);
        }

        //Patrón observer
        private List<IObserver<PlayerEventData>> _observers = new List<IObserver<PlayerEventData>>();
        public void AddObserver(IObserver<PlayerEventData> observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver<PlayerEventData> observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers(PlayerEventData data)
        {
            foreach(IObserver<PlayerEventData> observer in _observers)
            {
                observer.OnUpdate(data);
            }
        }

        public void SendPlayerEvent(EventId eventType)
        {
            NotifyObservers(new PlayerEventData(eventType)); //Sonidos
            _player.NotifyObservers(eventType);  
        }
    }
}
