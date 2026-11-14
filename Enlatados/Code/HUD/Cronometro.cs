using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
namespace Enlatados.Code.HUD
{
    public  class Cronometro : IHud, IObserver<EventId>
    {
        private float time = 30;

        public void Update(float deltaFijo)
        {
            time -= deltaFijo;
        }

        public void Render() //Aqui lo casteamos a entero para que se vea bien
        {
            Raylib.DrawText("Time: " + (int)Math.Ceiling(time), 20, 20, 40, Color.White);
        }


        public void OnUpdate(EventId data)
        {
            if(data == EventId.LataDestroyed)
            {
                time += 5;
            }
        }

    }
}
