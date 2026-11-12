using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Enlatados.Components
{
    public class Lata : GameObject
    {
        private  float speed { get; set; } // Para la lata 
        public Lata(Vector2 position, float speed, GameLoop parent) : base(parent)
        { 
            MovementComponent = new LataMovementComponent(this);
            
        }

    }
}
