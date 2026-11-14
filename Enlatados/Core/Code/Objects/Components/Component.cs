using Enlatados.Core.Code.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enlatados.Core.Code.Objects.Components;

public abstract class Component
{
    public GameObject Owner { get; private set; }

    public Component(GameObject owner)
    {
        Owner = owner;
    }
}