using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enlatados.Scenes
{
    public interface IState
    {
        public States StateID { get; } //Identificador del estado actual

        public StateManager StateManagement { get; set; }

        public void HandleInput();
        public void Update(); //Logica Continua de ese estado
        public void Render();

        public void Enter();
        public void Exit();
    }
}
