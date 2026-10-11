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
        public void Run()
        {
            Init();

            while (!Raylib.WindowShouldClose())
            {
                ReadInput();

                Update();

                Render();
            }

            Raylib.CloseWindow();
        }

        private void Init()
        {


            //Raylib.InitWindow(
            //    _mazeScreenWidth - 1,
            //    _mazeScreenHeight + 48,
            //    "Gameloop");

            //Raylib.SetTargetFPS(FPS);
        }

        private void ReadInput()
        {
            // Read input
            //_player.ReadInput();
        }

        private void Update()
        {
            //Hay que hacer fixedDelta
            float deltaTime = Raylib.GetFrameTime();

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
