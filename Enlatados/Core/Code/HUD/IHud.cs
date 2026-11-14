using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enlatados.Core.Code.HUD
{
    public interface IHud
    {

        public void Update(float deltaFijo);
        public void Render();


    }
}
