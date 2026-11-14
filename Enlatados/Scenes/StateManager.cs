using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enlatados.Scenes
{
    public class StateManager //Singleton
    {
        public static StateManager instance;

        private StateManager()  { } //Privatizamos el constructor


        public static StateManager getInstance()
        {
            if(instance == null)
            {
                instance = new StateManager();
            }
            return instance;
        }


        public void changeState(States StateID)
        {

        }

       
    }
}
