using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using Enlatados.Components;

namespace Enlatados
{

    public class GameLoop : ISubject<PlayerEventData>
    {

        private const double deltaFijo = 1 / 60d;
        //intervalo de tiempo constante que queremos que transcurra
        //entre actualizaciones de la simulación
      

        private const int FPS = 120;
        private const int SCREEN_WIDTH = 1280;
        private const int SCREEN_HEIGTH = 720;

        private Player _player;
        private StaticObject _bg;
        private SoundSystem _soundSystem;

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

            _bg.Unload();                          // Destruye el canvas de la GPU
            Raylib.UnloadTexture(_player.RenderComponent.texture);
            Raylib.CloseWindow();
        }

        private void Init()
        {
            Raylib.InitWindow(
                SCREEN_WIDTH,
                SCREEN_HEIGTH,
                "Enlatados");

            Raylib.SetTargetFPS(FPS);

            _player = new Player(new Vector2(0,0), Raylib.LoadTexture("Assets/Images/Cursor.png"), this);
            _bg = new StaticObject(new Vector2(0, 0), Raylib.LoadTexture("Assets/Images/Background.png"), SCREEN_WIDTH, SCREEN_HEIGTH);

            _soundSystem = new SoundSystem();
            _soundSystem.Initialize();
            AddObserver(_soundSystem);

            Raylib.HideCursor(); //Ocultamos el cursor para que se vea sólo el png de la mira
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
        }

        private void Render()
        {
            // Render
            Raylib.BeginDrawing();

            // Rener: clean background
            Raylib.ClearBackground(Color.Black);
            
            //Render background
            _bg.Render();

            // Render: draw player
            _player.Render();

            _soundSystem.Render();
          
            // Render: Title and FPS
            //Raylib.DrawText("Hello NoGameloop!", 16, _mazeScreenHeight + 12, 20, Color.Yellow);
            //RenderFpsCounter();

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

        public void SendPlayerEvent(Events eventType)
        {
            NotifyObservers(new PlayerEventData(eventType));
        }
    }
}
