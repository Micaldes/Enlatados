using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public struct PlayerEventData
{
    public EventId EventType; //Unicamente permite valores de la enumeracion evidentemente

    public PlayerEventData(EventId eventType)
    {
        EventType = eventType;
    }
}

