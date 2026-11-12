using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enlatados.Components;

public abstract class Component
{
    public GameObject Owner { get; private set; }

    public Component(GameObject owner)
    {
        this.Owner = owner;
    }
}