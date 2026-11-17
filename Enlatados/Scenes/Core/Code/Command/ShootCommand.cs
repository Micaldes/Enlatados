using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enlatados.Scenes.Core.Code.Objects;
using Enlatados.Scenes.Core.Code.Interfaces;
namespace Enlatados.Scenes.Core.Code.Command
    
{
    public class ShootCommand : ICommand
    {

        private Player _player; //Referencia a player

        public ShootCommand(GameObject player)
        {
            if(player is Player p)
            {
                this._player = p;
            }
        }

        public void execute()
        {
            _player.NotifyObservers(EventId.PlayerShoots);
        }
    }
}
