using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics; // Necesario para Vector2
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using static ImageAssets.ImageID;

namespace Enlatados.Scenes.Menu
{
    public class Menu : IState
    {
        public States StateID { get; } = States.State_Menu; //Ya no te hace falta
        public StateManager StateManagement { get; set; } = StateManager.getInstance();
        ServiceLocator controladorServicios = ServiceLocator.getInstance(); //Instancia unica y globalmente accesible
        // Faltaba el tipo (int) y completar el nombre de los métodos de Raylib
        private int SCREEN_WIDTH = Raylib.GetScreenWidth();
        private int SCREEN_HEIGHT = Raylib.GetScreenHeight();

        private StaticObject _bg;

        // AREAS BOTONES (Ajusta los números según tu resolución)
        private Rectangle Jugar = new Rectangle(860, 340, 200, 50);
        private Rectangle Ajustes = new Rectangle(860, 410, 200, 50);
        private Rectangle Creditos = new Rectangle(860, 480, 200, 50);

        // Las instrucciones de inicialización van dentro de un constructor o en Enter(), no sueltas en la clase
        public Menu()
        {
            _bg = new StaticObject(new Vector2(0, 0), controladorServicios.GetService<ImageLoader>().GetTexture(MenuEnlatados), SCREEN_WIDTH, SCREEN_HEIGHT);
        }

        public void Enter() //Es un preload
        {
            //Inicialización de variables si hace falta
        }

        public void HandleInput()
        {
            // Cambiado a MouseButton.Left (si querías clic derecho déjalo en Right)
            if (Raylib.IsMouseButtonPressed(MouseButton.Left))
            {
                var mousePos = Raylib.GetMousePosition();

                if (Raylib.CheckCollisionPointRec(mousePos, Jugar))
                {
                    // Aquí llamas a tu gestor de estados para cambiar al juego
                    StateManagement.changeState(States.State_Core);
                }
                else if (Raylib.CheckCollisionPointRec(mousePos, Ajustes))
                {
                    // Aquí llamas a tu gestor de estados para cambiar a ajustes
                    StateManagement.changeState(States.State_Settings);
                }
                else if (Raylib.CheckCollisionPointRec(mousePos, Creditos))
                {
                    // Aquí llamas a tu gestor de estados para cambiar a créditos
                    StateManagement.changeState(States.State_Credits);
                }
            }
        }

        //  //Logica Continua de ese estado
        public void Update()
        {
            //Aqui hacer que los botones se oscurezcan al pasar el raton por encima del boton pero sin pulsar
        }

        //Mostrar cambios por pantalla
        public void Render()
        {
            // ((Dibujar Fondo))
            _bg.Render();

            Raylib.DrawRectangleRec(Jugar, Color.DarkGray);
            Raylib.DrawText("JUGAR", (int)Jugar.X + 60, (int)Jugar.Y + 15, 20, Color.White);

            Raylib.DrawRectangleRec(Ajustes, Color.DarkGray);
            Raylib.DrawText("AJUSTES", (int)Ajustes.X + 45, (int)Ajustes.Y + 15, 20, Color.White);

            Raylib.DrawRectangleRec(Creditos, Color.DarkGray);
            Raylib.DrawText("CREDITOS", (int)Creditos.X + 40, (int)Creditos.Y + 15, 20, Color.White);
        }

        public void Exit()
        {
            //Limpieza
            _bg.Unload();
        }
    }
}