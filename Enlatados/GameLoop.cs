using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace Enlatados
{
    internal class GameLoop
    {

        private const double deltaFijo = 1 / 60d;


        private const int FPS = 120;
        private const int SCREEN_WIDTH = 1280;
        private const int SCREEN_HEIGTH = 720;


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

            Raylib.CloseWindow();
        }

        private void Init()
        {


            Raylib.InitWindow(
                SCREEN_WIDTH,
                SCREEN_HEIGTH,
                "Enlatados");

            Raylib.SetTargetFPS(FPS);
        }

        private void ReadInput()
        {
            // Read input
            //_player.ReadInput();
        }

        private void Update(double deltaFijo)
        {
           

            // Update game logic
            //_player.Update(deltaTime);
        }

        private void Render()
        {
            // Render
            Raylib.BeginDrawing();

            // Rener: clean background
            Raylib.ClearBackground(Color.Black);

            // Render: draw player
            //_player.Render();

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
    }
}
