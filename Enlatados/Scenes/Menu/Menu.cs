using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

       

        // AREAS BOTONES (Ajusta los números según tu resolución)
        private Rectangle Jugar = new Rectangle(540, 300, 200, 50);
        private Rectangle Ajustes = new Rectangle(540, 370, 200, 50);
        private Rectangle Creditos = new Rectangle(540, 440, 200, 50);

        public void Enter() //Es un preload
        {
            //Inicialización de variables si hace falta
        }

        public void HandleInput()
        {
            if (Raylib.IsMouseButtonPressed(MouseButton.Right))
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
        }

        //Mostrar cambios por pantalla
        public void Render()
        {
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
        }
    }
}