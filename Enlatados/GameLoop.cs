using System;
using Raylib_cs;
using Enlatados.Scenes;

namespace Enlatados
{

    //AHORA GAMELOOP DELEGA EN EL ESTADO ACTIVO, SIMPLEMENTE ES EL MOTOR QUE PONE EN MARCHA
    //Y MANTIENE EL JUEGO
    public class GameLoop
    {
        private const double deltaFijo = 1 / 60d;
        private const int FPS = 120;
        private const int SCREEN_WIDTH = 1920;
        private const int SCREEN_HEIGTH = 1080;

        private StateManager _stateManager; //Instancia unica y globalmente accesible

        // Gestión de tiempos
        double currentTime;
        double lastTime;
        double lag = 0;
        double deltaTime;

        public void Run()
        {
            Init();

            lastTime = Raylib.GetTime();
            while (!Raylib.WindowShouldClose())
            {
                currentTime = Raylib.GetTime();
                deltaTime = currentTime - lastTime;
                lastTime = currentTime;

                lag += deltaTime;

                ReadInput();
                while (lag >= deltaFijo)
                {
                    Update(deltaFijo);
                    lag -= deltaFijo;
                }

                Render();
            }
            //Cuando acaba el juego
            // Limpiamos el estado activo antes de liberar los servicios globales
            _stateManager.GetEstado()?.Exit();

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
            // Raylib.ToggleFullscreen();
            Raylib.SetWindowPosition(100, 100);
            // Servicios globales (se mantienen vivos durante todo el juego)
            SoundLoader _soundSystem = new SoundLoader();
            _soundSystem.Initialize();
            ServiceLocator.RegisterService<SoundLoader>(_soundSystem);

            ImageLoader _imageSystem = new ImageLoader();
            _imageSystem.Initialize();
            ServiceLocator.RegisterService<ImageLoader>(_imageSystem);

            // Inicializamos la máquina de estados y arrancamos en el Menú
            _stateManager = StateManager.getInstance();
            _stateManager.changeState(States.State_Menu); //nada mas inicializarlo, pasamos a menu

           


        }

        private void ReadInput()
        {
            _stateManager.GetEstado()?.HandleInput();
        }

        private void Update(double deltaFijo)
        {
            // Si en tu IState.Update() no recibes parámetros, quita (float)deltaFijo
            _stateManager.GetEstado()?.Update();
        }

        private void Render()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            // Dibuja el estado que esté activo en ese momento
            _stateManager.GetEstado()?.Render();

            // Los sonidos activos del SoundLoader pueden seguir actualizándose globalmente si lo necesitas
            ServiceLocator.GetService<SoundLoader>().Render();

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
    }
}