using System;
using System.Numerics;
using Raylib_cs;
using static ImageAssets.ImageID;


namespace Enlatados.Scenes.Credits
{
    public class Credits : IState
    {
        public States StateID { get; } = States.State_Credits;
        public StateManager StateManagement { get; set; } = StateManager.getInstance();

        private int SCREEN_WIDTH = Raylib.GetScreenWidth();
        private int SCREEN_HEIGHT = Raylib.GetScreenHeight();

        private StaticObject _bg;

        private string _titulo = "CREDITOS";
        private string _nombre1 = "Nombre 1";
        private string _nombre2 = "Nombre 2";
        private string _nombre3 = "Nombre 3";
        private string _nombre4 = "Nombre 4";
        private string _volver = "VOLVER";

        private int _tamTitulo = 60;
        private int _tamNombre = 36;
        private int _tamVolver = 32;

        private Vector2 _posTitulo;
        private Vector2 _posNombre1;
        private Vector2 _posNombre2;
        private Vector2 _posNombre3;
        private Vector2 _posNombre4;
        private Vector2 _posVolver;

        public Credits()
        {
         

            _bg = new StaticObject(
                new Vector2(0, 0),
                ServiceLocator.GetService<ImageLoader>().GetTexture(MenuEnlatados),
                SCREEN_WIDTH,
                SCREEN_HEIGHT
            );

            _posTitulo = new Vector2((SCREEN_WIDTH - Raylib.MeasureText(_titulo, _tamTitulo)) / 2f, SCREEN_HEIGHT * 0.15f);
            _posNombre1 = new Vector2((SCREEN_WIDTH - Raylib.MeasureText(_nombre1, _tamNombre)) / 2f, SCREEN_HEIGHT * 0.35f);
            _posNombre2 = new Vector2((SCREEN_WIDTH - Raylib.MeasureText(_nombre2, _tamNombre)) / 2f, SCREEN_HEIGHT * 0.44f);
            _posNombre3 = new Vector2((SCREEN_WIDTH - Raylib.MeasureText(_nombre3, _tamNombre)) / 2f, SCREEN_HEIGHT * 0.53f);
            _posNombre4 = new Vector2((SCREEN_WIDTH - Raylib.MeasureText(_nombre4, _tamNombre)) / 2f, SCREEN_HEIGHT * 0.62f);
            _posVolver = new Vector2((SCREEN_WIDTH - Raylib.MeasureText(_volver, _tamVolver)) / 2f, SCREEN_HEIGHT * 0.82f);
        }

        public void Enter()
        {
        }

        public void HandleInput()
        {
            Vector2 mousePos = Raylib.GetMousePosition();
            int anchoVolver = Raylib.MeasureText(_volver, _tamVolver);

            bool sobreVolver = mousePos.X >= _posVolver.X && mousePos.X <= _posVolver.X + anchoVolver &&
                               mousePos.Y >= _posVolver.Y && mousePos.Y <= _posVolver.Y + _tamVolver;

            if (Raylib.IsKeyPressed(KeyboardKey.Escape) ||
               (Raylib.IsMouseButtonPressed(MouseButton.Left) && sobreVolver))
            {
                StateManagement.changeState(States.State_Menu);
            }
        }

        public void Update()
        {
        }

        public void Render()
        {
            _bg.Render();

            Raylib.DrawText(_titulo, (int)_posTitulo.X, (int)_posTitulo.Y, _tamTitulo, Color.White);
            Raylib.DrawText(_nombre1, (int)_posNombre1.X, (int)_posNombre1.Y, _tamNombre, Color.White);
            Raylib.DrawText(_nombre2, (int)_posNombre2.X, (int)_posNombre2.Y, _tamNombre, Color.White);
            Raylib.DrawText(_nombre3, (int)_posNombre3.X, (int)_posNombre3.Y, _tamNombre, Color.White);
            Raylib.DrawText(_nombre4, (int)_posNombre4.X, (int)_posNombre4.Y, _tamNombre, Color.White);

            Vector2 mousePos = Raylib.GetMousePosition();
            int anchoVolver = Raylib.MeasureText(_volver, _tamVolver);
            bool sobreVolver = mousePos.X >= _posVolver.X && mousePos.X <= _posVolver.X + anchoVolver &&
                               mousePos.Y >= _posVolver.Y && mousePos.Y <= _posVolver.Y + _tamVolver;

            Raylib.DrawText(_volver, (int)_posVolver.X, (int)_posVolver.Y, _tamVolver, sobreVolver ? Color.Yellow : Color.White);
        }

        public void Exit()
        {
        }
    }
}