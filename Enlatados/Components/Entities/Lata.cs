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
    
        public Lata(Vector2 position, float speed) : base(position, speed)
        {
            MovementComponent = new movementLataComponent();
            
        }

    }
}
